namespace CryptoFolio.Migrations
{
    using CryptoFolio.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CryptoFolio.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CryptoFolio.Models.ApplicationDbContext context)
        {
            context.Coins.AddOrUpdate(x => x.Name,
                new Coin() { Name = "Bitcoin" },
                new Coin() { Name = "Ethereum" },
                new Coin() { Name = "Ripple" },
                new Coin() { Name = "Bitcoin Cash" },
                new Coin() { Name = "EOS" },
                new Coin() { Name = "Litecoin"},
                new Coin() { Name = "Binance Coin"},
                new Coin() { Name = "Tether" },
                new Coin() { Name = "Stellar" },
                new Coin() { Name = "TRON"},
                new Coin() { Name = "Monero" },
                new Coin() { Name = "Dash"},
                new Coin() { Name = "IOTA"},
                new Coin() { Name = "NEO" },
                new Coin() { Name = "Ethereum Classic"},
                new Coin() { Name = "Ontology" },
                new Coin() { Name = "Tezos"},
                new Coin() { Name = "Maker"},
                new Coin() { Name = "NEM" },
                new Coin() { Name = "Zcash" }
                );            
            context.SaveChanges();
            
        }
    }
}
