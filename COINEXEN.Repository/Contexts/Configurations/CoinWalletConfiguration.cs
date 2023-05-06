using COINEXEN.Core.Entities.Wallet;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COINEXEN.Repository.Contexts.Configurations
{
    public class CoinWalletConfiguration : IEntityTypeConfiguration<CoinWallet>
    {
        public void Configure(EntityTypeBuilder<CoinWallet> builder)
        {
            builder
                .HasMany(x => x.CoinWalletLines)
                .WithOne(x=>x.CoinWallet)
                .HasForeignKey(x=>x.CoinWalletId);
        }
    }
}
