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
        private readonly BlogYorum _blogYorum = new BlogYorum();
        private readonly Context _context = new Context();
        public ActionResult Index()
        {
            _blogYorum.Deger1 = _context.Blogs.ToList();
            _blogYorum.Deger3 = _context.Blogs.OrderByDescending(x=>x.ID).Take(3).ToList();
            return View(_blogYorum);
        }

        public ActionResult BlogDetay(int id)
        {
            _blogYorum.Deger1 = _context.Blogs.Where(x => x.ID == id).ToList();
            _blogYorum.Deger2 = _context.Yorumlars.Where(x => x.BlogID == id).ToList();
            return View(_blogYorum);
        }

        [HttpGet]
        public PartialViewResult YorumYap(int id)
        {
            ViewBag.deger = id;
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult YorumYap(Yorumlar yorumlar)
        {
            _context.Yorumlars.Add(yorumlar);
            _context.SaveChanges();
            return PartialView();
        }
    }
}