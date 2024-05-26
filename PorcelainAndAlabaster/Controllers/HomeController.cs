using Microsoft.AspNetCore.Mvc;
using PorcelainAndAlabaster.Models;
using System.Diagnostics;
using System.Net.Mail;

namespace PorcelainAndAlabaster.Controllers
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

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Archives()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }

        public void ContactSubmit(Contact contact, EventArgs e)
        {
            // Set up email client
            // Configure to the library settings
            SmtpClient smtpClient = new SmtpClient("", 25);
            smtpClient.Credentials = new System.Net.NetworkCredential("", "");
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.EnableSsl = true;
            MailMessage message = new MailMessage();
            // Set email address based on library
            message.To.Add(new MailAddress("insertLibraryEmail@library", "Library"));
            message.From = new MailAddress("contactForm@library", "library name");
            message.Subject = "Contact Request";
            message.Body = $"First Name: {contact.FirstName} Last Name: {contact.LastName} Email: {contact.Email} Question: {contact.Question}";
            smtpClient.Send(message);

        }

        public void ILLSubmit(ILLRequest iLLRequest, EventArgs e)
        {
            // Set up email client
            // Configure to the library settings
            SmtpClient smtpClient = new SmtpClient("", 25);
            smtpClient.Credentials = new System.Net.NetworkCredential("", "");
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.EnableSsl = true;
            MailMessage message = new MailMessage();
            // Set email address based on library
            message.To.Add(new MailAddress("insertLibraryEmail@library", "Library"));
            message.From = new MailAddress("contactForm@library", "library name");
            message.Subject = "ILL Request";
            message.Body = $"First Name: {iLLRequest.FirstName} Last Name: {iLLRequest.LastName} Email: {iLLRequest.Email} Library Card Number: {iLLRequest.LibraryCardNumber} Title: {iLLRequest.Title} Author: {iLLRequest.Author} Journal: {iLLRequest.Journal} Volume: {iLLRequest.Volume}";
            smtpClient.Send(message);

        }
        public IActionResult Events()
        {
            return View();
        }
        public IActionResult ILLRequest()
        {
            return View();
        }
        public IActionResult YourAccount()
        {
            return View();
        }
        public IActionResult ReferenceGuide()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}