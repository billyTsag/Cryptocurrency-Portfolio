using CryptoFolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CryptoFolio.ViewModels
{
    public class OposNaNaiViewModel
    {
        public IEnumerable<MyTransactionsViewModel> Bla { get; set; }
        public IEnumerable<Portfolio> Portfolios { get; set; }
        public string SelectedPortfolio { get; set; }
        
    
    }
}