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
        public ActionResult ViewAllPortfolios()
        {
            var portfolios = _context.Portfolios.ToList();
            return View(portfolios);
        }

        [Authorize]
        [HttpGet]
        public ActionResult ViewMyPortfolios()
        {
            var userId = User.Identity.GetUserId();
            var Ports = _context.Portfolios.Where(x => x.UserID == userId).ToList();
            return View(Ports);
        }

        [Authorize]
        [HttpGet]
        public ActionResult ViewMyPortfolio(int portfolioId)       //apo dropdown list na emfanizei ta portfolio tou owner kai na dialegei poio thelei na dei
        {
            var userId = User.Identity.GetUserId();
            var MyPort = _context.Portfolios.Where(x => x.UserID == userId && x.PortfolioID == portfolioId);
            return View(MyPort);
        }
    }
}