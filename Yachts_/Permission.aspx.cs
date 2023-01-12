using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Yachts_
{
    public partial class Permission : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            SPerson person;

            string getuserData = ((FormsIdentity)(HttpContext.Current.User.Identity)).Ticket.UserData;
            person = JsonConvert.DeserializeObject<SPerson>(getuserData); //轉型別 //物件要用<括號>


            string RankStr = person.Permission;
            string[] RankArr = RankStr.Split(',');

            string yachts = "帳號權限";

            bool result = false;


            if (RankStr.Contains(yachts) == true)
            {
                result = true;
            }


            if (User.Identity.IsAuthenticated == false || result == false)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "message",
                    "<script language='javascript' defer>alert('您沒有權限拜訪此頁');</script>");
                Response.Redirect("BackIndex.aspx");
            }




            if (!IsPostBack)
            {
               
                    Show();
                

            }
        }

        private void Show()
        {
            //1.連線資料庫
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["YachtsConnectionString"].ConnectionString);

            //2.執行sql語法
            string sql = "SELECT * FROM [userinfo]";

            //3.創建command物件
            SqlCommand command = new SqlCommand(sql, connection);

            //4.資料庫連線開啟
            connection.Open();

            //5.執行sql (連線的作法-需自行關閉)
            SqlDataReader reader = command.ExecuteReader();
            //DataReader速度快只能逐筆單向有上往下而且不能計算，適合用來抓單筆資料
            //控制器資料來源
            GridView1.DataSource = reader; //(拿資料)
                                           //控制器綁定 (真的把資料放進去)
            GridView1.DataBind();

            //6.資料庫關閉
            connection.Close();
        }

        //在後置程式碼中拿掉象徵老闆 ID 1 的刪除鍵避免老闆刪除自己
        protected void GridView1_DataBound(object sender, EventArgs e)
        {
            GridView1.Rows[0].Cells[4].Controls.Clear();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            string id = GridView1.DataKeys[e.RowIndex].Value.ToString();//取得點擊這列的id

            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["YachtsConnectionString"].ConnectionString);


            string sql = "DELETE  FROM [userinfo] WHERE   (id = @id) ";
            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@id", id);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            Response.Redirect("Permission.aspx");



        }


    }
}