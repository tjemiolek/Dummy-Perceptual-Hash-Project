using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DPHAlgorithmProject.code
{
    public static class AppUser
    {
        public static bool VerifyUser(string name, string password)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DPHConnectionString"].ConnectionString);
            conn.Open();

            string selectQuery = "SELECT [Id] FROM [UserData] WHERE UserName = @Name AND UserPassword = @Password";

            SqlCommand com = new SqlCommand(selectQuery, conn);
            com.Parameters.AddWithValue("@Name", name);
            com.Parameters.AddWithValue("@Password", password);

            var loginResult = com.ExecuteScalar();

            conn.Close();
            int loginResultVal = 0;

            if (loginResult != null)
            {
                loginResultVal = Convert.ToInt32(loginResult.ToString());
                HttpContext.Current.Session["UserId"] = loginResultVal;
                return true;
            }
            else
            {
                return false;
            }
            }
        }
    }