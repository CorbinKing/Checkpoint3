using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlowOut.Models;
using System.Net;
using System.Net.Mail;

namespace BlowOut.Controllers
{
    public class GmailController : Controller
    {
        // GET: Gmail
        public ActionResult Index()
        {
            return View();
        }

        // Post: Gmail
        [HttpPost]
        public ActionResult Index(Gmail model)
        {
            MailMessage myMessage = new MailMessage("mj2797@gmail.com", model.To);
            myMessage.Subject = model.Subject;
            myMessage.Body = model.Body;
            myMessage.IsBodyHtml = false;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;

            NetworkCredential myCredential = new NetworkCredential("mj2797@gmail.com", "15673Jenkins!");
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = myCredential;
            smtp.Send(myMessage);
            ViewBag.Message = "Thank you, you're message has been sent";



            return View("Thanks");
        }
    }
}