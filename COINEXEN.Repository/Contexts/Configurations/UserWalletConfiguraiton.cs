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
    public class UserWalletConfiguraiton : IEntityTypeConfiguration<UserWallet>
    {
        public void Configure(EntityTypeBuilder<UserWallet> builder)
        {
            builder
                .HasData
                (
                    new UserWallet() { Id = 1, Balance = 2500,AppUserId=1 }
                );
        }
    }
}
