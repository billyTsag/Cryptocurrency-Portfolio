using CryptoFolio.Models;
using CryptoFolio.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CryptoFolio.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();


        [Authorize]
        [HttpGet]
        public ActionResult CreateBuyTransaction()
        {

            var coins = _context.Coins.ToList();
            var userID = User.Identity.GetUserId();

            var portfolios = _context.Portfolios.Where(x => x.UserID == userID);

            var ViewModel = new TransactionViewModel
            {
                Coins = coins,
                Portfolios = portfolios
            };
            return View(ViewModel);
        }

        [Authorize]
        [HttpGet]
        public ActionResult CreateSellTransaction()
        {
            var coins = _context.Coins.ToList();
            var userID = User.Identity.GetUserId();

            var portfolios = _context.Portfolios.Where(x => x.UserID == userID);

            var ViewModel = new TransactionViewModel
            {
                Coins = coins,
                Portfolios = portfolios
            };
            return View(ViewModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult CreateBuyTransaction(TransactionViewModel transactionViewModel)
        {
            var userId = User.Identity.GetUserId();

            
            


            var tr = new Transaction()
            {
                Quantity = transactionViewModel.Quantity,
                DateOfPurchase = transactionViewModel.DatePurchased,
                Buy = true,
                Watch = true
            };

            _context.Transactions.Add(tr);

            

            var prtc = new PortfolioCoin()
            {
                TransactionID = tr.TransactionID,
                PortfolioID = transactionViewModel.PortfolioID,
                CoinID = transactionViewModel.CoinID

            };
            _context.PortfolioCoins.Add(prtc);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        [HttpPost]
        public ActionResult CreateSellTransaction(TransactionViewModel transactionViewModel)
        {
            var userId = User.Identity.GetUserId();

            var quan =
                _context.Transactions.Where(x=>x.Buy==true)
                .Join(_context.PortfolioCoins, t => t.TransactionID, pc => pc.TransactionID, (t, pc) => new { t, pc })
                .Join(_context.Coins, pc => pc.pc.CoinID, c => c.CoinID, (pc, c) => new { pc, c })
                .Join(_context.Portfolios, tpc => tpc.pc.pc.PortfolioID, port => port.PortfolioID, (tpc, port) => new { tpc, port })
                .Where(tpc => tpc.port.UserID == userId && tpc.tpc.c.CoinID == tpc.tpc.pc.pc.CoinID)
                .Select(tpcport => new TransactionViewModel
                {
                    Quantity = tpcport.tpc.pc.t.Quantity,
                    Buy = tpcport.tpc.pc.t.Buy
                });

            
            var tr = new Transaction()
            {
                Quantity = -(transactionViewModel.Quantity),
                DateOfPurchase = transactionViewModel.DatePurchased,
                Buy = false
            };

            _context.Transactions.Add(tr);

            

            var prtc = new PortfolioCoin()
            {
                TransactionID = tr.TransactionID,
                PortfolioID = transactionViewModel.PortfolioID,
                CoinID = transactionViewModel.CoinID

            };
            _context.PortfolioCoins.Add(prtc);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        [HttpGet]
        public ActionResult ViewMyTransactions(string selectedPortfolio = "")
        {
            var userID = User.Identity.GetUserId();

            var portfolioFilters = _context.Portfolios
                .Where(x => String.IsNullOrEmpty(selectedPortfolio) || x.Name == selectedPortfolio);

            var coinss = _context.Transactions
                .Join(_context.PortfolioCoins, t => t.TransactionID, pc => pc.TransactionID, (t, pc) => new { t, pc })
                .Join(portfolioFilters, tpc => tpc.pc.PortfolioID, port => port.PortfolioID, (tpc, port) => new { tpc, port })
                .Where(tpc => tpc.port.UserID == userID)
                .Select(tpcport => new MyTransactionsViewModel
                {
                    TransactionID = tpcport.tpc.t.TransactionID,
                    //PortfolioID = tpcport.port.PortfolioID,
                    PortfolioName = tpcport.tpc.pc.Portfolio.Name,
                    //CoinID = tpcport.tpc.pc.CoinID,
                    Quantity = tpcport.tpc.t.Quantity,
                    DateOfPurchase = tpcport.tpc.t.DateOfPurchase,
                    Buy = tpcport.tpc.t.Buy,
                    CoinName = tpcport.tpc.pc.Coin.Name,                    
                }).ToList();


            var portfolios = _context.Portfolios.Where(x => x.UserID == userID).ToList();

            OposNaNaiViewModel hello = new OposNaNaiViewModel()
            {
                Bla = coinss,
                Portfolios = portfolios,  
                //SelectedPortfolio = selectedPortfolio
            };
            
            return View(hello);
        }        
    }
}