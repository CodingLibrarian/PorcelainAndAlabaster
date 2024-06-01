using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using System.Text.Json.Nodes;

namespace PorcelainAndAlabaster.Controllers
{
    public class SharedController : Controller
    {
        private JsonArray GetBibRecordById(int bibRecordID)
        {
            SqlCommand scCommand = new SqlCommand("usp_CheckEmailMobile", sqlCon);
            scCommand.CommandType = CommandType.StoredProcedure;
            scCommand.Parameters.Add("@Name", SqlDbType.Int).Value = bibRecordID;
        }
    }
}
