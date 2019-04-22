using CryptoFolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CryptoFolio.ViewModels
{
    public class MarketViewModel
    {
        public int CoinID { get; set; }

        public IEnumerable<Coin> Coins { get; set; }

        public DateTime DatePurchased { get; set; }

        public decimal Quantity { get; set; }

        public int PortfolioID { get; set; }

        public int TransactionID { get; set; }
    }
}