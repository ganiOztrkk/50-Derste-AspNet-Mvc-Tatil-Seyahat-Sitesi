using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Entities;

namespace TravelTripProje.Controllers
{
    public class BlogController : Controller
    {
        private readonly Context _context = new Context();
        public ActionResult Index()
        {
            var bloglar = _context.Blogs.ToList();
            return View(bloglar);
        }

        public ActionResult BlogDetay(int id)
        {
            return View();
        }
    }
}