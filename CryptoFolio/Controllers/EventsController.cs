using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CryptoFolio.Controllers
{
    public class EventsController : Controller
    {
        // GET: Events
        public ActionResult GetEvents()
        {
            return View();
        }
    }
}