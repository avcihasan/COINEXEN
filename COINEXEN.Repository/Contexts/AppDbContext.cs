using COINEXEN.Core.Entities;
using COINEXEN.Core.Entities.Identity;
using COINEXEN.Core.Entities.Wallet;
using COINEXEN.Repository.Contexts.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace COINEXEN.Repository.Contexts
{
    public class AppDbContext : IdentityDbContext<AppUser,AppRole, int>
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
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(CoinConfiguration)));
            base.OnModelCreating(modelBuilder);
        }

    }
}
