using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DPHAlgorithmProject.code;

namespace DPHAlgorithmProject
{
    public partial class FotoPage : System.Web.UI.Page
    {
        public int userID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(HttpContext.Current.Session["UserId"] != null)
            {
                userID = (int)HttpContext.Current.Session["UserId"];
            }
            else
            {
                Response.Redirect("LoginPage.aspx");
            }

            List<AppUserImage> imageList = ImageList.GetImages(userID);

            Panel p = new Panel();
            p.CssClass = "ImageClass";

            if(imageList.Count > 0)
            {
                for (int i = 0; i < imageList.Count; i++)
                {
                    System.Web.UI.WebControls.Image img = new System.Web.UI.WebControls.Image();         
                    img.CssClass = "img-thumbnail";
                    img.ImageUrl = imageList[i].path.Trim();
                    img.Attributes.Add("base-index", imageList[i].Id.ToString());
                    string redirectUrl = "ChoosenPhoto.aspx?id=" + imageList[i].Id.ToString();
                    img.Attributes.Add("onclick", "window.location(" + "'" + redirectUrl + "'" + ")");
                    p.Controls.Add(img);
                }
            }


//            In Page1.aspx

//Response.Redirect("Page2.aspx?param1=Test");

//            In Page2.aspx

//if (Request.QueryString["param1"] != null)
//                Response.Write("From Page1 param1 value=" + Request.QueryString["param1"]);


            //Label l = new Label();
            //l.Attributes.Add("background", "appends\\default_banner.png");
            //p.Controls.Add(img);
            //p.Controls.Add(l);
            GalleryBodyPanel.Controls.Add(p);
  
        }

    }
}