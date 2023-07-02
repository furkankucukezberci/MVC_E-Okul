using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMVC_2.Models.EntityFramework;
using OgrenciNotMVC_2.Models;

namespace OgrenciNotMVC_2.Controllers
{
    public class NotlarController : Controller
    {

        DB_MVC_OKULEntities db = new DB_MVC_OKULEntities();
        // GET: Notlar
        public ActionResult Index()
        {
            var notlar = db.TBLNOTLAR.ToList();
            return View(notlar);
        }

        [HttpGet]
        public ActionResult YeniSinav()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniSinav(TBLNOTLAR p4)
        {
            db.TBLNOTLAR.Add(p4);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult NotGetir(int id)
        {
            var notGetir = db.TBLNOTLAR.Find(id);
            return View("NotGetir", notGetir);
        }

        [HttpPost]
        public ActionResult NotGetir(Class1 model, TBLNOTLAR p8, int SINAV1 = 0, int SINAV2 = 0, int SINAV3 = 0, int PROJE = 0)
        {
            if (model.islem == "HESAPLA")
            {
                int ORTALAMA = (SINAV1 + SINAV2 + SINAV3 + PROJE) / 4;
                ViewBag.ort = ORTALAMA;
            }
            if (model.islem == "NOTGUNCELLE")
            {
                var notGuncelle = db.TBLNOTLAR.Find(p8.NOTID);
                notGuncelle.SINAV1 = p8.SINAV1;
                notGuncelle.SINAV2 = p8.SINAV2;
                notGuncelle.SINAV3 = p8.SINAV3;
                notGuncelle.PROJE = p8.PROJE;
                notGuncelle.ORTALAMA = p8.ORTALAMA;
                db.SaveChanges();
                return RedirectToAction("Index", "Notlar");
            }
            return View();
        }
    }
}