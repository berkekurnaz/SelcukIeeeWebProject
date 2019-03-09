using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SelcukIeeeWebProject.DataAccessLayer;
using SelcukIeeeWebProject.Filter;
using SelcukIeeeWebProject.Models;

namespace SelcukIeeeWebProject.Controllers.Site
{
    [AuthFilter]
    public class YonetimEtkinliklerController : Controller
    {

        EtkinlikOperations etkinlikOperations = new EtkinlikOperations();

        public IActionResult Index()
        {
            return View(etkinlikOperations.GetAll().OrderByDescending(x => x.Id));
        }

        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Ekle(Etkinliks etkinlik)
        {
            if (ModelState.IsValid)
            {
                etkinlikOperations.Add(etkinlik);
                return RedirectToAction("Index");
            }
            return View(etkinlik);
        }

        public IActionResult Guncelle(int id)
        {
            var item = etkinlikOperations.GetById(id);
            if (item == null)
            {
                return RedirectToAction("Index");
            }
            return View(item);
        }

        [HttpPost]
        public IActionResult Guncelle(int id, Etkinliks newEtkinlik)
        {
            var etkinlik = etkinlikOperations.GetById(id);

            etkinlik.EtkinlikAd = newEtkinlik.EtkinlikAd;
            etkinlik.EtkinlikAciklama = newEtkinlik.EtkinlikAciklama;
            etkinlik.Tarih = newEtkinlik.Tarih;
            etkinlikOperations.Update(etkinlik);

            return RedirectToAction("Index");
        }

        public IActionResult Sil(int id)
        {
            var item = etkinlikOperations.GetById(id);
            if (item == null)
            {
                return RedirectToAction("Index");
            }
            return View(item);
        }

        [HttpPost]
        public IActionResult Sil(int id, IFormCollection collection)
        {
            etkinlikOperations.Delete(id);
            return RedirectToAction("Index");
        }

    }
}