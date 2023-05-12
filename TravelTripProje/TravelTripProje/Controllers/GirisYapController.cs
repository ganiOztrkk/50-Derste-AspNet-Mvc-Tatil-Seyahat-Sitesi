using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TravelTripProje.Models.Entities;

namespace TravelTripProje.Controllers
{
    public class GirisYapController : Controller
    {
        private readonly Context _context = new Context();
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Admin admin)
        {
            var adminler =
                _context.Admins.FirstOrDefault(x => x.Kullanici == admin.Kullanici && x.Sifre == admin.Sifre);
            if (adminler != null)
            {
                FormsAuthentication.SetAuthCookie(adminler.Kullanici,false);
                Session["Kullanici"] = adminler.Kullanici.ToString();
                return RedirectToAction("Index", "Admin");
            }
            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "GirisYap");
        }
    }
}