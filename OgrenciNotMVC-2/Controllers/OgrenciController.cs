using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrenciNotMVC_2.Models.EntityFramework;

namespace OgrenciNotMVC_2.Controllers
{
    public class OgrenciController : Controller
    {

        DB_MVC_OKULEntities db = new DB_MVC_OKULEntities();

        // GET: Ogrenci
        public ActionResult Index()
        {
            var ogrenciler = db.TBLOGRENCILER.ToList();
            return View(ogrenciler);
        }

        [HttpGet]
        public ActionResult YeniOgrenci()
        {
            List<SelectListItem> degerler = (from i in db.TBLKULUPLER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KULUPAD,
                                                 Value = i.KULUPID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;

            return View();
        }


        [HttpPost]
        public ActionResult YeniOgrenci(TBLOGRENCILER p3)
        {
            var klp = db.TBLKULUPLER.Where(
                                            m => m.KULUPID == p3.TBLKULUPLER.KULUPID
                                          ).FirstOrDefault();
            p3.TBLKULUPLER = klp;
            db.TBLOGRENCILER.Add(p3);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id)
        {
            var ogrenci = db.TBLOGRENCILER.Find(id);
            db.TBLOGRENCILER.Remove(ogrenci);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult OgrenciGetir(int id)
        {
            var ogrenciGetir = db.TBLOGRENCILER.Find(id);

            List<SelectListItem> degerler = (from i in db.TBLKULUPLER.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KULUPAD,
                                                 Value = i.KULUPID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;

            return View("OgrenciGetir", ogrenciGetir);
        }

        [HttpPost]
        public ActionResult Guncelle(TBLOGRENCILER p7)
        {
            var ogrenciGuncelle = db.TBLOGRENCILER.Find(p7.OGRENCIID);
            ogrenciGuncelle.OGRAD = p7.OGRAD;
            ogrenciGuncelle.OGRSOYAD = p7.OGRSOYAD;
            ogrenciGuncelle.OGRFOTOGRAF = p7.OGRFOTOGRAF;
            ogrenciGuncelle.OGRCINSIYET = p7.OGRCINSIYET;

            var klp = db.TBLKULUPLER.Where(
                                            m => m.KULUPID == p7.TBLKULUPLER.KULUPID
                                          ).FirstOrDefault();
            p7.TBLKULUPLER = klp;

            ogrenciGuncelle.OGRKULUP = p7.TBLKULUPLER.KULUPID;
            db.SaveChanges();
            return RedirectToAction("Index", "Ogrenci");
        }

    }
}