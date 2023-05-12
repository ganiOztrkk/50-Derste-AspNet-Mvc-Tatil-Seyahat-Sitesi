using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Entities;

namespace TravelTripProje.Controllers
{
    public class DefaultController : Controller
    {
        private readonly Context _context = new Context();
        public ActionResult Index()
        {
            var values = _context.Blogs.ToList();
            return View(values);
        }
        public PartialViewResult Partial1()
        {
            var values = _context.Blogs.OrderByDescending(x => x.ID).Take(2).ToList();
            return PartialView(values);
        }

            
        public PartialViewResult Partial2()
        {
            var values = _context.Blogs.Where(x=>x.ID == 1).ToList();
            return PartialView(values);
        }

        public PartialViewResult Partial3()
        {
            var values = _context.Blogs.Take(10).ToList();
            return PartialView(values);
        }

        public PartialViewResult Partial4()
        {
            var values = _context.Blogs.Take(3).ToList();
            return PartialView(values);
        }

        public PartialViewResult Partial5()
        {
            var values = _context.Blogs.OrderByDescending(x => x.ID).Take(3).ToList();
            return PartialView(values);
        }
    }
}