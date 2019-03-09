using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SelcukIeeeWebProject.DataAccessLayer;
using SelcukIeeeWebProject.Models;

namespace SelcukIeeeWebProject.Controllers.Site
{
    public class AnasayfaController : Controller
    {

        DuyurularOperations duyurularOperations = new DuyurularOperations();
        EtkinlikOperations etkinlikOperations = new EtkinlikOperations();
        EtkinlikFotografOperations etkinlikFotografOperations = new EtkinlikFotografOperations();
        BlogOperations blogOperations = new BlogOperations();

        /* Anasayfa Acilis Sayfasi */
        public IActionResult Index()
        {
            return View();
        }

        /* Anasayfa Duyurular Sayfasi */
        public IActionResult Duyurular()
        {
            return View(duyurularOperations.GetAll().OrderByDescending(x => x.Id));
        }

        /* Duyuru Detay Sayfasi */
        public IActionResult DuyuruDetay(int id)
        {
            var item = duyurularOperations.GetById(id);
            if (item == null)
            {
                return RedirectToAction("Hata");
            }
            return View(item);
        }

        /* Anasayfa Duyurular Sayfasi */
        public IActionResult Etkinlikler()
        {
            return View(etkinlikOperations.GetAll().OrderByDescending(x => x.Id));
        }

        /* Anasayfa Blog Sayfasi */
        public IActionResult Blog()
        {
            return View(blogOperations.GetAll().OrderByDescending(x => x.Id));
        }

        /* Blog Detay Sayfasi */
        public IActionResult BlogDetay(int id)
        {
            var item = blogOperations.GetById(id);
            if (item == null)
            {
                return RedirectToAction("Hata");
            }
            return View(item);
        }

        /* Anasayfa Iletisim Sayfasi */
        public IActionResult Iletisim()
        {
            return View();
        }

        /* Hata Durumunda Cikan Sayfa */
        public IActionResult Hata()
        {
            return View();
        }

    }
}