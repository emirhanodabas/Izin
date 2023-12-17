using İzin_Application.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace İzin_Application.MVC.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GirisYap(Personel pPersonel)
        {
            pPersonel.PersonelKAdi = pPersonel.PersonelEmail;
            using (IzinContext db = new IzinContext())

            {
                Personel personel = db.Personel.AsNoTracking().Where(x => (x.PersonelEmail == pPersonel.PersonelEmail ||
                                                        x.PersonelKAdi == pPersonel.PersonelKAdi) &&
                                                        x.PersonelParola == pPersonel.PersonelParola).FirstOrDefault();

                if (personel != null)
                {
                    FormsAuthentication.SetAuthCookie(personel.PersonelKAdi, false);
                    Session["PersonelId"] = personel.PersonelId;
                    Session["Personeli"] = personel.PersonelAdi + " " + personel.PersonelSoyadi;
                    Session["PersonelKadi"] = personel.PersonelKAdi;
                    Session["PersonelEmail"] = personel.PersonelEmail;
                    Session["YetkiId"] = personel.YetkiId;
                    return RedirectToAction("Index", "Izin");
                }
            }


            return RedirectToAction("Index");
        }
        public ActionResult Cikis()
        {
            Session.Clear();

            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}