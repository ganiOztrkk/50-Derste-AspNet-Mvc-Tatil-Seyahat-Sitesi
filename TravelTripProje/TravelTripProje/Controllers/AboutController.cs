using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Entities;

namespace TravelTripProje.Controllers
{
    public class AboutController : Controller
    {
        private readonly Context _context = new Context();
        public ActionResult Index()
        {
            var values = _context.Hakkimizdas.ToList();

            return View(values);
        }
    }
} 