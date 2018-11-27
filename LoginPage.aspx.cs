using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DPHAlgorithmProject.code;

namespace DPHAlgorithmProject
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            if(AppUser.VerifyUser(Login1.UserName, Login1.Password))
            {
                //Authorization.GetToken();
                //res.header('x-authorization', "Bearer " + JWT);
                //Response.AddHeader("x-authorization", "Bearer " + "12345Kowalski");
                Response.Redirect("FotoPage.aspx");
                //Response.Redirect("FotoPage.aspx#token=${jwt}");
                //res.redirect(307, `http://appServer:5001/?key=value#token=${jwt}`)
            }
            else
            {
                e.Authenticated = false;
            } 
        }

        protected void Login1_LoginError(object sender, EventArgs e)
        {
            Login1.FailureText = "Błędne hasło lub login.";
        }
    }
}