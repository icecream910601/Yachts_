using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Yachts_
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            LoadBanner();

            if (!IsPostBack)
            {

            }
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["YachtsConnectionString"].ConnectionString);

            string sql = "select Top 3* from[dbo].[News] Order by isTop Desc,date Desc";

            SqlCommand command = new SqlCommand(sql, connection);


            connection.Open();

            SqlDataReader reader1 = command.ExecuteReader();

            Repeater1.DataSource = reader1;//repeater的資料來源是從rereader來

            Repeater1.DataBind();//執行繫結

            connection.Close();

            LoadBanner();

        }


        private void LoadBanner()
        {

            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["YachtsConnectionString"].ConnectionString);
            string sql2 = "SELECT   Yachts.Type, YachtsPhoto.yachts_photo, YachtsPhoto.isCover FROM Yachts INNER JOIN YachtsPhoto ON Yachts.id = YachtsPhoto.yachts_id WHERE(YachtsPhoto.isCover = 1) ";
            SqlCommand command2 = new SqlCommand(sql2, connection);

            connection.Open();
            SqlDataReader reader2 = command2.ExecuteReader();

            StringBuilder bannerHTML = new StringBuilder();
            StringBuilder bannerHTML2 = new StringBuilder();

            while (reader2.Read())
            {
                //string Path = Server.MapPath(@"~/Yachtsupload/");
                //string imgName = reader2["yachts_photo"].ToString();
                //string Model = reader2["Type"].ToString();

                bannerHTML.Append($"<li class='info on' style='border-radius:5px;height:424px;width:978px'><a href=''>  <img src=\"/Yachtsupload/{reader2["yachts_photo"]}\"/></a> <div class='wordtitle'> {reader2["Type"].ToString()}<br />  <p>SPECIFICATION SHEET</p> </div> </li>");

                bannerHTML2.Append($"<li class='on'><div> <p class='bannerimg_p'>  <img src=\"/Yachtsupload/{reader2["yachts_photo"]}\"  alt='& quot; &quot; '/> </p> </div> </li> ");

            }





            connection.Close();

            Literal1.Text = bannerHTML.ToString();

            Literal2.Text = bannerHTML2.ToString();

        }


    }
}