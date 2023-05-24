using COINEXEN.Core.Entities.Identity;
using COINEXEN.Core.Entities.Wallet;
using COINEXEN.Core.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace COINEXEN.Repository.Contexts.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder
             .HasOne(x => x.Wallet)
             .WithOne(x => x.AppUser)
             .HasForeignKey<UserWallet>(x => x.Id);

            builder
               .HasOne(p => p.CoinWallet)
               .WithOne(p => p.AppUser)
               .HasForeignKey<CoinWallet>(p => p.Id);
           
        }
    }
}
