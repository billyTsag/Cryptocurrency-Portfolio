using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CryptoFolio.Models
{
    public class Portfolio
    {
        public int PortfolioID { get; set; }

        public ApplicationUser User { get; set; }
               
        public string UserID { get; set; }       

        public string Name { get; set; }

        public DateTime DateCreated { get; set; }

    }
}