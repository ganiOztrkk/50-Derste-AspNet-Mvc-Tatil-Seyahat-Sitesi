using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Entities;

namespace TravelTripProje.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        readonly Context _context = new Context();
        public ActionResult Index()
        {
            var values = _context.Blogs.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult BlogEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult BlogEkle(Blog blog)
        {
            _context.Blogs.Add(blog);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BlogSil(int id)
        {
            var blog = _context.Blogs.Find(id);
            if (blog != null)
            {
                _context.Blogs.Remove(blog);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public ActionResult BlogGuncelle(int id)
        {
            var blog = _context.Blogs.Find(id);
            return View("BlogGuncelle",blog);
        }
        [HttpPost]
        public ActionResult BlogGuncelle(Blog blog)
        {
            var blg = _context.Blogs.Find(blog.ID);
            blg.Baslik = blog.Baslik;
            blg.BlogImage = blog.BlogImage;
            blg.Tarih = blog.Tarih;
            blg.Aciklama = blog.Aciklama;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult YorumListesi()
        {
            var yorumlar = _context.Yorumlars.ToList();
            return View(yorumlar);
        }

        public ActionResult YorumSil(int id)
        {
            var yorum = _context.Yorumlars.Find(id);
            _context.Yorumlars.Remove(yorum);
            _context.SaveChanges();
            return RedirectToAction("YorumListesi","Admin");
        }

        [HttpGet]
        public ActionResult YorumGuncelle(int id)
        {
            var yorum = _context.Yorumlars.Find(id);
            return View("YorumGuncelle",yorum);
        }
        [HttpPost]
        public ActionResult YorumGuncelle(Yorumlar yorumlar)
        {
            var yorum = _context.Yorumlars.Find(yorumlar.ID);
            yorum.KullaniciAdi = yorumlar.KullaniciAdi;
            yorum.Mail = yorumlar.Mail;
            yorum.Yorum = yorumlar.Yorum;
            _context.SaveChanges();
            return RedirectToAction("YorumListesi", "Admin");
        }
    }
}