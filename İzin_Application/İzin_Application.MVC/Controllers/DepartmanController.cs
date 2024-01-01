using İzin_Application.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace İzin_Application.MVC.Controllers
{
    
    public class DepartmanController : Controller
    {
        
        // GET: Departman
        IzinContext db = new IzinContext();
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            List<Departman> departman = db.Departman.Where(x => x.Durumu == true).ToList();
            return View(departman);
        }
        public ActionResult Sil(int id)
        {
            Departman dp = db.Departman.Find(id);
            dp.Durumu = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize(Roles ="Admin")]
        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Ekle(Departman pDepartman)
        {
            Departman dp = new Departman();
            dp.Departman_Adi = pDepartman.Departman_Adi;
            dp.Aciklama = pDepartman.Aciklama;
            dp.Durumu = true;
            db.Departman.Add(dp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Guncelle(int id)
        {
            Departman pDepartman = db.Departman.Find(id);
            return View(pDepartman);
        }
        [HttpPost]
        public ActionResult Guncelle(Departman pdepartman)
        {
            Departman dp = db.Departman.Find(pdepartman.ID);
            dp.Departman_Adi = pdepartman.Departman_Adi;
            dp.Aciklama = pdepartman.Aciklama;
            dp.Durumu = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}