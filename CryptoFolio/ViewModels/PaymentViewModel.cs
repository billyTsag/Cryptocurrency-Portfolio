using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CryptoFolio.ViewModels
{
    
    public class PaymentViewModel
    {
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        [DataType(DataType.CreditCard)]
        public int CardNumber { get; set; }
        [DataType(DataType.Date)]
        public DateTime Month { get; set; }
        [DataType(DataType.Date)]
        public DateTime Year { get; set; }
        public int Cvc { get; set; }
    }
}