using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CryptoFolio.ViewModels
{
    public class PaymentViewModel
    {
        public decimal Price { get; set; }
        public int CardNumber { get; set; }
        public DateTime Month { get; set; }
        public DateTime Year { get; set; }
        public int Cvc { get; set; }
    }
}