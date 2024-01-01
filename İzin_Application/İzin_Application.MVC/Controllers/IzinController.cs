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
        [Authorize]
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
            if (ModelState.IsValid)
            {
                try
                {
                    // Personel bilgisini veritabanından çek
                    Personel personel = db.Personel.Find(pizin.PersonelID);

                    if (personel != null)
                    {
                       
                            // Diğer izin ekleme işlemleri buraya eklenir...

                            // İzin haklarını güncelle
                            TimeSpan timeSpan = pizin.IzinBitis - pizin.IzinBaslangic;
                            int izinsuresi = timeSpan.Days;
                            personel.IzinHak -= izinsuresi;
                        
                        
                        // İzin nesnesini oluşturup kaydet
                        Izin iz = new Izin
                        {
                            Personel = personel,
                            IzinTur = db.IzinTur.Find(pizin.IzinTurId),
                            IzinBaslangic = pizin.IzinBaslangic,
                            IzinBitis = pizin.IzinBitis,
                            Aciklama = pizin.Aciklama,
                            tarih = pizin.tarih,
                            Durumu = true
                        };

                        db.Izin.Add(iz);
                        db.SaveChanges();

                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Personel bulunamadı");
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "İzin ekleme sırasında bir hata oluştu: " + ex.Message);
                }
            }

            // Model geçerli değilse, tekrar ekleme sayfasını göster
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

            return View(pizin);

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