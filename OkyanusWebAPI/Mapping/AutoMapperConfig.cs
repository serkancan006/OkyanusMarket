using AutoMapper;
using Okyanus.EntityLayer.Entities;
using OkyanusWebAPI.Models.AboutVM;
using OkyanusWebAPI.Models.BasketVM;
using OkyanusWebAPI.Models.BranchUsVM;
using OkyanusWebAPI.Models.CategoryVM;
using OkyanusWebAPI.Models.ContactMessageVM;
using OkyanusWebAPI.Models.ContactVM;
using OkyanusWebAPI.Models.MyPhoneVM;
using OkyanusWebAPI.Models.OrderDetailVM;
using OkyanusWebAPI.Models.OrderVM;
using OkyanusWebAPI.Models.ProductVM;
using OkyanusWebAPI.Models.SliderVM;
using OkyanusWebAPI.Models.SocialMediaVM;

namespace OkyanusWebAPI.Mapping
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ResultAboutVM, About>().ReverseMap();
            CreateMap<UpdateAboutVM, About>().ReverseMap();
            CreateMap<CreateAboutVM, About>().ReverseMap();

            CreateMap<ResultBasketVM, Basket>().ReverseMap();
            CreateMap<UpdateBasketVM, Basket>().ReverseMap();
            CreateMap<CreateBasketVM, Basket>().ReverseMap();

            CreateMap<ResultBranchUsVM, BranchUs>().ReverseMap();
            CreateMap<UpdateBranchUsVM, BranchUs>().ReverseMap();
            CreateMap<CreateBranchUsVM, BranchUs>().ReverseMap();

            CreateMap<ResultCategoryVM, Category>().ReverseMap();
            CreateMap<UpdateCategoryVM, Category>().ReverseMap();
            CreateMap<CreateCategoryVM, Category>().ReverseMap();

            CreateMap<ResultContactVM, Contact>().ReverseMap();
            CreateMap<UpdateContactVM, Contact>().ReverseMap();
            CreateMap<CreateContactVM, Contact>().ReverseMap();

            CreateMap<ResultOrderVM, Order>().ReverseMap();
            CreateMap<UpdateOrderVM, Order>().ReverseMap();
            CreateMap<CreateOrderVM, Order>().ReverseMap();

            CreateMap<ResultOrderDetailVM, OrderDetail>().ReverseMap();
            CreateMap<UpdateOrderDetailVM, OrderDetail>().ReverseMap();
            CreateMap<CreateOrderDetailVM, OrderDetail>().ReverseMap();

            CreateMap<ResultProductVM, Product>().ReverseMap();
            CreateMap<UpdateProductVM, Product>().ReverseMap();
            CreateMap<CreateProductVM, Product>().ReverseMap();

            CreateMap<ResultSliderVM, Slider>().ReverseMap();
            CreateMap<UpdateSliderVM, Slider>().ReverseMap();
            CreateMap<CreateSliderVM, Slider>().ReverseMap();

            CreateMap<ResultSocialMediaVM, SocialMedia>().ReverseMap();
            CreateMap<UpdateSocialMediaVM, SocialMedia>().ReverseMap();
            CreateMap<CreateSocialMediaVM, SocialMedia>().ReverseMap();

            CreateMap<ResultMyPhoneVM, MyPhone>().ReverseMap();
            CreateMap<UpdateMyPhoneVM, MyPhone>().ReverseMap();
            CreateMap<CreateMyPhoneVM, MyPhone>().ReverseMap();

            CreateMap<ResultContactMessageVM, ContactMessage>().ReverseMap();
            CreateMap<UpdateContactMessageVM, ContactMessage>().ReverseMap();
            CreateMap<CreateContactMessageVM, ContactMessage>().ReverseMap();

        }
    }
}
