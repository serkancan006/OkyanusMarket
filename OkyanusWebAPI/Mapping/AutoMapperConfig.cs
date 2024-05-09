using AutoMapper;
using Okyanus.EntityLayer.Entities;
using OkyanusWebAPI.Models.AboutVM;
using OkyanusWebAPI.Models.BasketVM;
using OkyanusWebAPI.Models.BranchUsVM;
using OkyanusWebAPI.Models.CityVM;
using OkyanusWebAPI.Models.ContactMessageVM;
using OkyanusWebAPI.Models.ContactVM;
using OkyanusWebAPI.Models.DeliveryTimeVM;
using OkyanusWebAPI.Models.DistrictVM;
using OkyanusWebAPI.Models.FavoriUrunlerVM;
using OkyanusWebAPI.Models.GroupVM;
using OkyanusWebAPI.Models.MarkaVM;
using OkyanusWebAPI.Models.MyPhoneVM;
using OkyanusWebAPI.Models.OrderDetailVM;
using OkyanusWebAPI.Models.OrderVM;
using OkyanusWebAPI.Models.ProductTypeVM;
using OkyanusWebAPI.Models.ProductVM;
using OkyanusWebAPI.Models.SliderVM;
using OkyanusWebAPI.Models.SocialMediaVM;
using OkyanusWebAPI.Models.SssVM;
using OkyanusWebAPI.Models.TermsAndConditionVM;
using OkyanusWebAPI.Models.UserAdresVM;

namespace OkyanusWebAPI.Mapping
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ResultAboutVM, About>().ReverseMap();
            CreateMap<UpdateAboutVM, About>().ReverseMap();
            CreateMap<CreateAboutVM, About>().ReverseMap();

            //CreateMap<ResultBasketVM, Basket>().ReverseMap();
            //CreateMap<UpdateBasketVM, Basket>().ReverseMap();
            //CreateMap<CreateBasketVM, Basket>().ReverseMap();

            CreateMap<ResultBranchUsVM, BranchUs>().ReverseMap();
            CreateMap<UpdateBranchUsVM, BranchUs>().ReverseMap();
            CreateMap<CreateBranchUsVM, BranchUs>().ReverseMap();

            CreateMap<ResultGroupVM, Group>().ReverseMap();
            CreateMap<UpdateGroupVM, Group>().ReverseMap();
            CreateMap<CreateGroupVM, Group>().ReverseMap();

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

            CreateMap<ResultUserAdresVM, UserAdres>().ReverseMap();
            CreateMap<UpdateUserAdresVM, UserAdres>().ReverseMap();
            CreateMap<CreateUserAdresVM, UserAdres>().ReverseMap();

            CreateMap<ResultDistrictVM, District>().ReverseMap();
            CreateMap<CreateDistrictVM, District>().ReverseMap();
            CreateMap<UpdateDistrictVM, District>().ReverseMap();

            CreateMap<ResultCityVM, City>().ReverseMap();
            CreateMap<CreateCityVM, City>().ReverseMap();
            CreateMap<UpdateCityVM, City>().ReverseMap();

            CreateMap<ResultDeliveryTimeVM, DeliveryTime>().ReverseMap();
            CreateMap<CreateDeliveryTimeVM, DeliveryTime>().ReverseMap();
            CreateMap<UpdateDeliveryTimeVM, DeliveryTime>().ReverseMap();

            CreateMap<ResultMarkaVM, Marka>().ReverseMap();
            CreateMap<CreateMarkaVM, Marka>().ReverseMap();
            CreateMap<UpdateMarkaVM, Marka>().ReverseMap();

            CreateMap<ResultProductTypeVM, ProductType>().ReverseMap();
            CreateMap<CreateProductTypeVM, ProductType>().ReverseMap();
            CreateMap<UpdateProductTypeVM, ProductType>().ReverseMap();

            CreateMap<ResultSssVM, Sss>().ReverseMap();
            CreateMap<CreateSssVM, Sss>().ReverseMap();
            CreateMap<UpdateSssVM, Sss>().ReverseMap();

            CreateMap<ResultTermsAndConditionVM, TermsAndCondition>().ReverseMap();
            CreateMap<CreateTermsAndConditionVM, TermsAndCondition>().ReverseMap();
            CreateMap<UpdateTermsAndConditionVM, TermsAndCondition>().ReverseMap();

            CreateMap<ResultFavoriUrunlerVM, FavoriUrunler>().ReverseMap();
            CreateMap<CreateFavoriUrunlerVM, FavoriUrunler>().ReverseMap();
            CreateMap<UpdateFavoriUrunlerVM, FavoriUrunler>().ReverseMap();
        }
    }
}
