using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using advokatplus.Models;

namespace advokatplus.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Prices()
        {
            ViewData["Message"] = "Prices page.";

            return View();
        }


        [HttpGet]
        public IActionResult Questions()
        {
            ViewData["Message"] = "Questions and answers page.";

            return View();
        }

        [HttpGet]
        public IActionResult Contacts()
        {
            ViewData["Message"] = "Contact page.";

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
