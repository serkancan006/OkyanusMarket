using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Okyanus.BusinessLayer.Abstract;
using OkyanusWebAPI.Models;
using OkyanusWebAPI.Models.ProductVM;

namespace OkyanusWebAPI.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public SignalRHub(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        public async Task SendOrder()
        {
            var value = _orderService.TGetListAll();
            await Clients.All.SendAsync("ReceiveOrder", value);
        }

    }
}
