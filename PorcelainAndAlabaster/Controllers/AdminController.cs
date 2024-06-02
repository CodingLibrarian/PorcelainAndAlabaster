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
                    connection.Close();
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
                connection.Close();
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
        // TODO: Need to make the Get Users from DB permission based and build security around the patron one
        private List<User> GetUserbyID(int userID)
        {
            var userList = new List<User>();
            using (SqlConnection connection = new SqlConnection("YourConnectionString"))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetUserByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    SqlParameter parameter = command.Parameters.AddWithValue("@userID", userID);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var obj = new User();
                            obj.UserId = reader.GetInt32(reader.GetOrdinal("id"));
                            obj.Username = reader.GetString(reader.GetOrdinal("userName"));
                            obj.Setting = reader.GetString(reader.GetOrdinal("settings"));
                            obj.FirstName = reader.GetString(reader.GetOrdinal("firstName"));
                            obj.MiddleName = reader.GetString(reader.GetOrdinal("middleName"));
                            obj.LastName = reader.GetString(reader.GetOrdinal("lastName"));
                            obj.EmailAddress = reader.GetString(reader.GetOrdinal("email"));
                            obj.PrimaryMailingAddress = reader.GetString(reader.GetOrdinal("address1"));
                            obj.SecondaryMailingAddress = reader.GetString(reader.GetOrdinal("address2"));
                            obj.HomePhoneNumber = reader.GetString(reader.GetOrdinal("homePhone"));
                            obj.MobilePhoneNumber = reader.GetString(reader.GetOrdinal("cellPhone"));
                            userList.Add(obj);
                        }
                    }
                }
                connection.Close();
            }
            return userList;
        }

        private List<Patron> GetPatronbyID(int patronID)
        {
            var patronList = new List<Patron>();
            using (SqlConnection connection = new SqlConnection("YourConnectionString"))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetPatronByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    SqlParameter parameter = command.Parameters.AddWithValue("@patronID", patronID);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var obj = new Patron();
                            obj.FirstName = reader.GetString(reader.GetOrdinal("firstName"));
                            obj.MiddleName = reader.GetString(reader.GetOrdinal("middleName"));
                            obj.LastName = reader.GetString(reader.GetOrdinal("lastName"));
                            obj.EmailAddress = reader.GetString(reader.GetOrdinal("email"));
                            obj.PrimaryMailingAddress = reader.GetString(reader.GetOrdinal("address1"));
                            obj.SecondaryMailingAddress = reader.GetString(reader.GetOrdinal("address2"));
                            obj.HomePhoneNumber = reader.GetString(reader.GetOrdinal("homePhone"));
                            obj.MobilePhoneNumber = reader.GetString(reader.GetOrdinal("cellPhone"));
                            obj.Settings = reader.GetString(reader.GetOrdinal("settings"));
                            patronList.Add(obj);
                        }
                    }
                }
                connection.Close();
            }
            return patronList;
        }
        private List<Patron> GetPatronbyName(string patronName)
        {
            var patronList = new List<Patron>();
            using (SqlConnection connection = new SqlConnection("YourConnectionString"))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetPatronByLastName", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    SqlParameter parameter = command.Parameters.AddWithValue("@patronLastName", patronName);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var obj = new Patron();
                            obj.FirstName = reader.GetString(reader.GetOrdinal("firstName"));
                            obj.MiddleName = reader.GetString(reader.GetOrdinal("middleName"));
                            obj.LastName = reader.GetString(reader.GetOrdinal("lastName"));
                            obj.EmailAddress = reader.GetString(reader.GetOrdinal("email"));
                            obj.PrimaryMailingAddress = reader.GetString(reader.GetOrdinal("address1"));
                            obj.SecondaryMailingAddress = reader.GetString(reader.GetOrdinal("address2"));
                            obj.HomePhoneNumber = reader.GetString(reader.GetOrdinal("homePhone"));
                            obj.MobilePhoneNumber = reader.GetString(reader.GetOrdinal("cellPhone"));
                            obj.Settings = reader.GetString(reader.GetOrdinal("settings"));
                            patronList.Add(obj);
                        }
                    }
                }
                using (SqlCommand command2 = new SqlCommand("GetPatronByFirstName", connection))
                {
                    command2.CommandType = CommandType.StoredProcedure;

                    SqlParameter parameter = command2.Parameters.AddWithValue("@patronFirstName", patronName);

                    using (SqlDataReader reader = command2.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var obj = new Patron();
                            obj.FirstName = reader.GetString(reader.GetOrdinal("firstName"));
                            obj.MiddleName = reader.GetString(reader.GetOrdinal("middleName"));
                            obj.LastName = reader.GetString(reader.GetOrdinal("lastName"));
                            obj.EmailAddress = reader.GetString(reader.GetOrdinal("email"));
                            obj.PrimaryMailingAddress = reader.GetString(reader.GetOrdinal("address1"));
                            obj.SecondaryMailingAddress = reader.GetString(reader.GetOrdinal("address2"));
                            obj.HomePhoneNumber = reader.GetString(reader.GetOrdinal("homePhone"));
                            obj.MobilePhoneNumber = reader.GetString(reader.GetOrdinal("cellPhone"));
                            obj.Settings = reader.GetString(reader.GetOrdinal("settings"));
                            patronList.Add(obj);
                        }
                    }
                }
                using (SqlCommand command3 = new SqlCommand("GetPatronByMiddleName", connection))
                {
                    command3.CommandType = CommandType.StoredProcedure;

                    SqlParameter parameter = command3.Parameters.AddWithValue("@patronMiddleName", patronName);

                    using (SqlDataReader reader = command3.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var obj = new Patron();
                            obj.FirstName = reader.GetString(reader.GetOrdinal("firstName"));
                            obj.MiddleName = reader.GetString(reader.GetOrdinal("middleName"));
                            obj.LastName = reader.GetString(reader.GetOrdinal("lastName"));
                            obj.EmailAddress = reader.GetString(reader.GetOrdinal("email"));
                            obj.PrimaryMailingAddress = reader.GetString(reader.GetOrdinal("address1"));
                            obj.SecondaryMailingAddress = reader.GetString(reader.GetOrdinal("address2"));
                            obj.HomePhoneNumber = reader.GetString(reader.GetOrdinal("homePhone"));
                            obj.MobilePhoneNumber = reader.GetString(reader.GetOrdinal("cellPhone"));
                            obj.Settings = reader.GetString(reader.GetOrdinal("settings"));
                            patronList.Add(obj);
                        }
                    }
                }
                connection.Close();
            }
            return patronList;
        }
        private List<BibRecord> GetBibRecordbyID(int bibRecordID)
        {
            var bibList = new List<BibRecord>();
            using (SqlConnection connection = new SqlConnection("YourConnectionString"))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetBibRecordByID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    SqlParameter parameter = command.Parameters.AddWithValue("@bibRecordID", bibRecordID);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var obj = new BibRecord();
                            obj.Id = reader.GetInt32(reader.GetOrdinal("id"));
                            obj.Title = reader.GetString(reader.GetOrdinal("title"));
                            obj.Author = reader.GetString(reader.GetOrdinal("author"));
                            obj.Publisher = reader.GetString(reader.GetOrdinal("publisher"));
                            obj.PublisherLocation = reader.GetString(reader.GetOrdinal("publisherLocation"));
                            obj.Created = reader.GetDateTime(reader.GetOrdinal("created"));
                            obj.LastUpdated = reader.GetDateTime(reader.GetOrdinal("lastUpdate"));
                            obj.IsDeleted = reader.GetBoolean(reader.GetOrdinal("isDeleted"));
                            obj.MARCRecord = reader.GetString(reader.GetOrdinal("marcRecord"));
                            bibList.Add(obj);
                        }
                    }
                }
                connection.Close();
            }
            return bibList;
        }

        private List<BibRecord> GetBibRecordbyTitle(string bibRecordTitle)
        {
            var bibList = new List<BibRecord>();
            using (SqlConnection connection = new SqlConnection("YourConnectionString"))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetBibRecordByTitle", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    SqlParameter parameter = command.Parameters.AddWithValue("@bibRecordTitle", bibRecordTitle);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var obj = new BibRecord();
                            obj.Id = reader.GetInt32(reader.GetOrdinal("id"));
                            obj.Title = reader.GetString(reader.GetOrdinal("title"));
                            obj.Author = reader.GetString(reader.GetOrdinal("author"));
                            obj.Publisher = reader.GetString(reader.GetOrdinal("publisher"));
                            obj.PublisherLocation = reader.GetString(reader.GetOrdinal("publisherLocation"));
                            obj.Created = reader.GetDateTime(reader.GetOrdinal("created"));
                            obj.LastUpdated = reader.GetDateTime(reader.GetOrdinal("lastUpdate"));
                            obj.IsDeleted = reader.GetBoolean(reader.GetOrdinal("isDeleted"));
                            obj.MARCRecord = reader.GetString(reader.GetOrdinal("marcRecord"));
                            bibList.Add(obj);
                        }
                    }
                }
                connection.Close();
            }
            return bibList;
        }

        private List<BibRecord> GetBibRecordbyAuthor(string bibRecordAuthor)
        {
            var bibList = new List<BibRecord>();
            using (SqlConnection connection = new SqlConnection("YourConnectionString"))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetBibRecordByAuthor", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    SqlParameter parameter = command.Parameters.AddWithValue("@bibRecordAuthor", bibRecordAuthor);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var obj = new BibRecord();
                            obj.Id = reader.GetInt32(reader.GetOrdinal("id"));
                            obj.Title = reader.GetString(reader.GetOrdinal("title"));
                            obj.Author = reader.GetString(reader.GetOrdinal("author"));
                            obj.Publisher = reader.GetString(reader.GetOrdinal("publisher"));
                            obj.PublisherLocation = reader.GetString(reader.GetOrdinal("publisherLocation"));
                            obj.Created = reader.GetDateTime(reader.GetOrdinal("created"));
                            obj.LastUpdated = reader.GetDateTime(reader.GetOrdinal("lastUpdate"));
                            obj.IsDeleted = reader.GetBoolean(reader.GetOrdinal("isDeleted"));
                            obj.MARCRecord = reader.GetString(reader.GetOrdinal("marcRecord"));
                            bibList.Add(obj);
                        }
                    }
                }
                connection.Close();
            }
            return bibList;
        }

        private List<BibRecord> GetBibRecordbyPublisher(string bibRecordPublisher)
        {
            var bibList = new List<BibRecord>();
            using (SqlConnection connection = new SqlConnection("YourConnectionString"))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetBibRecordByPublisher", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    SqlParameter parameter = command.Parameters.AddWithValue("@bibRecordPublisher", bibRecordPublisher);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var obj = new BibRecord();
                            obj.Id = reader.GetInt32(reader.GetOrdinal("id"));
                            obj.Title = reader.GetString(reader.GetOrdinal("title"));
                            obj.Author = reader.GetString(reader.GetOrdinal("author"));
                            obj.Publisher = reader.GetString(reader.GetOrdinal("publisher"));
                            obj.PublisherLocation = reader.GetString(reader.GetOrdinal("publisherLocation"));
                            obj.Created = reader.GetDateTime(reader.GetOrdinal("created"));
                            obj.LastUpdated = reader.GetDateTime(reader.GetOrdinal("lastUpdate"));
                            obj.IsDeleted = reader.GetBoolean(reader.GetOrdinal("isDeleted"));
                            obj.MARCRecord = reader.GetString(reader.GetOrdinal("marcRecord"));
                            bibList.Add(obj);
                        }
                    }
                }
                connection.Close();
            }
            return bibList;
        }
    }
}
