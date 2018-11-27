using DPHAlgorithmProject.code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DPHAlgorithmProject
{
    public partial class ChoosenPhoto : System.Web.UI.Page
    {
        int photoId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            string urlId = Request.QueryString["Id"];
            if (urlId != null)
            {
                photoId = Int32.Parse(urlId);
                var aaa = "";

                AppUserImage appUImage = ImageList.GetImage(photoId);
                System.Web.UI.WebControls.Image mainImg = new System.Web.UI.WebControls.Image();
                mainImg.ImageUrl = appUImage.path.Trim();
                MainPhoto.Controls.Add(mainImg);

                List<string> similarPhoto = ImageList.GetSimilarImages(1);

                Panel p = new Panel();
                p.CssClass = "ImageClass";

                if (similarPhoto.Count > 0)
                {
                    for (int i = 0; i < similarPhoto.Count; i++)
                    {
                        System.Web.UI.WebControls.Image img = new System.Web.UI.WebControls.Image();
                        img.CssClass = "img-thumbnail";
                        img.ImageUrl = similarPhoto[i].Trim();
                        p.Controls.Add(img);
                    }
                }

                SimilarPhoto.Controls.Add(p);
                var x = "sadasdasdasd";
            }
        }
    }
}