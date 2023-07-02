using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMVC_2.Models.EntityFramework;

namespace OgrenciNotMVC_2.Controllers
{
    public class HomeController : Controller
    {

        DB_MVC_OKULEntities db = new DB_MVC_OKULEntities();

        public ActionResult Index()
        {
            var dersler = db.TBLDERSLER.ToList();
            return View(dersler);
        }

        [HttpGet]
        public ActionResult YeniDers()
        {
            return View();
        }

        //ViewBag.Message = "Your application description page.";
        [HttpPost]
        public ActionResult YeniDers(TBLDERSLER p)
        {

            db.TBLDERSLER.Add(p);
            db.SaveChanges();

            return View();
        }

        public ActionResult Sil(int id)
        {
            var ders = db.TBLDERSLER.Find(id);
            db.TBLDERSLER.Remove(ders);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DersGetir(int id)
        {
            var dersGetir = db.TBLDERSLER.Find(id);
            return View("DersGetir", dersGetir);
        }

        public ActionResult Guncelle(TBLDERSLER p6)
        {
            var dersGuncelle = db.TBLDERSLER.Find(p6.DERSID);
            dersGuncelle.DERSAD = p6.DERSAD;
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}