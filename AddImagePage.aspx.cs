using DPHAlgorithmProject.code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DPHAlgorithmProject
{
    public partial class AddImagePage : System.Web.UI.Page
    {
        public int userID;

        protected void Page_Load(object sender, EventArgs e)
        {
            userID = (int)HttpContext.Current.Session["UserId"];
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            FileUpload1.SaveAs(Server.MapPath("appends\\" + FileUpload1.FileName));

            string md5 = Md5Encoder.EncodeMD5(Server.MapPath("appends\\" + FileUpload1.FileName));
            byte randomDPH = DPHGenerator.GenerateDPH();
            string stringRandomDPH = ByteConverter.ByteToBinaryString(randomDPH);

            AppUserImage userImage = new AppUserImage(0 ,userID, FileUpload1.FileName, stringRandomDPH, md5);
            userImage.SaveImage();

            Response.Redirect("FotoPage.aspx");
        }
    }
}