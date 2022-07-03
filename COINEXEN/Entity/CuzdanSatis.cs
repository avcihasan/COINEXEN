﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COINEXEN.Entity
{
    public class CuzdanSatis
    {
        public int Id { get; set; }
        public string CoinName { get; set; }
        public int Quantity { get; set; }
        public double CoinPrice { get; set; }
        public double TotalPrice { get; set; }
        public DateTime SatisDate { get; set; }

        public string UserName { get; set; }
    }
}