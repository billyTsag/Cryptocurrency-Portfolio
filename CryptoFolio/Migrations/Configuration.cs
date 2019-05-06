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
                new Coin() { Name = "XRP" },
                new Coin() { Name = "Bitcoin Cash" },
                new Coin() { Name = "EOS" },
                new Coin() { Name = "Litecoin"},
                new Coin() { Name = "Binance Coin"},
                new Coin() { Name = "Tether" },
                new Coin() { Name = "Cardano" },
                new Coin() { Name = "Stellar"},
                new Coin() { Name = "TRON" },
                new Coin() { Name = "Monero"},
                new Coin() { Name = "Cosmos"},
                new Coin() { Name = "Dash" },
                new Coin() { Name = "Bitcoin SV"},
                new Coin() { Name = "Tezos" },
                new Coin() { Name = "IOTA"},
                new Coin() { Name = "Ontology"},
                new Coin() { Name = "Ethereum Classic" },
                new Coin() { Name = "NEO" },
                new Coin() { Name = "Maker" },
                new Coin() { Name = "OKB" },
                new Coin() { Name = "NEM" },
                new Coin() { Name = "Basic Attention Token" },
                new Coin() { Name = "Zcash" },
                new Coin() { Name = "Crypto.com Chain" },
                new Coin() { Name = "VeChain" },
                new Coin() { Name = "Bitcoin Gold" },
                new Coin() { Name = "Dogecoin" },
                new Coin() { Name = "USD Coin" },
                new Coin() { Name = "Decred" },
                new Coin() { Name = "TrueUSD" },
                new Coin() { Name = "Holo" },
                new Coin() { Name = "Augur" },
                new Coin() { Name = "Lisk" },
                new Coin() { Name = "OmiseGO" },
                new Coin() { Name = "Waves" },
                new Coin() { Name = "Qtum" },
                new Coin() { Name = "ChainLink" },
                new Coin() { Name = "Nano" },
                new Coin() { Name = "Paxos Standard" },
                new Coin() { Name = "Bitcoin Diamond" },
                new Coin() { Name = "Bytecoin" },
                new Coin() { Name = "Ravencoin" },
                new Coin() { Name = "0x" },
                new Coin() { Name = "ICON" },
                new Coin() { Name = "IOST" },
                new Coin() { Name = "Bytom" },
                new Coin() { Name = "BitShares" },
                new Coin() { Name = "Zilliqa" },
                new Coin() { Name = "Pundi X" },
                new Coin() { Name = "Aeternity" },
                new Coin() { Name = "Enjin Coin" },
                new Coin() { Name = "DigiByte" },
                new Coin() { Name = "Komodo" },
                new Coin() { Name = "Verge" },
                new Coin() { Name = "Siacoin" },
                new Coin() { Name = "Steem" },
                new Coin() { Name = "KuCoin Shares" },
                new Coin() { Name = "Huobi Token" },
                new Coin() { Name = "Dai" },
                new Coin() { Name = "Factom" },
                new Coin() { Name = "Stratis" },
                new Coin() { Name = "Status" },
                new Coin() { Name = "Crypto.com" },
                new Coin() { Name = "Mixin" },
                new Coin() { Name = "Aurora" },
                new Coin() { Name = "Golem" },
                new Coin() { Name = "Decentraland" },
                new Coin() { Name = "Ark" },
                new Coin() { Name = "Theta Network" },
                new Coin() { Name = "Ardor" },
                new Coin() { Name = "MonaCoin" },
                new Coin() { Name = "WAX" },
                new Coin() { Name = "GXChain" },
                new Coin() { Name = "MaidSafeCoin" },
                new Coin() { Name = "Horizen" },
                new Coin() { Name = "DigixDAO" },
                new Coin() { Name = "Lambda" },
                new Coin() { Name = "Ultrain" },
                new Coin() { Name = "Aion" },
                new Coin() { Name = "Waltonchain" },
                new Coin() { Name = "BitTorrent" },
                new Coin() { Name = "aelf" },
                new Coin() { Name = "Reddcoin" },
                new Coin() { Name = "Electroneum" },
                new Coin() { Name = "HyperCash" },
                new Coin() { Name = "Zcoin" },
                new Coin() { Name = "ODEM" },
                new Coin() { Name = "Revain" },
                new Coin() { Name = "NEXO" },
                new Coin() { Name = "Dent" },
                new Coin() { Name = "Loopring" },
                new Coin() { Name = "Power Ledger" },
                new Coin() { Name = "QASH" },
                new Coin() { Name = "Gemini Dollar" },
                new Coin() { Name = "Elastos" },
                new Coin() { Name = "Nebulas" },
                new Coin() { Name = "Metaverse ETP" },
                new Coin() { Name = "Loom Network" }
                );            
            context.SaveChanges();
            
        }
    }
}
