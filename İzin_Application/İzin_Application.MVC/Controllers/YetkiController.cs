using İzin_Application.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace İzin_Application.MVC.Controllers
{

    public class YetkiController : Controller
    {
        // GET: Yetki
        IzinContext db = new IzinContext();
        public ActionResult Index()
        {
            List<Yetki> yetkiList = db.Yetki.Where(x => x.YetkiDurumu == true).ToList();
            return View(yetkiList);
        }
        public ActionResult Sil(int id)
        {
            Yetki yetki = db.Yetki.Find(id);
            yetki.YetkiDurumu = false;
            db.SaveChanges();
            return RedirectToAction("Index");


        }
        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(Yetki pYetki)
        {
            Yetki ytk = new Yetki();
            ytk.YetkiAdi = pYetki.YetkiAdi;
            ytk.YetkiAciklama = pYetki.YetkiAciklama;
            ytk.YetkiDurumu = true;
            db.Yetki.Add(ytk);
            db.SaveChanges();
            return RedirectToAction("Index");





        }
        [HttpGet]
        public ActionResult Guncelle(int id)
        {
            Yetki yetki = db.Yetki.Find(id);
            return View(yetki);
        }
        [HttpPost]
        public ActionResult Guncelle(Yetki pYetki)
        {
            Yetki ytk = db.Yetki.Find(pYetki.YetkiId);
            ytk.YetkiAdi = pYetki.YetkiAdi;
            ytk.YetkiAciklama = pYetki.YetkiAciklama;
            ytk.YetkiDurumu = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}