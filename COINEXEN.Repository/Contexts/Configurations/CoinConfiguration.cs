using COINEXEN.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COINEXEN.Repository.Contexts.Configurations
{
    public class CoinConfiguration : IEntityTypeConfiguration<Coin>
    {
        public void Configure(EntityTypeBuilder<Coin> builder)
        {
            builder.HasKey(x=>x.Id);

            builder
                .HasOne(x => x.Category)
                .WithMany(x => x.Coins)
                .HasForeignKey(x => x.CategoryId);

            builder
                .HasData(SeedCoins());
        }

        private List<Coin> SeedCoins()
        {
            List<string> shortNames = new()
            {
                        "a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","x","y","z"
            };
            List<Coin> coins = new();
            int i = 1;
            foreach (var shortName in shortNames)
            {
                coins.Add(
                    new Coin() 
                    { 
                        Id = i, 
                        Name = $"{shortName.ToUpper()}Coin", 
                        Description = $"{shortName.ToUpper()}-Description", 
                        Stock = 10, 
                        Price = 1.6, 
                        ShortName = shortName, 
                        CategoryId = 1
                    });
                i++;
            }
            return coins;
        }
    }
}
