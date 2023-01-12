using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

namespace Yachts_
{
    public partial class YatchsBack : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //現在要去判斷Rank這個字串[a,b,c] 裡面有沒有關鍵字[a] 例如此頁是遊艇清單
            //目前Rank 存到 Sperson的permission 裡面了

            //string userData = JsonConvert.SerializeObject(person); 將PERSON 變成 json格式
            //將userdata抓出來
            //反序列化

            SPerson person;

            string getuserData = ((FormsIdentity)(HttpContext.Current.User.Identity)).Ticket.UserData;
            person = JsonConvert.DeserializeObject<SPerson>(getuserData); //轉型別 //物件要用<括號>
            

            string RankStr = person.Permission;
            string[] RankArr = RankStr.Split(',');

            string yachts = "遊艇清單";

            bool result = false;


            if (RankStr.Contains(yachts) == true)
            {
                result = true;
            }


            //for (int i = 0; i < RankArr.Length; i++)  /*跑打勾進來的資料*/
            //{
            //    if (RankArr[i] == yachts)
            //    {
            //        result = true;
            //    }
            //}

            //if (!User.Identity.IsAuthenticated && result)
            //{
            //    Page.ClientScript.RegisterStartupScript(Page.GetType(), "message",
            //        "<script language='javascript' defer>alert('您沒有權限拜訪此頁');</script>");
            //    Response.Redirect("Login.aspx");
            //}

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
            string sql = "SELECT * FROM [Yachts]";

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

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["YachtsConnectionString"].ConnectionString);

            string sql = "INSERT INTO Yachts(Type) VALUES(@Type)";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@Type", TextBox1.Text);

            connection.Open();

            command.ExecuteNonQuery();

            connection.Close();

            TextBox1.Text = "";


            Show();


        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            string id = GridView1.DataKeys[e.RowIndex].Value.ToString();//取得點擊這列的id

            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["YachtsConnectionString"].ConnectionString);


            //"DELETE FROM [Dealers] WHERE [country_ID] = @id; DELETE FROM [CountrySort] WHERE [id] = @id"

            string sql = "DELETE  FROM [Yachts] WHERE   (id = @id) ";
            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@id", id);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            Show();


        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            Show();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            string id = GridView1.DataKeys[e.RowIndex].Value.ToString();

            TextBox TextBox2 = (TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox2");


            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["YachtsConnectionString"].ConnectionString);

            string sql = "UPDATE [Yachts] SET Type=@Type WHERE (id=@id)";
            SqlCommand command = new SqlCommand(sql, connection);


            command.Parameters.AddWithValue("@Type", TextBox2.Text);
            command.Parameters.AddWithValue("@id", id);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();



            //command.UpdateById(id);
            GridView1.EditIndex = -1;
            Show();

        }


        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            Show();

        }

    }
}