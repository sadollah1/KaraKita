using KaraKita.Components;
using KaraKita.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VeriErisimKatmani;

namespace KaraKita.Controllers
{
    public class AdminController : Controller
    {
        private readonly DataContext _db;
        public AdminController()
        {
            _db = new DataContext();
        }
        [CustomAuth]
        public ActionResult Projeler() {
            var projeler = _db.Projeler.ToList();
            return View(projeler);
        }
        [CustomAuth]
        public ActionResult ProjeDetay(string projeId) {
            if (string.IsNullOrEmpty(projeId))
            {
                return View(new Proje());
            }
            var proje = _db.Projeler.Find(projeId);
            if (proje == null)
            {
                return View(new Proje());
            }
            return View(proje);
        }
        [CustomAuth]
        public ActionResult ProjeSil(string projeId)
        {
            if (!string.IsNullOrEmpty(projeId))
            {
             var proje=   _db.Projeler.Find(projeId);
                if (proje != null) {
                    _db.Projeler.Remove(proje);
                    var yuklemeYeri = Path.Combine(Server.MapPath("~/images/proje"), proje.ResimYolu);
                    if (System.IO.File.Exists(yuklemeYeri)) {
                        System.IO.File.Delete(yuklemeYeri);
                    }
                    _db.SaveChanges();
                }
            }
          
            return RedirectToAction("Projeler", "Admin");
        }
        [CustomAuth]
        [HttpPost]
        public ActionResult ProjeDetay(Proje proje,HttpPostedFileBase Resim)
        {
            if (!Resim.ContentType.ToLower().Contains("image")) {
                return View(proje);
            }
            if (string.IsNullOrEmpty(proje.Id))
            {
                proje.Id = "prj-" + Guid.NewGuid().ToString().Substring(0, 4);
                string uzantı = Path.GetExtension(Resim.FileName);
                var yuklemeYeri = Path.Combine(Server.MapPath("~/images/proje"), proje.Id + uzantı);
                proje.ResimYolu = "proje/" + proje.Id + uzantı;
                proje.EklemeZamanı = DateTime.Now;
                Resim.SaveAs(yuklemeYeri);
                _db.Projeler.Add(proje);
                _db.SaveChanges();
            }
            else {
                if (Resim != null) {
                    string uzantı = Path.GetExtension(Resim.FileName);
                    var yuklemeYeri = Path.Combine(Server.MapPath("~/images/proje"), proje.Id + uzantı);
                    if (System.IO.File.Exists(yuklemeYeri))
                    {
                        System.IO.File.Delete(yuklemeYeri);
                    }
                    Resim.SaveAs(yuklemeYeri);
                    proje.ResimYolu = "proje/" + proje.Id + uzantı;
                    _db.Entry(proje).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();

                }

            }
            
            return View(proje);
        }
        public ActionResult Login()
        {
            if (HttpContext.Session["IsAdminLogin"] !=null) {
                if (HttpContext.Session["IsAdminLogin"].ToString() == "true") {
                    return RedirectToAction("Projeler", "Admin");
                }
            }
            return View();
        }
        [HttpPost]
        public ActionResult Login(string email, string sifre)
        {
            var user = _db.Yoneticiler.Where(x => x.Email == email && x.Sifre == sifre).FirstOrDefault();
            if (user != null)
            {
                HttpContext.Session.Add("IsAdminLogin", "true");
                HttpContext.Session.Add("Username", user.Ad);
                return RedirectToAction("Projeler", "Admin");

            }
            else
            {
                ViewBag.Message = "Hatalı şifre yada kullanıcı adı";
                return View();
            }

        }
        [CustomAuth]
        public ActionResult Mesajlar() {
            var mesajlar = _db.Mesajlar.ToList();
            return View(mesajlar);
        }
        [CustomAuth]
        public ActionResult MesajSil(int mesajId)
        {
            var mesaj = _db.Mesajlar.Find(mesajId);
            if (mesaj != null) {
                _db.Mesajlar.Remove(mesaj);
                _db.SaveChanges();
            }
            return RedirectToAction("Mesajlar", "Admin");
        }
        public ActionResult Cikis()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
        [CustomAuth]
        public ActionResult YoneticiBilgileri() {
            var yonetici = _db.Yoneticiler.Select(x => new YoneticiModel { Ad = x.Ad, Email = x.Email, Sifre = x.Sifre, SifreTekrar = x.Sifre }).FirstOrDefault(); ;
            return View(yonetici);
        }
        [HttpPost]
        [CustomAuth]
        public ActionResult YoneticiBilgileri(YoneticiModel model)
        {
            if (ModelState.IsValid) {
                var yonetici = _db.Yoneticiler.FirstOrDefault();
                yonetici.Ad = model.Ad;
                yonetici.Email = model.Email;
                yonetici.Sifre = model.Sifre;
                HttpContext.Session["Username"] = model.Ad;
                _db.SaveChanges();
            }
            return View(model);
        }
       
        [CustomAuth]
        public ActionResult IletisimBilgileri()
        {
            var bilgiler = _db.Bilgiler.FirstOrDefault();
            return View(bilgiler);
        }
        [HttpPost]
        [CustomAuth]
        public ActionResult IletisimBilgileri(IletisimBilgileri bilgiler)
        {
            _db.Entry(bilgiler).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();
            return View(bilgiler);
        }
    }
}