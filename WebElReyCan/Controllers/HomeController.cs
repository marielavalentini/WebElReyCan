﻿using Microsoft.AspNetCore.Mvc;
using System;

namespace WebElReyCan.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Fecha = DateTime.Now.ToString();
            return View();
        }
    }
}
