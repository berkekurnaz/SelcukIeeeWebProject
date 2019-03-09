using System;
using System.Collections.Generic;
using System.IO;
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
    public class YonetimBlogController : Controller
    {

        BlogOperations blogOperations = new BlogOperations();

        public IActionResult Index()
        {
            return View(blogOperations.GetAll().OrderByDescending(x =>x.Id));
        }

        public IActionResult Incele(int id)
        {
            return View(blogOperations.GetById(id));
        }

        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Ekle(Blogs blog, IFormFile Image)
        {
            var myBlog = new Blogs();

            if (Image == null || Image.Length == 0)
            {
                return RedirectToAction("Error", "Yonetim");
            }

            string newImage = Guid.NewGuid().ToString() + Image.FileName;

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img\\bloglar", newImage);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await Image.CopyToAsync(stream);
            }

            myBlog.Fotograf = newImage;
            myBlog.Baslik = blog.Baslik;
            myBlog.Yazar = blog.Yazar;
            myBlog.EklenmeTarihi = blog.EklenmeTarihi;
            myBlog.Icerik = blog.Icerik;
            blogOperations.Add(myBlog);

            return RedirectToAction("Index");
        }

        public IActionResult Sil(int id)
        {
            var item = blogOperations.GetById(id);
            if (item == null)
            {
                return RedirectToAction("Error", "Yonetim");
            }
            return View(item);
        }

        [HttpPost]
        public IActionResult Sil(int id, IFormCollection collection)
        {
            var item = blogOperations.GetById(id);
            if (item == null)
            {
                return RedirectToAction("Error", "Yonetim");
            }
            if (System.IO.File.Exists(Directory.GetCurrentDirectory() + "\\wwwroot\\img\\bloglar\\" + item.Fotograf))
            {
                System.IO.File.Delete(Directory.GetCurrentDirectory() + "\\wwwroot\\img\\bloglar\\" + item.Fotograf);
            }
            blogOperations.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Guncelle(int id)
        {
            var item = blogOperations.GetById(id);
            if (item == null)
            {
                return RedirectToAction("Error", "Yonetim");
            }
            return View(item);
        }

        [HttpPost]
        public async Task<IActionResult> Guncelle(int id, Blogs blog, IFormFile Image)
        {
            var item = blogOperations.GetById(id);
            if (item == null)
            {
                return RedirectToAction("Error", "Yonetim");
            }

            if (Image != null)
            {
                if (System.IO.File.Exists(Directory.GetCurrentDirectory() + "\\wwwroot\\img\\bloglar\\" + item.Fotograf))
                {
                    System.IO.File.Delete(Directory.GetCurrentDirectory() + "\\wwwroot\\img\\bloglar\\" + item.Fotograf);
                }

                string newImage = Guid.NewGuid().ToString() + Image.FileName;

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img\\bloglar", newImage);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await Image.CopyToAsync(stream);
                }

                item.Fotograf = newImage;
            }

            item.Baslik = blog.Baslik;
            item.EklenmeTarihi = blog.EklenmeTarihi;
            item.Yazar = blog.Yazar;
            item.Icerik = blog.Icerik;
            blogOperations.Update(item);

            return RedirectToAction("Index");
        }

    }
}