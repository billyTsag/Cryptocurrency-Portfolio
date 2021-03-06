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
    public class MarketController : Controller
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        public ActionResult ViewMarket()
        {
            var coins = _context.Coins.ToList();
            return View(coins);
        }

        
    }
}