﻿using Azure.Blob.Web.Sample.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Azure.Blob.Web.Sample.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Error()
        {
            ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View();
        }
    }
}
