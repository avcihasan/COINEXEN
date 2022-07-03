using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using COINEXEN.Identity;

namespace COINEXEN.Entity
{
    public class DataContext:DbContext
    {

        public DataContext():base("dataConnection")
        {
           
        }


        public DbSet<Coin> Coin { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }

        
        public DbSet<CoinCuzdan> CoinCuzdans { get; set; }
        public DbSet<CoinCuzdanLine> CoinCuzdanLines { get; set; }
        public DbSet<CuzdanSatis> CuzdanSatiss { get; set; }
        public DbSet<CuzdanAlim> CuzdanAlims { get; set; }
        public DbSet<Message> Messages { get; set; }



    }
}