using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Yachts_
{
    public partial class testYachts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }



            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["YachtsConnectionString"].ConnectionString);

            string sql = "SELECT [id],[Type] FROM [Yachts]";

            SqlCommand command1 = new SqlCommand(sql, connection);

            connection.Open();

            SqlDataReader reader1 = command1.ExecuteReader();

            Repeater1.DataSource = reader1;//repeater的資料來源是從rereader來

            Repeater1.DataBind();//執行繫結

            connection.Close();



            loadContent();

            LoadBanner();


        }


        private void loadContent()
        {
            LinkButton1.Enabled = false;
            LinkButton1.ForeColor = System.Drawing.Color.Black;
            LinkButton2.Enabled = true;
            LinkButton2.ForeColor = System.Drawing.Color.Blue;
            LinkButton3.Enabled = true;
            LinkButton3.ForeColor = System.Drawing.Color.Blue;

            string config = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["YachtsConnectionString"].ConnectionString; //從config找到資料庫位置

            SqlConnection connection = new SqlConnection(config);
            SqlCommand itemCommand = new SqlCommand(@"SELECT id,Type,OverviewContent,OverviewDownload,LayoutdeckplanContent,SpecificationContent FROM Yachts where id = @id", connection);//對資料庫下令的SQL語法
            if (Request["yachtsid"] == null)
            {
                itemCommand.Parameters.AddWithValue("@id", 1);
            }
            else
            {
                itemCommand.Parameters.AddWithValue("@id", Request["yachtsid"]);
            }
            connection.Open();
            SqlDataReader ItemReader = itemCommand.ExecuteReader();//使用DataReader

            if (ItemReader.Read())
            {
                Literal1.Text = HttpUtility.HtmlDecode(ItemReader["OverviewContent"].ToString());
                Label2.Text = ItemReader["Type"].ToString();
                HyperLink2.Text = ItemReader["Type"].ToString();
                HyperLink1.Text = ItemReader["OverviewDownload"].ToString();
                HyperLink1.NavigateUrl = "Yachtsupload/" + ItemReader["OverviewDownload"].ToString();

            }


            connection.Close();
        }



        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Panel1.Visible = true;

            LinkButton1.Enabled = false;
            LinkButton1.ForeColor = System.Drawing.Color.Black;
            LinkButton2.Enabled = true;
            LinkButton2.ForeColor = System.Drawing.Color.Blue;
            LinkButton3.Enabled = true;
            LinkButton3.ForeColor = System.Drawing.Color.Blue;



            //Label1.Text = "Overview";

            //string yatchid = Request.QueryString["yatchid"];

            //if (Request.QueryString["id"] != null)
            //{

            //取得  頁面 HTML 資料
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["YachtsConnectionString"].ConnectionString);

            string sql = "SELECT id,Type,OverviewContent FROM Yachts WHERE id = @id";

            SqlCommand command = new SqlCommand(sql, connection);

            if (Request["yachtsid"] == null) //預設為1
            {
                command.Parameters.AddWithValue("@id", 1);  //要寫?後面的東西
            }
            else
            {
                command.Parameters.AddWithValue("@id", Request["yachtsid"]);
            }


            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                //渲染畫面
                Literal1.Text = HttpUtility.HtmlDecode(reader["OverviewContent"].ToString());
                Label2.Text = reader["Type"].ToString();
                HyperLink2.Text = reader["Type"].ToString();
            }
            connection.Close();
            //}

        }


        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;

            LinkButton1.Enabled = true;
            LinkButton1.ForeColor = System.Drawing.Color.Blue;
            LinkButton2.Enabled = false;
            LinkButton2.ForeColor = System.Drawing.Color.Black;
            LinkButton3.Enabled = true;
            LinkButton3.ForeColor = System.Drawing.Color.Blue;




            /*Label1.Text = "Layout";*/  //要配合按鈕事件 改變label

            //取得  頁面 HTML 資料
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["YachtsConnectionString"].ConnectionString);

            string sql = "SELECT id,Type,LayoutdeckplanContent FROM Yachts WHERE id = @id";

            SqlCommand command = new SqlCommand(sql, connection);

            if (Request["yachtsid"] == null) //預設為1
            {
                command.Parameters.AddWithValue("@id", 1);  //要寫?後面的東西
            }
            else
            {
                command.Parameters.AddWithValue("@id", Request["yachtsid"]);
            }


            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                //渲染畫面
                Literal1.Text = HttpUtility.HtmlDecode(reader["LayoutdeckplanContent"].ToString());
                Label2.Text = reader["Type"].ToString();
                HyperLink2.Text = reader["Type"].ToString();
            }
            connection.Close();


        }


        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;

            LinkButton1.Enabled = true;
            LinkButton1.ForeColor = System.Drawing.Color.Blue;
            LinkButton2.Enabled = true;
            LinkButton2.ForeColor = System.Drawing.Color.Blue;
            LinkButton3.Enabled = false;
            LinkButton3.ForeColor = System.Drawing.Color.Black;



            /* Label1.Text = "Specification";*/ //要配合按鈕事件 改變label



            //取得  頁面 HTML 資料
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["YachtsConnectionString"].ConnectionString);

            string sql = "SELECT id,Type,SpecificationContent FROM Yachts WHERE id = @id";

            SqlCommand command = new SqlCommand(sql, connection);

            if (Request["yachtsid"] == null) //預設為1
            {
                command.Parameters.AddWithValue("@id", 1);  //要寫?後面的東西
            }
            else
            {
                command.Parameters.AddWithValue("@id", Request["yachtsid"]);
            }


            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                //渲染畫面
                Literal1.Text = HttpUtility.HtmlDecode(reader["SpecificationContent"].ToString());
                Label2.Text = reader["Type"].ToString();
                HyperLink2.Text = reader["Type"].ToString();
            }
            connection.Close();
        }


        private void LoadBanner()
        {

            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["YachtsConnectionString"].ConnectionString);
            string sql2 = "SELECT  Yachts.id, YachtsPhoto.yachts_photo FROM Yachts INNER JOIN YachtsPhoto ON Yachts.id = YachtsPhoto.yachts_id WHERE(Yachts.id = @id)";
            SqlCommand command2 = new SqlCommand(sql2, connection);

            if (Request["yachtsid"] == null) //預設為1
            {
                command2.Parameters.AddWithValue("@id", 1);  //要寫?後面的東西
            }
            else
            {
                command2.Parameters.AddWithValue("@id", Request["yachtsid"]);
            }



            connection.Open();
            SqlDataReader reader2 = command2.ExecuteReader();

            StringBuilder bannerHTML = new StringBuilder();
           

            while (reader2.Read())
            {
                //string Path = Server.MapPath(@"~/Yachtsupload/");
                //string imgName = reader2["yachts_photo"].ToString();
                //string Model = reader2["Type"].ToString();

                //< li >
                //    < a href = "/images/test002.jpg" >
 
                //    < img src = "/images/pit003.jpg" >
  
                //    </ a >
  
                //    </ li >


                  bannerHTML.Append($"<li style=''> <a href=\"/Yachtsupload/{reader2["yachts_photo"]}\"/ > <img src=\"/Yachtsupload/{reader2["yachts_photo"]}\"/ class='image0' style='opacity:0.7;' height='63px'> </a></li>");

          

            }



            connection.Close();

            Banner.Text = bannerHTML.ToString();


        }







    }





}

