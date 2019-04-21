using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CryptoFolio.Models
{
    public class Coin
    {
        public int CoinID { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public decimal Price { get; set; }
        public decimal Supply { get; set; }
    }
}