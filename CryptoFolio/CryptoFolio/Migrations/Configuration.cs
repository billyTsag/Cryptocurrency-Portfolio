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
                new Coin() { Name = "Bitcoin", Price = 3046.25m, Symbol = "btc", Supply = 17000000m },
                new Coin() { Name = "Ethereum", Price = 3056.25m, Symbol = "btbjnc", Supply = 17000000m },
                new Coin() { Name = "Kostas", Price = 3096.25m, Symbol = "jh", Supply = 17000000m },
                new Coin() { Name = "Nikos", Price = 3856.25m, Symbol = "cv", Supply = 17000000m },
                new Coin() { Name = "Petros", Price = 4046.25m, Symbol = "dfg", Supply = 17000000m },
                new Coin() { Name = "Makius", Price = 52246.25m, Symbol = "rtghj", Supply = 17000000m },
                new Coin() { Name = "Billy", Price = 3089.25m, Symbol = "ert", Supply = 17000000m },
                new Coin() { Name = "Gamiesai", Price = 3046.25m, Symbol = "sxcv", Supply = 17000000m },
                new Coin() { Name = "Gamiemai", Price = 3046.25m, Symbol = "wert", Supply = 17000000m },
                new Coin() { Name = "Gamietai", Price = 3046.25m, Symbol = "bnm", Supply = 17000000m }
                );
            context.SaveChanges();
            
        }
    }
}
