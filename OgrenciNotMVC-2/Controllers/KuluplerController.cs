using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMVC_2.Models.EntityFramework;

namespace OgrenciNotMVC_2.Controllers
{
    public class KuluplerController : Controller
    {

        DB_MVC_OKULEntities db = new DB_MVC_OKULEntities();

        // GET: Kulupler
        public ActionResult Index()
        {
            var kulupler = db.TBLKULUPLER.ToList();
            return View(kulupler);
        }

        [HttpGet]
        public ActionResult YeniKulup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniKulup(TBLKULUPLER p2)
        {
            db.TBLKULUPLER.Add(p2);
            db.SaveChanges();

            return RedirectToAction("Index", "Kulupler");
        }

        public ActionResult Sil(int id)
        {
            var kulup = db.TBLKULUPLER.Find(id);
            db.TBLKULUPLER.Remove(kulup);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult KulupGetir(int id)
        {
            var getirilecekKulup = db.TBLKULUPLER.Find(id);

            return View("KulupGetir", getirilecekKulup);
        }

        public ActionResult Guncelle(TBLKULUPLER p5)
        {
            var kulupGuncelle = db.TBLKULUPLER.Find(p5.KULUPID);
            kulupGuncelle.KULUPAD = p5.KULUPAD;
            db.SaveChanges();
            return RedirectToAction("Index", "Kulupler");
        }
    }
}