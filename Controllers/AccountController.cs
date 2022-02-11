using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AwsALB.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        public AccountController(ILogger<AccountController> logger)
        {
            _logger = logger;

        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SignUp(string username)
        {
            try
            {
                _logger.LogInformation("username " + username);
                if (!string.IsNullOrEmpty(username))
                {
                    _logger.LogInformation("set session " + username);
                    HttpContext.Session.SetString("username", username);
                    _logger.LogInformation("redirect after set session " + username);
                    return RedirectToAction("Index", "Home");
                }
            }catch(Exception ex)
            {
                _logger.LogError("Account Exception " + ex.Message);
            }
            return RedirectToAction("Index", "Account"); 
        }
    }
}
