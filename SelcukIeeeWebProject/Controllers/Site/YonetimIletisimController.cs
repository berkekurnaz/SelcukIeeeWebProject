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
    public class YonetimIletisimController : Controller
    {

        IletisimOperations iletisimOperations = new IletisimOperations();

        public IActionResult Index()
        {
            return View(iletisimOperations.GetAll().OrderByDescending(x => x.Id));
        }

        public IActionResult Incele(int id)
        {
            var item = iletisimOperations.GetById(id);
            if (item == null)
            {
                return RedirectToAction("Index");
            }
            return View(item);
        }

        [HttpPost]
        public IActionResult Incele(int id, Iletisims newIletisim)
        {
            var iletisim = iletisimOperations.GetById(id);

            iletisim.Durum = newIletisim.Durum;
            iletisimOperations.Update(iletisim);

            return RedirectToAction("Index");
        }

        public IActionResult Sil(int id)
        {
            var item = iletisimOperations.GetById(id);
            if (item == null)
            {
                return RedirectToAction("Index");
            }
            return View(item);
        }

        [HttpPost]
        public IActionResult Sil(int id, IFormCollection collection)
        {
            iletisimOperations.Delete(id);
            return RedirectToAction("Index");
        }


    }
}