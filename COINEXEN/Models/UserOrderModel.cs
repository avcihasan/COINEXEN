using COINEXEN.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COINEXEN.Models
{
    public class UserOrderModel
    {
        public int Id { get; set; }
        public double Total { get; set; }
        public DateTime OrderDate { get; set; }
        public int Quantity { get; set; }
        public int OldQuantity { get; set; }
        public string CoinName { get; set; }
        public double CoinFiyat { get; set; }

        public string Username { get; set; }
        public int CoinId { get; set; }




    }
}