using Microsoft.AspNetCore.Mvc;
using PorcelainAndAlabaster.Models;
using System.Data.SqlClient;
using System.Data;

namespace PorcelainAndAlabaster.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        private readonly ILogger<HomeController> _logger;

        public AdminController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Acquisitions()
        {
            return View();
        }
        public IActionResult AdminEdit()
        {
            return View();
        }
        public IActionResult Cataloger()
        {
            return View();
        }
        public IActionResult EventsEditor()
        {
            return View();
        }
        public IActionResult ILLReview()
        {
            return View();
        }
        public IActionResult PatronEdit()
        {
            return View();
        }
        public IActionResult ReferenceGuideEdit()
        {
            return View();
        }
        public IActionResult RoomBookings()
        {
            return View();
        }
        public IActionResult Settings()
        {
            return View();
        }
        public IActionResult Statistics()
        {
            return View();
        }
        public IActionResult Weeding()
        {
            return View();
        }

        public void InsertPatrons(Patron[] patrons)
            {
                using (SqlConnection connection = new SqlConnection("YourConnectionString"))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("InsertPatrons", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        SqlParameter parameter = command.Parameters.AddWithValue("@users", CreatePatronDataTable(patrons));
                        parameter.SqlDbType = SqlDbType.Structured;
                        parameter.TypeName = "dbo.UserType";

                        command.ExecuteNonQuery();
                    }
                }
            }

        private DataTable CreatePatronDataTable(Patron[] patrons)
        {
            DataTable table = new DataTable();
            table.Columns.Add("firstName", typeof(string));
            table.Columns.Add("middleName", typeof(string));
            table.Columns.Add("lastName", typeof(string));
            table.Columns.Add("address1", typeof(string));
            table.Columns.Add("address2", typeof(string));
            table.Columns.Add("email", typeof(string));
            table.Columns.Add("homePhone", typeof(string));
            table.Columns.Add("cellPhone", typeof(string));

            foreach (Patron patron in patrons)
            {
                table.Rows.Add(patron.FirstName, patron.MiddleName, patron.LastName, patron.PrimaryMailingAddress, patron.SecondaryMailingAddress, patron.EmailAddress, patron.HomePhoneNumber, patron.MobilePhoneNumber);
            }

            return table;
        }

        public void InsertUsers(Patron[] patrons)
        {
            using (SqlConnection connection = new SqlConnection("YourConnectionString"))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("InsertUsers", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    SqlParameter parameter = command.Parameters.AddWithValue("@users", CreatePatronDataTable(patrons));
                    parameter.SqlDbType = SqlDbType.Structured;
                    parameter.TypeName = "dbo.UserType";

                    command.ExecuteNonQuery();
                }
            }
        }

        private DataTable CreateUserDataTable(User[] users)
        {
            DataTable table = new DataTable();
            table.Columns.Add("name", typeof(string));
            table.Columns.Add("email", typeof(string));

            foreach (User user in users)
            {
                table.Rows.Add(user.FirstName, user.MiddleName);
            }

            return table;
        }
    }
}
