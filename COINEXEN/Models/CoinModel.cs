using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COINEXEN.Models
{
    public class CoinModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }
        public double OldPrice { get; set; }
        public string KısaKod { get; set; }
        public string AlimSayisi { get; set; }

        public int CategoryId { get; set; }
        
    }
}