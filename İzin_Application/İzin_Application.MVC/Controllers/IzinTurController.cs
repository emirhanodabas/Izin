using İzin_Application.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace İzin_Application.MVC.Controllers
{

    public class IzinTurController : Controller
    {
        // GET: IzinTur
        IzinContext db = new IzinContext();
        public ActionResult Index()
        {
            List<IzinTur> izinTur = db.IzinTur.Where(x => x.Durumu == true).ToList();
            return View(izinTur);
        }
        public ActionResult Sil(int id)
        {
            IzinTur it = db.IzinTur.Find(id);
            it.Durumu = false;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(IzinTur pit)
        {
            IzinTur it = new IzinTur();
            it.IzinTuru = pit.IzinTuru;
            it.Aciklama = pit.Aciklama;
            it.IzinSure = pit.IzinSure;
            it.Durumu = true;
            db.IzinTur.Add(it);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Guncelle(int id)
        {
            IzinTur it = db.IzinTur.Find(id);
            it.Durumu = true;
            return View(it);
        }

        [HttpPost]
        public ActionResult Guncelle(IzinTur pIzinTur)
        {
            IzinTur it = db.IzinTur.Find(pIzinTur.IzinTurId);
            it.IzinTuru = pIzinTur.IzinTuru;
            it.Aciklama = pIzinTur.Aciklama;
            it.IzinSure = pIzinTur.IzinSure;
            it.Durumu = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}