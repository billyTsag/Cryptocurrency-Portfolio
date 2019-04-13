using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CryptoFolio.Models
{
    public class PortfolioCoin
    {
        public Portfolio Portfolio { get; set; }

        public Coin Coin { get; set; }

        public Transaction Transaction { get; set; }

        [Key]
        [Column(Order=1)]
        public int PortfolioID { get; set; }

        [Key]
        [Column(Order = 2)]
        public int CoinID { get; set; }

        [Key]
        [Column(Order = 3)]
        public int TransactionID { get; set; }
    }
}