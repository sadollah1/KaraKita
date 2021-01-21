using KaraKita.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VeriErisimKatmani;

namespace KaraKita.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext _db;
        public HomeController()
        {
            _db = new DataContext();
      
        }
        public ActionResult Index()
        {
            AnasayfaModel model = new AnasayfaModel();
            model.Projeler = _db.Projeler.ToList();
            model.Resimler = _db.Resimler.Take(6).ToList();
            return View(model);
        }
        public ActionResult IletisimPartial() {
            var iletisim = _db.Bilgiler.FirstOrDefault();
            return PartialView("IletisimPartial",iletisim);
        }
        public ActionResult Iletisim()
        {
            var bilgiler = _db.Bilgiler.FirstOrDefault();
            return View(bilgiler);
        }

        public ActionResult Projelerimiz()
        {
            var projeler = _db.Projeler.ToList();
            return View(projeler);
        }
        public ActionResult ProjeDetayı(string projeId)
        {
            if (string.IsNullOrEmpty(projeId))
            {
                return View(new Proje());
            }
            var proje = _db.Projeler.Find(projeId);
            if (proje == null)
            {
                return View(new Proje());
            }
            ProjeDetayModel model = new ProjeDetayModel();
            model.Proje = proje;
            model.Projeler = _db.Projeler.Take(5).ToList();
            return View(model);
        }
        public ActionResult Kurumsal()
        {
            return View();
        }
        public ActionResult Referanslar()
        {
            return View();
        }
        public ActionResult Etkinlikler()
        {
            return View();
        }
        public ActionResult Galeri()
        {
            var projeler = _db.Projeler.ToList();
            return View(projeler);
        }
        [HttpPost]
        public ActionResult MesajEkle(string ad, string email, string telefon, string konu, string mesaj)
        {
            Mesaj msj = new Mesaj { AdSoyad = ad, Email = email, Icerik = mesaj, Konu = konu, OlusturmaZamani = DateTime.Now, Telefon = telefon };
            _db.Mesajlar.Add(msj);
            int sonuc = _db.SaveChanges();
            if (sonuc > 0)
            {
                return Json(true);

            }
            else
            {
                return Json(false);

            }

        }
    }
}