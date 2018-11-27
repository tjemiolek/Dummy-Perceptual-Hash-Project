using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DPHAlgorithmProject.code
{
    public class AppUserImage
    {
        public int Id { get; set; }
        public int userId { get; set; }
        public string path { get; set; }
        public string dph { get; set; }
        public string md5 { get; set; }

        public AppUserImage(int Id, int userId, string path, string dph, string md5)
        {
            this.Id = Id;
            this.userId = userId;
            this.path = path;
            this.dph = dph;
            this.md5 = md5;
        }

        public void SaveImage()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DPHConnectionString"].ConnectionString);
            conn.Open();

            string insertQuery = "INSERT INTO [ImageData] VALUES (@uId, @path, @md5, @dph)";

            SqlCommand comm = new SqlCommand(insertQuery, conn);

            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = insertQuery;
            comm.Parameters.AddWithValue("@uId", this.userId);
            comm.Parameters.AddWithValue("@path", "appends\\" + this.path);
            comm.Parameters.AddWithValue("@md5", this.md5);
            comm.Parameters.AddWithValue("@dph", this.dph);
            try
            {
                comm.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {

            }
            conn.Close();
        }

       
    }


    public static class ImageList
    {
        public static List<AppUserImage> GetImages(int userId)
        {
            List<AppUserImage> imageList = new List<AppUserImage>();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DPHConnectionString"].ConnectionString);
            conn.Open();

            string selectQuery = "SELECT [Id],[UserId],[ImagePath],[Md5],[Dph] FROM [ImageData] WHERE [UserId]=" + userId + "";

            SqlCommand com = new SqlCommand(selectQuery, conn);
            using (SqlDataReader rdr = com.ExecuteReader())
            {
                while (rdr.Read())
                {
                    
                    int id = rdr.GetInt32(0);
                    int uId = rdr.GetInt32(1);
                    string imgPath = rdr.GetString(2);
                    string md5 = rdr.GetString(3);
                    string dph = rdr.GetString(4);
                    AppUserImage appUserImage = new AppUserImage(id, uId, imgPath, md5, dph);

                    imageList.Add(appUserImage);
                }
            }
            conn.Close();

            return imageList;
        }

        public static AppUserImage GetImage(int imageId)
        {
            AppUserImage appUImage = null;
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DPHConnectionString"].ConnectionString);
            conn.Open();

            string selectQuery = "SELECT [Id],[UserId],[ImagePath],[Md5],[Dph] FROM [ImageData] WHERE [Id]=" + imageId + "";

            SqlCommand com = new SqlCommand(selectQuery, conn);
            using (SqlDataReader rdr = com.ExecuteReader())
            {
                while (rdr.Read())
                {
                    int id = rdr.GetInt32(0);
                    int uId = rdr.GetInt32(1);
                    string imgPath = rdr.GetString(2);
                    string md5 = rdr.GetString(3);
                    string dph = rdr.GetString(4);
                    appUImage = new AppUserImage(id, uId, imgPath, md5, dph);
                }
            }
            string password = com.ExecuteScalar().ToString();
            conn.Close();

            return appUImage;
        }


        public static List<string> GetSimilarImages(int userId)
        {
            List<string> imageList = new List<string>();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DPHConnectionString"].ConnectionString);
            conn.Open();

            //string selectQuery = "SELECT [ImagePath] FROM [ImageData] WHERE [UserId]=" + userId + "";

            SqlCommand com = new SqlCommand("sp_get_similar_photo", conn);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add("@param1", SqlDbType.VarChar).Value = "11100011";

            using (SqlDataReader rdr = com.ExecuteReader())
            {
                while (rdr.Read())
                {

                    //int id = rdr.GetInt32(0);
                    //int uId = rdr.GetInt32(1);
                    string imgPath = rdr.GetString(0);
                    //string md5 = rdr.GetString(3);
                    //string dph = rdr.GetString(4);
                    //AppUserImage appUserImage = new AppUserImage(id, uId, imgPath, md5, dph);

                    imageList.Add(imgPath);
                }
            }
            string password = com.ExecuteScalar().ToString();
            conn.Close();

            return imageList;
        }

    //    //[GetSimilarPhoto]
    //    //[sp_get_similar_photo]
    //    using (SqlConnection con = new SqlConnection(dc.Con)) {
    //using (SqlCommand cmd = new SqlCommand("sp_Add_contact", con)) {
    //  cmd.CommandType = CommandType.StoredProcedure;

    //  cmd.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = txtFirstName.Text;
    //  cmd.Parameters.Add("@LastName", SqlDbType.VarChar).Value = txtLastName.Text;

    //  con.Open();
  //  //  cmd.ExecuteNonQuery();
  //  }
  //}


    }
}