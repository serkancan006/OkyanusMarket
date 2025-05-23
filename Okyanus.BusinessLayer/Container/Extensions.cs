﻿using Microsoft.Extensions.DependencyInjection;
using Okyanus.BusinessLayer.Abstract;
using Okyanus.BusinessLayer.Abstract.ExternalService;
using Okyanus.BusinessLayer.Concrete;
using Okyanus.BusinessLayer.Concrete.ExternalService;
using Okyanus.DataAccessLayer.Abstract;
using Okyanus.DataAccessLayer.EntityFramework;

namespace Okyanus.BusinessLayer.Container
{
    public static class Extensions
    {
        public static void ContainerDependencies(this IServiceCollection services)
        {
            services.AddScoped<IAboutDal, EfAboutDal>();
            services.AddScoped<IAboutService, AboutManager>();

            //services.AddScoped<IBasketDal, EfBasketDal>();
            //services.AddScoped<IBasketService, BasketManager>();

            services.AddScoped<IBranchUsDal, EfBranchUsDal>();
            services.AddScoped<IBranchUsService, BranchUsManager>();

            services.AddScoped<IGroupDal, EfGroupDal>();
            services.AddScoped<IGroupService, GroupManager>();

            services.AddScoped<IContactDal, EfContactDal>();
            services.AddScoped<IContactService, ContactManager>();

            services.AddScoped<IOrderDal, EfOrderDal>();
            services.AddScoped<IOrderService, OrderManager>();

            services.AddScoped<IOrderDetailDal, EfOrderDetailDal>();
            services.AddScoped<IOrderDetailService, OrderDetailManager>();

            services.AddScoped<IProductDal, EfProductDal>();
            services.AddScoped<IProductService, ProductManager>();

            services.AddScoped<ISliderDal, EfSliderDal>();
            services.AddScoped<ISliderService, SliderManager>();

            services.AddScoped<ISocialMediaDal, EfSocialMediaDal>();
            services.AddScoped<ISocialMediaService, SocialMediaManager>();

            services.AddScoped<IMyPhoneDal, EfMyPhoneDal>();
            services.AddScoped<IMyPhoneService, MyPhoneManager>();

            services.AddScoped<IContactMessageDal, EfContactMessageDal>();
            services.AddScoped<IContactMessageService, ContactMessageManager>();

            services.AddScoped<IUserAdresDal, EfUserAdresDal>();
            services.AddScoped<IUserAdresService, UserAdresManager>();

            services.AddScoped<ICityDal, EfCityDal>();
            services.AddScoped<ICityService, CityManager>();

            services.AddScoped<IDistrictDal, EfDistrictDal>();
            services.AddScoped<IDistrictService, DistrictManager>();

            services.AddScoped<IDeliveryTimeDal, EfDeliveryTimeDal>();
            services.AddScoped<IDeliveryTimeService, DeliveryTimeManager>();

            services.AddScoped<IMarkaDal, EfMarkaDal>();
            services.AddScoped<IMarkaService, MarkaManager>();

            services.AddScoped<IProductTypeDal, EfProductTypeDal>();
            services.AddScoped<IProductTypeService, ProductTypeManager>();

            services.AddScoped<ISssDal, EfSssDal>();
            services.AddScoped<ISssService, SssManager>();

            services.AddScoped<ITermsAndConditionDal, EfTermsAndConditionDal>();
            services.AddScoped<ITermsAndConditionService, TermsAndConditionManager>();

            services.AddScoped<IFavoriUrunlerDal, EfFavoriUrunlerDal>();
            services.AddScoped<IFavoriUrunlerService, FavoriUrunlerManager>();

            //Default Service 
            services.AddHttpClient();

            //External Service
            services.AddScoped<IMailService, MailManager>();
            services.AddScoped<ICreateTokenService, CreateTokenManager>();
            services.AddScoped<IFileOperationsService, FileOperationsManager>();
            services.AddScoped<ISmsService, SmsManager>();
        }
    }
}
