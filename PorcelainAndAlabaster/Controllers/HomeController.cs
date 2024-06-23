using Microsoft.AspNetCore.Mvc;
using PorcelainAndAlabaster.Models;
using PorcelainAndAlabaster.Settings;
using System.Data.SqlClient;
using System.Data;
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
            ViewBag.AboutLibrary = GetAbout();
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

        public List<LibraryEvent> GetLibraryEvents()
        {
            var libraryEventList = new List<LibraryEvent>();
            using (SqlConnection connection = new SqlConnection(DatabaseSettings.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetLibraryEvents", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var obj = new LibraryEvent();
                            obj.EventName = reader.GetString(reader.GetOrdinal("title"));
                            obj.EventDescription = reader.GetString(reader.GetOrdinal("eventDescription"));
                            obj.ImageURL = reader.GetString(reader.GetOrdinal("imageURL"));
                            libraryEventList.Add(obj);
                        }
                    }
                }
                connection.Close();
            }
            return libraryEventList;
        }
        public AboutLibrary GetAbout()
        {
            var aboutLibrary = new AboutLibrary();
            using (SqlConnection connection = new SqlConnection(DatabaseSettings.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetAboutLibrary", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            aboutLibrary.AboutTheLibrary = reader.GetString(reader.GetOrdinal("aboutTheLibrary"));
                            aboutLibrary.MissionStatement = reader.GetString(reader.GetOrdinal("missionStatement"));
                            aboutLibrary.VisionStatement = reader.GetString(reader.GetOrdinal("visionStatement"));
                        }
                    }
                }
                connection.Close();
            }
            return aboutLibrary;
        }
        public IActionResult Events()
        {
            ViewBag.LibraryEvents = GetLibraryEvents();
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