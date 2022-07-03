using COINEXEN.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace COINEXEN.Models
{
    public class Cart
    {
        private List<CartLine> _cardlines = new List<CartLine>();
        public List<CartLine> CartLines
        {
            get { return _cardlines; }
        }
        public void AddCoin(Coin coin, int quantity)
        {
            _cardlines.Clear();
            var line = _cardlines.Where(i => i.Coin.Id == coin.Id).FirstOrDefault();
            if (line==null)//varsa arttır
            {
                _cardlines.Add(new CartLine() { Coin = coin, Quantity = quantity });
            }
           else
            {
                line.Quantity += quantity;
          
            }



        }

        public double Total()
        {
            return _cardlines.Sum(i => i.Coin.Price * i.Quantity);
        }
        public void  Clear()
        {
            _cardlines.Clear();
        }

      
    }

    public class CartLine
    {
        public Coin Coin { get; set; }
        public int Quantity { get; set; }
    }
}