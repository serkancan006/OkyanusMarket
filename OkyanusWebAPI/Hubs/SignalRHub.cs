using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Okyanus.BusinessLayer.Abstract;
using Okyanus.EntityLayer.Entities;
using OkyanusWebAPI.Models;
using OkyanusWebAPI.Models.OrderVM;
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
            var orderList = _mapper.Map<List<ResultOrderVM>>(value);
            await Clients.All.SendAsync("ReceiveOrder", orderList);
        }

    }
}
