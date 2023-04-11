using COINEXEN.Core.Entities;
using COINEXEN.Core.Entities.Identity;
using COINEXEN.Core.Entities.Wallet;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace COINEXEN.Repository.Contexts
{
    public class AppDbContext : IdentityDbContext<AppUser,AppRole, Guid>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Coin> Coins { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<CoinTransaction> CoinTransactions { get; set; }
        public DbSet<CoinWallet> CoinWallets { get; set; }
        public DbSet<CoinWalletLine> CoinWalletLines { get; set; }
        public DbSet<UserWallet> UserWallets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<UserWallet>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<AppUser>()
                .HasOne(x => x.Wallet)
                .WithOne(x => x.AppUser)
                .HasForeignKey<UserWallet>(x => x.Id);

            modelBuilder.Entity<CoinWallet>()
                .HasKey(key => key.Id);

            modelBuilder.Entity<AppUser>()
               .HasOne(p => p.CoinWallet)
               .WithOne(p => p.AppUser)
               .HasForeignKey<CoinWallet>(p => p.Id);

            //modelBuilder.SeedDatas();
            //modelBuilder.SeedRoles();
            //modelBuilder.SeedUsers();

            base.OnModelCreating(modelBuilder);
        }

    }
}
