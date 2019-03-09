using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SelcukIeeeWebProject.DataAccessLayer;
using SelcukIeeeWebProject.Filter;
using SelcukIeeeWebProject.Models;

namespace SelcukIeeeWebProject.Controllers.Site
{
    [AuthFilter]
    public class YonetimFotograflarController : Controller
    {

        EtkinlikFotografOperations etkinlikFotografOperations = new EtkinlikFotografOperations();
        EtkinlikOperations etkinlikOperations = new EtkinlikOperations();

        public IActionResult Index()
        {
            return View(etkinlikOperations.GetAll());
        }

        public IActionResult Fotograflar(int id)
        {
            return View(etkinlikFotografOperations.GetAllByEtkinlik(id));
        }

        public IActionResult Incele(int id)
        {
            var item = etkinlikFotografOperations.GetById(id);
            if (item == null)
            {
                return RedirectToAction("Error", "Yonetim");
            }
            return View(item);
        }

        public IActionResult Ekle()
        {
            ViewBag.EtkinlikId = new SelectList(etkinlikOperations.GetAll(), "Id", "EtkinlikAd");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Ekle(EtkinlikFotografs etkinlikFotograf, IFormFile Image)
        {
            var myEtkinlikFotograf = new EtkinlikFotografs();

            if (Image == null || Image.Length == 0)
            {
                return RedirectToAction("Error", "Yonetim");
            }

            string newImage = Guid.NewGuid().ToString() + Image.FileName;

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img\\etkinlikler", newImage);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await Image.CopyToAsync(stream);
            }

            myEtkinlikFotograf.Fotograf = newImage;

            myEtkinlikFotograf.Ad = etkinlikFotograf.Ad;
            myEtkinlikFotograf.EtkinlikId = etkinlikFotograf.EtkinlikId;
            etkinlikFotografOperations.Add(myEtkinlikFotograf);

            return RedirectToAction("Index");
        }

        public IActionResult Sil(int id)
        {
            var item = etkinlikFotografOperations.GetById(id);
            if (item == null)
            {
                return RedirectToAction("Error", "Yonetim");
            }
            return View(item);
        }

        [HttpPost]
        public IActionResult Sil(int id, IFormCollection collection)
        {
            var fotograf = etkinlikFotografOperations.GetById(id);
            if (fotograf == null)
            {
                return RedirectToAction("Error", "Yonetim");
            }
            if (System.IO.File.Exists(Directory.GetCurrentDirectory() + "\\wwwroot\\img\\etkinlikler\\" + fotograf.Fotograf))
            {
                System.IO.File.Delete(Directory.GetCurrentDirectory() + "\\wwwroot\\img\\etkinlikler\\" + fotograf.Fotograf);
            }
            etkinlikFotografOperations.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Guncelle(int id)
        {
            var item = etkinlikFotografOperations.GetById(id);
            if (item == null)
            {
                return RedirectToAction("Error", "Yonetim");
            }
            ViewBag.EtkinlikId = new SelectList(etkinlikOperations.GetAll(), "Id", "EtkinlikAd", etkinlikFotografOperations.GetById(id).EtkinlikId);
            return View(item);
        }

        [HttpPost]
        public async Task<IActionResult> Guncelle(int id, EtkinlikFotografs etkinlikFotograf, IFormFile Image)
        {
            var item = etkinlikFotografOperations.GetById(id);
            if (item == null)
            {
                return RedirectToAction("Error", "Yonetim");
            }

            if (Image != null)
            {
                if (System.IO.File.Exists(Directory.GetCurrentDirectory() + "\\wwwroot\\img\\etkinlikler\\" + item.Fotograf))
                {
                    System.IO.File.Delete(Directory.GetCurrentDirectory() + "\\wwwroot\\img\\etkinlikler\\" + item.Fotograf);
                }

                string newImage = Guid.NewGuid().ToString() + Image.FileName;

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img\\etkinlikler", newImage);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await Image.CopyToAsync(stream);
                }

                item.Fotograf = newImage;
            }

            item.Ad = etkinlikFotograf.Ad;
            item.EtkinlikId = etkinlikFotograf.EtkinlikId;
            etkinlikFotografOperations.Update(item);

            return RedirectToAction("Index");
        }

    }
}