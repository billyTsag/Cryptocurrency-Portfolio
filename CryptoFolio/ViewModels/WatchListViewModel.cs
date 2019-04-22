using CryptoFolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CryptoFolio.ViewModels
{
    public class WatchListViewModel
    {
        public int CoinID { get; set; }
        public IEnumerable<Coin> Coin { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public decimal Price { get; set; }
        public decimal Supply { get; set; }
        public bool Watch { get; set; }
        public int TransactionID { get; set; }
        public int PortfolioID { get; set; }
    }
}