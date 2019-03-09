using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SelcukIeeeWebProject.DataAccessLayer;
using SelcukIeeeWebProject.Models;
using SelcukIeeeWebProject.Filter;

namespace SelcukIeeeWebProject.Controllers.Site
{
    public class YonetimController : Controller
    {

        IletisimOperations iletisimOperations = new IletisimOperations();
        DuyurularOperations duyurularOperations = new DuyurularOperations();
        EtkinlikOperations etkinlikOperations = new EtkinlikOperations();
        BlogOperations blogOperations = new BlogOperations();
        YoneticiOperations yoneticiOperations = new YoneticiOperations();

        [AuthFilter]
        public IActionResult Index()
        {
            ViewBag.MesajSayisi = iletisimOperations.GetAll().Count;
            ViewBag.DuyuruSayisi = duyurularOperations.GetAll().Count;
            ViewBag.EtkinlikSayisi = etkinlikOperations.GetAll().Count;
            ViewBag.BlogSayisi = blogOperations.GetAll().Count;

            var loginUsername = HttpContext.Session.GetString("SessionUsername");
            ViewBag.Username = loginUsername;

            return View();
        }

        [AuthFilter]
        public IActionResult Error()
        {
            return View();
        }

        [AuthFilter]
        public IActionResult TeknikDestek()
        {
            return View();
        }

        public IActionResult Giris()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Giris(Yoneticis yonetici)
        {
            var newYonetici = yoneticiOperations.Login(yonetici);
            if (newYonetici != null)
            {
                HttpContext.Session.SetString("SessionUsername", newYonetici.KullaniciAdi);
                return RedirectToAction("Index", "Yonetim");
            }
            return View(yonetici);
        }

        public IActionResult Cikis()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Anasayfa");
        }

    }
}