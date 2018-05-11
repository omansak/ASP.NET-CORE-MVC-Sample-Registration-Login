using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryptoBox.Data.Models;
using CryptoBox.Service.Email;
using CryptoBox.Service.Users;
using Microsoft.AspNetCore.Mvc;

namespace CryptoBox.Controllers
{
    public class EmailController : Controller
    {
        private readonly IActivationService _activationService;
        private readonly IUserService _userService;
        public EmailController(IActivationService activationService, IUserService userService)
        {
            _activationService = activationService;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Activation(string key)
        {
            string output = new Helpers.AESEncryption().DecryptText(key);
            string[] tokens = output.Split(":OSK:");
            EmailValid emailValid = _activationService.GetByFilter(i => i.Email == tokens[0] && i.ActivationKey == tokens[2] && DateTime.Parse(i.Time.ToString()) == DateTime.Parse(tokens[1]));
            if (emailValid != null)
            {
                if (DateTime.Now > DateTime.Parse(tokens[1]).AddDays(1))
                {
                    return RedirectToAction("EmailValidExpired", "Alert");
                }
                _activationService.Delete(emailValid);
                CryptoBox.Data.Models.Users user = _userService.GetByFilter(i => emailValid.Email == i.Email);
                user.EmailValid = true;
                _userService.UpdateUser(user);
                return RedirectToAction("EmailValidSuccess", "Alert");
            }
            return RedirectToAction("EmailValidFailed", "Alert");

        }
    }
}
