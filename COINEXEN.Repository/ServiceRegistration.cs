using COINEXEN.Core.Entities.Identity;
using COINEXEN.Core.UnitOfWorks;
using COINEXEN.Repository.Contexts;
using COINEXEN.Repository.UnitOfWorks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

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

            services.AddScoped<IUnitOfWork,UnitOfWork>();
        }
    }
}
