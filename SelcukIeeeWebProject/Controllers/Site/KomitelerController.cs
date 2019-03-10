using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SelcukIeeeWebProject.Controllers.Site
{
    public class KomitelerController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TeknikProjeler()
        {
            return View();
        }

        public IActionResult Tems()
        {
            return View();
        }

        public IActionResult Eac()
        {
            return View();
        }

        public IActionResult Comsoc()
        {
            return View();
        }

    }
}