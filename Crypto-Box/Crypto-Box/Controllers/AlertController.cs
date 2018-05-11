using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CryptoBox.Controllers
{
    public class AlertController : Controller
    {
        public IActionResult EmailValidFailed()
        {
            return View();
        }
        public IActionResult EmailValidSuccess()
        {
            return View();
        }
        public IActionResult EmailValidExpired()
        {
            return View();
        }
    }
}
