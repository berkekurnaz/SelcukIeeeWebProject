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
    public class YonetimDuyurularController : Controller
    {

        DuyurularOperations duyurularOperations = new DuyurularOperations();

        public IActionResult Index()
        {
            return View(duyurularOperations.GetAll());
        }

        public IActionResult Incele(int id)
        {
            var item = duyurularOperations.GetById(id);
            if (item == null)
            {
                return RedirectToAction("Index");
            }
            return View(item);
        }

        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Ekle(Duyurulars duyuru)
        {
            if (ModelState.IsValid)
            {
                duyurularOperations.Add(duyuru);
                return RedirectToAction("Index");
            }
            return View(duyuru);
        }

        public IActionResult Guncelle(int id)
        {
            var item = duyurularOperations.GetById(id);
            if (item == null)
            {
                return RedirectToAction("Index");
            }
            return View(item);
        }

        [HttpPost]
        public IActionResult Guncelle(int id, Duyurulars newDuyuru)
        {
            var duyuru = duyurularOperations.GetById(id);

            duyuru.Baslik = newDuyuru.Baslik;
            duyuru.Tarih = newDuyuru.Tarih;
            duyuru.Gonderici = newDuyuru.Gonderici;
            duyuru.Icerik = newDuyuru.Icerik;
            duyurularOperations.Update(duyuru);

            return RedirectToAction("Index");
        }

        public IActionResult Sil(int id)
        {
            var item = duyurularOperations.GetById(id);
            if (item == null)
            {
                return RedirectToAction("Index");
            }
            return View(item);
        }

        [HttpPost]
        public IActionResult Sil(int id, IFormCollection collection)
        {
            duyurularOperations.Delete(id);
            return RedirectToAction("Index");
        }


    }
}