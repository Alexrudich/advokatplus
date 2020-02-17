using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using advokatplus.Models;
using advokatplus.Models.Feedback;

namespace advokatplus.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly EmailAddress FromAndToEmailAddress;
        private IEmailService EmailService;

        public HomeController(EmailAddress _fromAddress, IEmailService _emailService, ILogger<HomeController> logger)
        {
            _logger = logger;
            FromAndToEmailAddress = _fromAddress;
            EmailService = _emailService;
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
        public IActionResult Contact()
        {
            ViewData["Message"] = "Contact page.";

            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactModel model)
        {
            if (ModelState.IsValid)
            {
                EmailMessage msgToSend = new EmailMessage
                {
                    FromAddresses = new List<EmailAddress> { FromAndToEmailAddress },
                    ToAddresses = new List<EmailAddress> { FromAndToEmailAddress },
                    Content = $"Отправитель: {model.Contact.Name} { model.Contact.LastName}," + $" Email: {model.Contact.Email}. Сообщение: {model.Contact.Message}. Телефон: {model.Contact.PhoneNumber}",
                    Subject = "Новое сообщение с сайта"
                };
                EmailService.Send(msgToSend);
                return RedirectToAction("Contact");
            }
            else
            {
                return Contact();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
