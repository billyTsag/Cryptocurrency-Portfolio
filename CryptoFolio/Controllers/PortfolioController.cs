﻿using CryptoFolio.Models;
using CryptoFolio.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CryptoFolio.Controllers
{
    public class PortfolioController : Controller
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

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
            bool result = User.IsInRole("Premium");
            if (result)
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

            }return View("BecomePremium", "AccountUser");
        }

        [Authorize]
        [HttpGet]
        public ActionResult ViewMyPortfolios(string sortOrder)
        {
            
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            var userId = User.Identity.GetUserId();
            var Ports = _context.Portfolios.Where(x => x.UserID == userId);

            switch (sortOrder)
            {
                case "name_desc":
                    Ports = Ports.OrderByDescending(x => x.Name);
                    break;
                case "Date":
                    Ports = Ports.OrderBy(x => x.DateCreated);
                    break;
                case "date_desc":
                    Ports = Ports.OrderByDescending(x => x.DateCreated);
                    break;
                default:
                    Ports = Ports.OrderBy(x => x.Name);
                    break;
            }
            return View(Ports.ToList());
        }

        [Authorize]
        [HttpGet]
        public ActionResult EditMyPortfolio(int PortfolioID)
        {
            var Portfolio = _context.Portfolios.Find(PortfolioID);
            return View(Portfolio);
        }

        [Authorize]
        [HttpPost]
        public ActionResult EditMyPortfolio(Portfolio portfolio)
        {
            
            var myPortfolio = _context.Portfolios.Find(portfolio.PortfolioID);
            myPortfolio.Name = portfolio.Name;
            _context.SaveChanges();

            return RedirectToAction("ViewMyPortfolios", "Portfolio");
        }
        [Authorize]
        [HttpGet]
        public ActionResult DeleteMyPortfolio(int PortfolioID)
        {
            var myPortfolio = _context.Portfolios.Find(PortfolioID);
            return View(myPortfolio);
        }

        [Authorize]
        [HttpPost]
        public ActionResult DeleteMyPortfolio(Portfolio portfolio)
        {
            var myPortfolio = _context.Portfolios.Find(portfolio.PortfolioID);
            _context.Portfolios.Remove(myPortfolio);
            _context.SaveChanges();
            return RedirectToAction("ViewMyPortfolios", "Portfolio");
        }

        [Authorize]
        [HttpGet]
        public ActionResult ViewMyPortfolio(int PortfolioID)
        {

            var userID = User.Identity.GetUserId();

            var coinss = _context.Transactions
                .Join(_context.PortfolioCoins, t => t.TransactionID, pc => pc.TransactionID, (t, pc) => new { t, pc })
                .Join(_context.Portfolios, tpc => tpc.pc.PortfolioID, port => port.PortfolioID, (tpc, port) => new { tpc, port })
                .Join(_context.Coins, pc => pc.tpc.pc.CoinID, c => c.CoinID, (pc, c) => new { pc, c })
                .Where(tpc => tpc.pc.port.UserID == userID && tpc.pc.port.PortfolioID == PortfolioID)

                .Select(tpcport => new MyTransactionsViewModel
                {
                    CoinID = tpcport.pc.tpc.pc.CoinID,
                    Quantity = tpcport.pc.tpc.t.Quantity,
                    CoinName = tpcport.pc.tpc.pc.Coin.Name,
                    TransactionID = tpcport.pc.tpc.t.TransactionID,
                    Buy = tpcport.pc.tpc.t.Buy
                }).ToList();

            var result = coinss.GroupBy(x => x.CoinID).Select(i => new MyTransactionsViewModel
            {
                CoinID = i.Key,
                Quantity = i.Sum(j => j.Quantity),
                CoinName = i.First().CoinName,
                CoinPrice = i.First().CoinPrice
            });

            return View(result);
        }

    }

}