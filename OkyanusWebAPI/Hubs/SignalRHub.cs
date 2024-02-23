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
        private readonly IProductService _productService;
        private readonly IMapper _mapper;


        public SignalRHub(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        public async Task SendProduct()
        {
            var value = _productService.TGetListAll();
            await Clients.All.SendAsync("ReceiveProduct", value);
        }

    }
}
