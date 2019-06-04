using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using TAS_Group4_WebApplication.Models;
using System.Text;
using System.Diagnostics;



namespace TAS_Group4_WebApplication.Controllers
{
    public class AccountController : Controller
    {   
        string Username;
        string Type;
        

        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            return View(new Login());
        }

        [HttpPost]
        public ActionResult Verify(string username, string password)
        {
            // Connect to SQL Server
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "inc382.database.windows.net";
            builder.UserID = "inc382";
            builder.Password = "INC@kmutt";
            builder.InitialCatalog = "inc382_group_4";

            using (SqlConnection connection = new
               SqlConnection(builder.ConnectionString))
            {
                connection.Open();
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT * FROM dbo.Login");
                String sql = sb.ToString();
                SqlCommand command = new SqlCommand(sql, connection);
                command.CommandText = "SELECT * FROM dbo.Login WHERE CONVERT(VARCHAR, AgentUsername) = '" + username + "'and CONVERT(VARCHAR, AgentPassword) = '" + password + "'";
                SqlDataReader reader = command.ExecuteReader();

                // DEBUG
                Debug.WriteLine(username);
                Debug.WriteLine(password);
                Debug.WriteLine(command.CommandText);

                // Check Status
                while (reader.Read())
                {
                    Username = Convert.ToString(reader.GetValue(1));
                    Type = Convert.ToString(reader.GetValue(5));
                }
                Debug.WriteLine(Type);

                Session["username"] = Username;

               
                if (Type == "Operator") // Welcome Operator
                {
                    
                    Session["status"] = 1; // Session - Throw some fucking data 
                    connection.Close();
                    ViewData["username"] = Session["username"];
                    ViewData["status"] = Session["status"];
                    //return View("~/Views/Dashboard/DashboardOperator.cshtml");
                    return RedirectToAction("DashboardOperator", "Dashboard");
                }
                else if(Type == "Manager") // Welcome Manager
                {
                    Session["status"] = 2; // Session - Throw some fucking d   ata 
                    connection.Close();
                    ViewData["username"] = Session["username"];
                    ViewData["status"] = Session["status"];
                    //return View("~/Views/Dashboard/DashboardOperator.cshtml");
                    return RedirectToAction("DashboardManager", "Dashboard");

                }
                else // Failed
                {
                    Session["status"] = 0; // Session - Throw some fucking data 
                    connection.Close();
                    ViewData["status"] = Session["status"];
                    return View("Failed");
                }
                      
            }

            

        }
    }
}