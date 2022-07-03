using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COINEXEN.Models
{
    public class AdminOrderModel
    {
        public int Id { get; set; }
        public double Total { get; set; }
        public DateTime OrderDate { get; set; }
        public int Quantity { get; set; }
        public string CoinName { get; set; }
        public double CoinFiyat { get; set; }
        public string Username { get; set; }   
    }
}