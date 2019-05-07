using CryptoFolio.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CryptoFolio.Controllers
{
    public class AccountUserController : Controller
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        
        public ActionResult BecomePremium(string usernameID, FormCollection formValues)
        {
                
            return RedirectToAction("ChangeRole","Events");
        }
    }
}