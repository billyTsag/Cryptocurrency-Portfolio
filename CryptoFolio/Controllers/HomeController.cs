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
            var userId = User.Identity.GetUserId();

            if (_context.Portfolios.Where(x => x.UserID == userId).Count() < 1)
            {
                var port = new Portfolio()
                {
                    UserID = User.Identity.GetUserId(),
                    DateCreated = DateTime.Now,
                    Name = "My Free Portfolio"
                };
                _context.Portfolios.Add(port);
                _context.SaveChanges();
            }
            var myPortfolios = _context.Portfolios.Where(x => x.UserID == userId).ToList();
            return View(myPortfolios);
        }

        public ActionResult HomePage()
        {
            return View();
        }
    }

    
}