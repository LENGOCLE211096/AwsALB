using AwsALB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AwsALB.Controllers
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
            try
            {
                //HttpContext.Session.SetString("username", "Lê Ngọc Lễ");
                if (string.IsNullOrEmpty(HttpContext.Session.GetString("username")))
                {
                    _logger.LogInformation("username is null");
                    return RedirectToAction("Index", "Account");
                }
                ViewBag.username = HttpContext.Session.GetString("username");
            }
            catch(Exception ex)
            {
                _logger.LogError("Home Exception " + ex.Message);
            }
            return View();
        }

        public IActionResult Privacy()
        {
            ViewBag.username = HttpContext.Session.GetString("username");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
