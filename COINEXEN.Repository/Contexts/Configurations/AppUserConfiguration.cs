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

            AppUser user = new AppUser
            {
                Id = 1,
                Name = "Hasan",
                Surname = "Avcı",
                UserName = "asanator",
                Email = "hsnavci7@gmail.com",
                Gender = Gender.Erkek,
                City = City.İstanbul,
                Birthday = 1999,
                PhoneNumber = "05380614193",
                WalletId = 1
            };

            PasswordHasher<AppUser> ph = new PasswordHasher<AppUser>();
            user.PasswordHash = ph.HashPassword(user, "123");
            builder
                .HasData(user);
        }
    }
}
