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

    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        public ActionResult Index()
        {
            var coins = _context.Coins.ToList();
            return View(coins);
        }

        [Authorize]
        [HttpGet]
        public ActionResult CreatePortfolio()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult CreatePortfolio(Portfolio portfolio)
        {
            var port = new Portfolio()
            {
                UserID = User.Identity.GetUserId(),
                DateCreated = DateTime.Now,
                Name = portfolio.Name
            };
            _context.Portfolios.Add(port);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        [HttpGet]
        public ActionResult CreateTransaction()
        {
            var ViewModel = new TransactionViewModel
            {
                Coins = _context.Coins.ToList()
            };
            return View(ViewModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult CreateTransaction(TransactionViewModel transactionViewModel)
        {
            var tr = new Transaction()
            {
                Quantity = transactionViewModel.Quantity,
                DateOfPurchase = transactionViewModel.DatePurchased
            };

            _context.Transactions.Add(tr);

            var userId = User.Identity.GetUserId();
            var portId = _context.Portfolios.FirstOrDefault(x => x.UserID == userId);            

            var prtc = new PortfolioCoin()
            {
                TransactionID = tr.TransactionID,
                PortfolioID = portId.PortfolioID,
                CoinID = transactionViewModel.CoinID

            };
            _context.PortfolioCoins.Add(prtc);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        [HttpGet]
        public ActionResult ViewAllPortfolios()
        {
            var portfolios = _context.Portfolios.ToList();
            return View(portfolios);
        }
    }
}