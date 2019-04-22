using CryptoFolio.Models;
using CryptoFolio.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CryptoFolio.Controllers
{
    public class MarketController : Controller
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        public ActionResult ViewMarket()
        {
            var coins = _context.Coins.ToList();
            return View(coins);
        }

        public ActionResult ViewWatchList(WatchListViewModel vm)
        {
            var userID = User.Identity.GetUserId();
            var portUser = _context.Portfolios.Where(x => x.UserID == userID).ToList();
            var portcoin = _context.PortfolioCoins.Where(x => x.PortfolioID == vm.PortfolioID);
            var tr = _context.Transactions.Where(x => x.TransactionID == vm.TransactionID).ToList();
            return View(tr);
        }

        [Authorize]
        [HttpGet]
        public ActionResult CreateWatchCoin()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult CreateWatchCoin(TransactionViewModel vm)
        {
            var userID = User.Identity.GetUserId();

            
            return View();

        }
    }
}