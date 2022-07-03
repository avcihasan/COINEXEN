using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace COINEXEN.Entity
{
    public class CoinCuzdan
    {

        public int Id { get; set; }
        public string UserName { get; set; }
        public List<CoinCuzdanLine> CoinCuzdanLine { get; set; }

    }
    public class CoinCuzdanLine
    {
        public int Id { get; set; }
        public int Quantity { get; set; }

        public string UserName { get; set; }

        public int CoinCuzdanId { get; set; }
        public virtual CoinCuzdan CoinCuzdan { get; set; }

        public int CoinId { get; set; }
        public virtual Coin Coin { get; set; }




    }
}