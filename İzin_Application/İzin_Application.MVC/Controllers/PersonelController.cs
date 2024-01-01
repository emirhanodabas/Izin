using İzin_Application.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace İzin_Application.MVC.Controllers
{

    public class PersonelController : Controller
    {
        // GET: Personel
        IzinContext db = new IzinContext();

        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            Personel prs = new Personel();

            List<Personel> personel = db.Personel.Where(x => x.Durumu == true).ToList();
            return View(personel);
        }

        public ActionResult Sil(int id)
        {
            Personel prs = db.Personel.Find(id);
            prs.Durumu = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Ekle()
        {
            List<SelectListItem> pdep = db.Departman.AsNoTracking().Where(x => x.Durumu == true)
                                                 .Select(s => new SelectListItem
                                                 {
                                                     Value = s.ID.ToString(),
                                                     Text = s.Departman_Adi
                                                 }).ToList();
            List<SelectListItem> pYet = db.Yetki.AsNoTracking().Where(x => x.YetkiDurumu == true)
                                                .Select(s => new SelectListItem
                                                {
                                                    Value = s.YetkiId.ToString(),
                                                    Text = s.YetkiAdi
                                                }).ToList();
            ViewBag.Departmanlar = pdep;
            ViewBag.Yetkiler = pYet;

            return View();
        }
        [HttpPost]
        public ActionResult Ekle(Personel pPersonel)
        {
            Personel prs = new Personel();
            prs.PersonelAdi = pPersonel.PersonelAdi;
            prs.PersonelSoyadi = pPersonel.PersonelSoyadi;
            prs.PersonelEmail = pPersonel.PersonelEmail;
            prs.TC = pPersonel.TC;
            prs.Telefon = pPersonel.Telefon;
            prs.Adres = pPersonel.Adres;
            prs.PersonelKAdi = pPersonel.PersonelKAdi;
            prs.PersonelParola = pPersonel.PersonelParola;
            prs.GirisTarihi = pPersonel.GirisTarihi;
            prs.departman = db.Departman.Find(pPersonel.DepartmanID);
            prs.yetki = db.Yetki.Find(pPersonel.YetkiId);
            prs.Durumu = true;
            prs.IzinHak = CalculateIzinHak(pPersonel.GirisTarihi);
            prs.AnnelikIzinHak = 5;
            prs.CenazeIzinHak = 3;
            prs.DogumIzinHak = 56;
            prs.OlumIzinHak = 3;
            prs.EvlilikIzinHak = 7;
            prs.UcretsizIzinHak = 365;
            db.Personel.Add(prs);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        private int CalculateIzinHak(DateTime girisTarihi)
        {
            // IzinHak'ı hesaplamak için gerekli işlemleri yapın
            // Bu kısmı gerekli iş mantığınıza göre doldurun

            // Örnek olarak:
            if ((DateTime.Now - girisTarihi).Days < 365)
            {
                return 0;
            }
            else if ((DateTime.Now - girisTarihi).TotalDays >= 1 && (DateTime.Now - girisTarihi).TotalDays < 5 * 365)
            {
                return 14;
            }
            else if ((DateTime.Now - girisTarihi).TotalDays >= 5 * 365 && (DateTime.Now - girisTarihi).TotalDays < 10 * 365)
            {
                return 28;
            }
            else
            {
                return 42;
            }
        }
        [HttpGet]
        public ActionResult Guncelle(int id)
        {
            Personel prs = db.Personel.Find(id);
            List<SelectListItem> pdep = db.Departman.AsNoTracking().Where(x => x.Durumu == true)
                                              .Select(s => new SelectListItem
                                              {
                                                  Value = s.ID.ToString(),
                                                  Text = s.Departman_Adi
                                              }).ToList();
            List<SelectListItem> pYet = db.Yetki.AsNoTracking().Where(x => x.YetkiDurumu == true)
                                                .Select(s => new SelectListItem
                                                {
                                                    Value = s.YetkiId.ToString(),
                                                    Text = s.YetkiAdi
                                                }).ToList();
            ViewBag.Departmanlar = pdep;
            ViewBag.Yetkiler = pYet;
            return View(prs);
        }
        [HttpPost]
        public ActionResult Guncelle(Personel pPersonel)
        {
            Personel prs = db.Personel.Find(pPersonel.PersonelId);
            prs.PersonelAdi = pPersonel.PersonelAdi;
            prs.PersonelSoyadi = pPersonel.PersonelSoyadi;
            prs.PersonelEmail = pPersonel.PersonelEmail;
            prs.TC = pPersonel.TC;
            prs.Telefon = pPersonel.Telefon;
            prs.Adres = pPersonel.Adres;
            prs.PersonelKAdi = pPersonel.PersonelKAdi;
            //prs.PersonelParola = pPersonel.PersonelParola;
            prs.GirisTarihi = pPersonel.GirisTarihi;
            prs.departman = db.Departman.Find(pPersonel.DepartmanID);
            prs.yetki = db.Yetki.Find(pPersonel.YetkiId);         
            prs.Durumu = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}