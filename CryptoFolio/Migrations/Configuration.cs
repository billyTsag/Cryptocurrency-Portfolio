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
                new Coin() { Name = "Bitcoin", Price = 5089.25m, Symbol = "BTC", Supply = 17664112m },
                new Coin() { Name = "Ethereum", Price = 164.35m, Symbol = "ETH", Supply = 105646790m },
                new Coin() { Name = "Ripple", Price = 0.35m, Symbol = "XRP", Supply = 410000000m },
                new Coin() { Name = "Bitcoin Cash", Price = 276.25m, Symbol = "BCH", Supply = 17000000m },
                new Coin() { Name = "EOS", Price = 5.35m, Symbol = "EOS", Supply = 17000000m },
                new Coin() { Name = "Litecoin", Price = 78.25m, Symbol = "LTC", Supply = 17000000m },
                new Coin() { Name = "Binance Coin", Price = 18.25m, Symbol = "BNB", Supply = 17000000m },
                new Coin() { Name = "Tether", Price = 1.01m, Symbol = "USDT", Supply = 17000000m },
                new Coin() { Name = "Stellar", Price = 0.25m, Symbol = "XLM", Supply = 17000000m },
                new Coin() { Name = "TRON", Price = 0.025m, Symbol = "TRX", Supply = 17000000m },
                new Coin() { Name = "Monero", Price = 65.85m, Symbol = "XMR", Supply = 17000000m },
                new Coin() { Name = "Dash", Price = 119.85m, Symbol = "DASH", Supply = 17000000m },
                new Coin() { Name = "IOTA", Price = 0.35m, Symbol = "MIOTA", Supply = 17000000m },
                new Coin() { Name = "NEO", Price = 11.5m, Symbol = "NEO", Supply = 17000000m },
                new Coin() { Name = "Ethereum Classic", Price = 6.85m, Symbol = "ETC", Supply = 17000000m },
                new Coin() { Name = "Ontology", Price = 1.35m, Symbol = "ONT", Supply = 17000000m },
                new Coin() { Name = "Tezos", Price = 0.98m, Symbol = "XTZ", Supply = 17000000m },
                new Coin() { Name = "Maker", Price = 636.1m, Symbol = "MKR", Supply = 17000000m },
                new Coin() { Name = "NEM", Price = 0.065m, Symbol = "XEM", Supply = 17000000m },
                new Coin() { Name = "Zcash", Price = 69.85m, Symbol = "ZEC", Supply = 17000000m }
                );            
            context.SaveChanges();
            
        }
    }
}
