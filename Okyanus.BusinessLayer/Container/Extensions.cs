using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Okyanus.BusinessLayer.Abstract;
using Okyanus.BusinessLayer.Concrete;
using Okyanus.DataAccessLayer.Abstract;
using Okyanus.DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okyanus.BusinessLayer.Container
{
    public static class Extensions
    {
        public static void ContainerDependencies(this IServiceCollection services)
        {
            services.AddScoped<IAboutDal, EfAboutDal>();
            services.AddScoped<IAboutService, AboutManager>();

            services.AddScoped<IBasketDal, EfBasketDal>();
            services.AddScoped<IBasketService, BasketManager>();

            services.AddScoped<IBranchUsDal, EfBranchUsDal>();
            services.AddScoped<IBranchUsService, BranchUsManager>();

            services.AddScoped<ICategoryDal, EfCategoryDal>();
            services.AddScoped<ICategoryService, CategoryManager>();

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
        }
    }
}
