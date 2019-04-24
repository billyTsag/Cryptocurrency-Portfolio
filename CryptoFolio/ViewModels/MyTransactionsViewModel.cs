using CryptoFolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CryptoFolio.ViewModels
{
    public class MyTransactionsViewModel
    {
        public int TransactionID { get; set; }
        public int PortfolioID { get; set; }
        public string PortfolioName { get; set; }
        public string CoinName { get; set; }
        public int CoinID { get; set; }
        public decimal Quantity { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public bool Buy { get; set; }
        public IEnumerable<Portfolio> Portfolios { get; set; }
        public decimal CoinPrice { get; set; }
        //public string SelectedPortfolio { get; set; }

    }
}