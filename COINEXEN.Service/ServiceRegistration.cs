using COINEXEN.Core.Repositories;
using COINEXEN.Core.Services;
using COINEXEN.Repository.Repositories;
using COINEXEN.Service.Mapping;
using COINEXEN.Service.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace COINEXEN.Service
{
    public static class ServiceRegistration
    {
        public static void AddServiceServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IWalletService, WalletService>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICoinService, CoinService>();
            services.AddScoped<IBasketService, BasketService>();



            services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));

            services.AddAutoMapper(Assembly.GetAssembly(typeof(MapProfile)));
        }
    }
}
