using System;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using System.Web;
using CryptoBox.Data.Models;
using CryptoBox.Exceptions;
using CryptoBox.Repo;
using CryptoBox.Service.Email;
using Microsoft.EntityFrameworkCore;

namespace CryptoBox.Helpers
{
    public class EmailSender
    {
        private readonly IActivationService _activationService;

        public EmailSender(IActivationService activationService)
        {
            _activationService = activationService;
        }

        public GeneralException SendEmailActivation(string email)
        {
            try
            {
                //Set mail SMTP settings
                SmtpClient client = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential("***@gmail.com", "***")
                };

                MailMessage mailMessage = new MailMessage
                {
                    From = new MailAddress("***@gmail.com"),
                    Subject = "Crypto Box Activation",
                    //Fix localhost port
                    Body = "Ready Crypto Box Activation </br><a href='http://localhost:5725/Email/Activation?key=" + HttpUtility.UrlEncode(new EmailActivaitonKey(_activationService).ActivationKey(email)) + "'><h1>Click For Activation<h1><a>",
                    To = { email },
                    IsBodyHtml = true
                };

                client.Send(mailMessage);
                client.Dispose();
                return new GeneralException(true);
            }
            catch (Exception ex)
            {
                return new GeneralException(false, ex.Message);
            }

        }
    }
}
