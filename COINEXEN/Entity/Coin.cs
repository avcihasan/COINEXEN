using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace COINEXEN.Entity
{
    public class Coin
    {
        public int Id { get; set; }
        [DisplayName("Coin Adı")]
        public string Name { get; set; }
        [DisplayName("Coin Resmi")]
        public string Photo { get; set; }
        [DisplayName("Coin Açıklaması")]
        public string Description { get; set; }
        [DisplayName("Coin Adeti")]
        public int Stock { get; set; }
        [DisplayName("Coin Fiyatı")]
        public double Price { get; set; }
        public double OldPrice { get; set; }
        [DisplayName("Coin Kısa Kodu")]
        public string KısaKod { get; set; }

        public int CuzdanAdeti { get; set; }

        public string AlimSayisi { get; set; }


        public int CategoryId { get; set; }
        public Category Category{ get; set; }


     




    }
}