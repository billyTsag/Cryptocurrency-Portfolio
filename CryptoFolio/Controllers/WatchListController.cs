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
    public class WatchListController : Controller
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        [Authorize]
        [HttpGet]
        public ActionResult AddToWatchList(int id)
        {
            
            var userID = User.Identity.GetUserId();

            var UserCoin = new UserCoin
            {
                UserID = userID,
                CoinID = id
               
            };

            _context.UserCoins.Add(UserCoin);
            _context.SaveChanges();

            return RedirectToAction("ViewMarket","Market");
        }

        [Authorize]
        [HttpGet]
        public ActionResult RemoveFromWatchList(int id)
        {

            var userID = User.Identity.GetUserId();

            var UserCoin = new UserCoin
            {
                UserID = userID,
                CoinID = id
            };

            _context.UserCoins.Remove(UserCoin);
            _context.SaveChanges();

            return View();
        }

        [Authorize]
        [HttpGet]
        public ActionResult ViewWatchList()
        {
            var userID = User.Identity.GetUserId();
            var watch = _context.UserCoins.Where(x => x.UserID == userID).ToList();
            var coinss = _context.Coins
                .Join(_context.UserCoins, c => c.CoinID, uc => uc.CoinID, (c, uc) => new { c, uc })
                .Where(cuc => cuc.uc.UserID == userID)
                .Select(cuc => new WatchListViewModel
                {
                    Name = cuc.c.Name,
                    Symbol = cuc.c.Symbol,
                    Supply = cuc.c.Supply,
                    Price = cuc.c.Price
                }).ToList();
                

           

            return View(coinss);
        }

        
        
    }
}
