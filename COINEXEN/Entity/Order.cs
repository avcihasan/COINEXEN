using COINEXEN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COINEXEN.Entity
{
    public class Order
    {
        public int Id { get; set; }
        public double Total { get; set; }
        public DateTime OrderDate { get; set; }

        public virtual List<OrderLine> OrderLines { get; set; }

        public string Username { get; set; }

        public int Quantity { get; set; }
        public int OldQuantity { get; set; }

        public string CoinName { get; set; }



        public double CoinFiyat { get; set; }
    }


    public class OrderLine
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string CoinName { get; set; }
        public string Username { get; set; }

        public int OrderId { get; set; }
        public virtual Order Order { get; set; }

        public int CoinId { get; set; }
        public virtual Coin Coin { get; set; }

        


    }
}