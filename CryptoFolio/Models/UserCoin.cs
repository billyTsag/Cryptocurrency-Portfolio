using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CryptoFolio.Models
{
    public class UserCoin
    {
        public ApplicationUser User { get; set; }
        public Coin Coin { get; set; }

        [Key]
        [Column(Order = 1)]
        public int CoinID { get; set; }
        
        [Key]
        [Column(Order = 2)]
        public string UserID { get; set; }
    }
}