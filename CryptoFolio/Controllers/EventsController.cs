using CryptoFolio.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CryptoFolio.Controllers
{
    public class EventsController : Controller
    {
        ApplicationDbContext _context = new ApplicationDbContext();
        

        
       
        // GET: Events
        public ActionResult GetEvents()
        {
            return View();
        }

        
        public ActionResult ChangeRole(string usernameID, FormCollection formValues)
        {
            var _userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(_context));
            usernameID = User.Identity.GetUserId();
            if (User.IsInRole("Freemium"))
            {
                _userManager.RemoveFromRole(usernameID, "Freemium");
                _userManager.AddToRole(usernameID, "Premium");
                _context.SaveChanges();
            }
            return RedirectToAction("Index", "Home");
        }

    }
}