using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PagedList.Core;
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
        IletisimOperations iletisimOperations = new IletisimOperations();

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

        /* Etkinlik Detay Sayfasi */
        public IActionResult EtkinlikDetay(int id)
        {
            var etkinlik = etkinlikOperations.GetById(id);
            if (etkinlik == null)
            {
                return RedirectToAction("Hata");
            }
            var etkinlikFotografs = etkinlikFotografOperations.GetAllByEtkinlik(id);

            ViewModels viewModels = new ViewModels();
            viewModels.Etkinliks = etkinlik;
            viewModels.EtkinlikFotografs = etkinlikFotografs;

            return View(viewModels);
        }

        /* Anasayfa Blog Sayfasi */
        public IActionResult Blog(int? sayfa = 1)
        {
            var query = blogOperations.GetAll().OrderByDescending(x => x.Id);
            //PagedList<Blogs> model = new PagedList<Blogs>(query, sayfa, sayfaBoyu);
            var sayfaNumber = sayfa == null || sayfa <= 0 ? 1 : sayfa.Value;
            var sayfaBoyu = 9;
            var model = query.ToPagedList(sayfaNumber,sayfaBoyu);
            return View("Blog", model);
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

        [HttpPost]
        public IActionResult Iletisim(Iletisims iletisim)
        {
            if (ModelState.IsValid)
            {
                var newMesaj = new Iletisims();
                newMesaj.Durum = "Okunmadı";
                newMesaj.Tarih = DateTime.Now.ToShortDateString();
                newMesaj.AdSoyad = iletisim.AdSoyad;
                newMesaj.Baslik = iletisim.Baslik;
                newMesaj.Mail = iletisim.Mail;
                newMesaj.Mesaj = iletisim.Mesaj;
                newMesaj.Telefon = iletisim.Telefon;
                iletisimOperations.Add(newMesaj);
                return RedirectToAction("MesajBasari");
            }
            return View(iletisim);
        }

        public IActionResult MesajBasari()
        {
            return View();
        }

        /* Hata Durumunda Cikan Sayfa */
        public IActionResult Hata()
        {
            return View();
        }

        /* Hakkimizda Bolumu Ieee Nedir Sayfasi */
        public IActionResult IeeeNedir()
        {
            return View();
        }

        /* Hakkimizda Bolumu Biz Kimiz Sayfasi */
        public IActionResult BizKimiz()
        {
            return View();
        }

        /* Hakkimizda Bolumu Yonetim Kurulu Sayfasi */
        public IActionResult YonetimKurulu()
        {
            return View();
        }

        /* Hakkimizda Bolumu Idari Kurul Sayfasi */
        public IActionResult IdariKurul()
        {
            return View();
        }

    }
}