using COINEXEN.Core.Entities.Identity;
using COINEXEN.Repository.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COINEXEN.Repository
{
    public static class ServiceRegistration
    {
        public static void AddRepositoryServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>(builder => builder.UseSqlServer(connectionString));
            services.AddIdentity<AppUser, AppRole>(opts =>
            {
                opts.Password.RequiredLength = 3;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireDigit = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
        }
    }
}
