using İzin_Application.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows;

namespace İzin_Application.MVC.Controllers
{

    public class IzinController : Controller
    {
        // GET: Izin
        IzinContext db = new IzinContext();

        public ActionResult Index()
        {
            List<Izin> izin = db.Izin.Where(x=>x.Durumu==true).ToList();
            return View(izin);
        }
        public ActionResult Sil(int id)
        {
            Izin izin = db.Izin.Find(id);
            izin.Durumu = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            List<SelectListItem> pPer = db.Personel.AsNoTracking().Where(x => x.Durumu == true)
                                                .Select(s => new SelectListItem
                                                {
                                                    Value = s.PersonelId.ToString(),
                                                    Text = s.PersonelAdi + " " + s.PersonelSoyadi,
                                                }).ToList();
            List<SelectListItem> Pit = db.IzinTur.AsNoTracking().Where(x => x.Durumu == true)
                                                .Select(s => new SelectListItem
                                                {
                                                    Value = s.IzinTurId.ToString(),
                                                    Text = s.IzinTuru
                                                }).ToList();
            ViewBag.Personeller = pPer;
            ViewBag.IzinTurleri = Pit;
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(Izin pizin)
        {
            List<Personel> model = new List<Personel>();
            Izin iz = new Izin();
            Personel prs = new Personel();
            if (pizin.IzinBaslangic > pizin.IzinBitis)
            {
                MessageBox.Show("Bitiş Tarihi Başlangıç Tarihinden Önce Olamaz! Lütfen Bilgileri Kontrol Ediniz", "Bilgi");
            }
            else
            {
                int hak = model.Select(p => p.IzinHak).Count();

                iz.Personel = db.Personel.Find(pizin.PersonelID);
                iz.IzinTur = db.IzinTur.Find(pizin.IzinTurId);
                iz.IzinBaslangic = pizin.IzinBaslangic;
                iz.IzinBitis = pizin.IzinBitis;
                iz.Aciklama = pizin.Aciklama;
                iz.tarih = pizin.tarih;
                iz.Durumu = true;

                TimeSpan timeSpan = iz.IzinBitis - iz.IzinBaslangic;
                int izinsuresi = timeSpan.Days;
                prs.IzinHak = prs.IzinHak - izinsuresi;

                db.Izin.Add(iz);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult Guncelle(int id)
        {
            Izin iz = db.Izin.Find(id);
            List<SelectListItem> pPer = db.Personel.AsNoTracking().Where(x => x.Durumu == true)
                                                .Select(s => new SelectListItem
                                                {
                                                    Value = s.PersonelId.ToString(),
                                                    Text = s.PersonelAdi + " " + s.PersonelSoyadi,
                                                }).ToList();
            List<SelectListItem> Pit = db.IzinTur.AsNoTracking().Where(x => x.Durumu == true)
                                                .Select(s => new SelectListItem
                                                {
                                                    Value = s.IzinTurId.ToString(),
                                                    Text = s.IzinTuru
                                                }).ToList();
            ViewBag.Personeller = pPer;
            ViewBag.IzinTurleri = Pit;
            return View();
        }
        [HttpPost]
        public ActionResult Guncelle(Izin piz)
        {
            Izin iz = db.Izin.Find(piz.ID);
            iz.Personel = db.Personel.Find(piz.PersonelID);
            iz.IzinTur = db.IzinTur.Find(piz.IzinTurId);
            iz.IzinBaslangic = piz.IzinBaslangic;
            iz.IzinBitis = piz.IzinBitis;
            iz.Aciklama = piz.Aciklama;
            iz.tarih = piz.tarih;
            iz.Durumu = true;

            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}