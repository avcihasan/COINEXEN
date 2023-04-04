using COINEXEN.Core.Services;
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

            services.AddAutoMapper(Assembly.GetAssembly(typeof(MapProfile)));
        }
    }
}
