using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SelcukIeeeWebProject.DataAccessLayer;
using SelcukIeeeWebProject.Models;

namespace SelcukIeeeWebProject.Controllers.Site
{
    public class YonetimController : Controller
    {

        IletisimOperations iletisimOperations = new IletisimOperations();
        DuyurularOperations duyurularOperations = new DuyurularOperations();
        EtkinlikOperations etkinlikOperations = new EtkinlikOperations();
        BlogOperations blogOperations = new BlogOperations();
        YoneticiOperations yoneticiOperations = new YoneticiOperations();

        public IActionResult Index()
        {
            ViewBag.MesajSayisi = iletisimOperations.GetAll().Count;
            ViewBag.DuyuruSayisi = duyurularOperations.GetAll().Count;
            ViewBag.EtkinlikSayisi = etkinlikOperations.GetAll().Count;
            ViewBag.BlogSayisi = blogOperations.GetAll().Count;
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

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
                // Buraya Session Olusturma Islemi Eklenecek.
                return RedirectToAction("Index", "Yonetim");
            }
            return View(yonetici);
        }

        public IActionResult Cikis()
        {
            // Session Temizleme Islemi Burada Yapilacak.
            return RedirectToAction("Index", "Anasayfa");
        }

    }
}