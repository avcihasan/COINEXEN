using COINEXEN.Core.Entities;
using COINEXEN.Core.Entities.BuyingAndSelling;
using COINEXEN.Core.Entities.Identity;
using COINEXEN.Core.Entities.Wallet;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace COINEXEN.Repository.Contexts
{
    public class AppDbContext : IdentityDbContext<AppUser,AppRole,int>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Coin> Coins { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<SellCoin> SellCoins { get; set; }
        public DbSet<BuyCoin> BuyCoins { get; set; }
        public DbSet<CoinWallet> CoinWallets { get; set; }
        public DbSet<CoinWalletLine> CoinWalletLines { get; set; }
        public DbSet<UserWallet> UserWallets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUser>()
               .HasOne(p => p.CoinWallet)
               .WithOne(p => p.AppUser)
               .HasForeignKey<CoinWallet>(p => p.Id);

            modelBuilder.Entity<AppUser>()
               .HasOne(p => p.Wallet)
               .WithOne(p => p.AppUser)
               .HasForeignKey<UserWallet>(p => p.Id);

            modelBuilder.SeedDatas();
            modelBuilder.SeedRoles();
            modelBuilder.SeedUsers();

            base.OnModelCreating(modelBuilder);
        }
    }
}
