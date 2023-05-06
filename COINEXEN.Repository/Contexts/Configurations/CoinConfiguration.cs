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
            builder
                .HasOne(x => x.Category)
                .WithMany(x=>x.Coins)
                .HasForeignKey(x=>x.CategoryId);




            builder
                .HasData(
                     new Coin() { Id =1, Name = "Acoin", PhotoPath = "A-Photo", Description = "A-Description", Stock = 10, Price = 1.2,ShortName="A", CategoryId = 1 },
                     new Coin() { Id = 2, Name = "Bcoin", PhotoPath = "B-Photo", Description = "B-Description", Stock = 10, Price = 1.2, ShortName = "A", CategoryId = 3},
                     new Coin() { Id = 3, Name = "Ccoin", PhotoPath = "C-Photo", Description = "C-Description", Stock = 10, Price = 1.2, ShortName = "A", CategoryId = 3 },
                     new Coin() { Id = 4, Name = "Dcoin", PhotoPath = "D-Photo", Description = "D-Description", Stock = 10, Price = 1.2, ShortName = "A", CategoryId = 1 },
                     new Coin() { Id =5, Name = "Ecoin", PhotoPath = "E-Photo", Description = "E-Description", Stock = 10, Price = 1.2, ShortName = "A", CategoryId = 2}
                );
        }
    }
}
