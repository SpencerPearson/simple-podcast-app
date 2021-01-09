using SimplePodcastApp.UI.MVC.Models;
using System.Net.Mail;
using System.Net;
using System.Web.Mvc;
using System;

namespace SimplePodcastApp.UI.MVC.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(ContactViewModel cvm)
        {
            if (ModelState.IsValid)
            {
                string body = $"You have received a new message from {cvm.FullName}. <br />" +
                    $"Sender's email: {cvm.Email} <br />" +
                    $"Subject: {cvm.Subject} <br />" +
                    $"Message: <br />{cvm.Message}";

                MailMessage msg = new MailMessage("no-reply@spencerpearson.net", "spencer.pearson.816@gmail.com", cvm.Subject, body);

                msg.IsBodyHtml = true;
                msg.Priority = MailPriority.High;
                msg.ReplyToList.Add(cvm.Email);
                

                SmtpClient client = new SmtpClient("mail.spencerpearson.net");
                client.Credentials = new NetworkCredential("no-reply@spencerpearson.net", "*********");

                try
                {
                    client.Send(msg);
                }
                catch (Exception ex)
                {

                    ViewBag.ErrorMessage = "Oops! Seems like your request could not be sent at this time. Please try again later.";
                    return View(cvm);
                }

                return View("EmailConfirmation", cvm);
            } else
            {
                return View(cvm);
            }
        }
    }
}
