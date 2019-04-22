using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CryptoFolio.Models
{
    public class Transaction
    {
        public int TransactionID { get; set; }

        public decimal Quantity { get; set; }

        public DateTime DateOfPurchase { get; set; }

        public bool Buy { get; set; }

        public bool Watch { get; set; }
    }
}