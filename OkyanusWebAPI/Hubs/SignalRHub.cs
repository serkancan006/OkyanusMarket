using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Okyanus.BusinessLayer.Abstract;
using Okyanus.EntityLayer.Entities.identitiy;
using OkyanusWebAPI.Models;
using OkyanusWebAPI.Models.OrderVM;

namespace OkyanusWebAPI.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        public SignalRHub(IOrderService orderService, IMapper mapper, UserManager<AppUser> userManager)
        {
            _orderService = orderService;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task GetUserOrder(int id)
        {
            //var username = Context.User?.Identity?.Name;
            //var user = await _userManager.FindByNameAsync(username);
            //if (user != null)
            //{
                var values = _orderService.TAsQueryable().Include(x => x.OrderDetails).ThenInclude(x => x.Product)
                    .Where(x => x.ID == id 
                    //&& x.AppUserID == user.Id
                    ).SingleOrDefault();
                var result = _mapper.Map<ResultOrderVM>(values);
                await Clients.All.SendAsync("ReceiveUserOrderStatus", result.OrderStatus);
            //}
        }

    }
}
