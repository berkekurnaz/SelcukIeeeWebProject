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
    public class YonetimYoneticilerController : Controller
    {

        YoneticiOperations yoneticiOperations = new YoneticiOperations();

        public IActionResult Index()
        {
            return View(yoneticiOperations.GetAll());
        }

        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Ekle(Yoneticis yonetici)
        {
            if (ModelState.IsValid)
            {
                yoneticiOperations.Add(yonetici);
                return RedirectToAction("Index");
            }
            return View(yonetici);
        }

        public IActionResult Guncelle(int id)
        {
            var item = yoneticiOperations.GetById(id);
            if (item == null)
            {
                return RedirectToAction("Index");
            }
            return View(item);
        }

        [HttpPost]
        public IActionResult Guncelle(int id, Yoneticis newYonetici)
        {
            var yonetici = yoneticiOperations.GetById(id);

            yonetici.KullaniciAdi = newYonetici.KullaniciAdi;
            yonetici.Sifre = newYonetici.Sifre;
            yoneticiOperations.Update(yonetici);

            return RedirectToAction("Index");
        }

        public IActionResult Sil(int id)
        {
            var item = yoneticiOperations.GetById(id);
            if (item == null)
            {
                return RedirectToAction("Index");
            }
            return View(item);
        }

        [HttpPost]
        public IActionResult Sil(int id, IFormCollection collection)
        {
            yoneticiOperations.Delete(id);
            return RedirectToAction("Index");
        }


    }
}