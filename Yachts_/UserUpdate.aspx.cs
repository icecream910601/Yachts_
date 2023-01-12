using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Yachts_
{
    public partial class UserUpdate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            SPerson person;

            string getuserData = ((FormsIdentity)(HttpContext.Current.User.Identity)).Ticket.UserData;
            person = JsonConvert.DeserializeObject<SPerson>(getuserData); //轉型別 //物件要用<括號>


            string RankString = person.Permission;
            string[] RankArray = RankString.Split(',');

            string yachts = "帳號權限";

            bool result = false;


            if (RankString.Contains(yachts) == true)
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

                

                string id = Request.QueryString["id"];//取得網址上的內容並存成字串

                string config = System.Web.Configuration.WebConfigurationManager
                                   .ConnectionStrings["YachtsConnectionString"].ConnectionString;
                SqlConnection connection = new SqlConnection(config);
                SqlCommand Command = new SqlCommand($"SELECT Username,Email,Password,Sex,Birthdate,Phone,Address,Rank  FROM [userinfo] where(id =@id)", connection);


                Command.Parameters.AddWithValue("@id", Request["id"]);   //讓網址的id變成參數的值

                connection.Open();

                SqlDataReader reader = Command.ExecuteReader();//使用DataReader

                if (reader.Read())//每讀入一行(這邊只會讀進一行因為SQL下的條件只會取得一筆資料)
                {
                    Username.Text = reader["Username"].ToString();
                    Label2.Text = reader["Email"].ToString();
                    //Password.Text = reader["Password"].ToString();
                    Sex.Text = reader["Sex"].ToString();
                    Birthdate.Text = reader["Birthdate"].ToString();
                    Phone.Text = reader["Phone"].ToString();
                    Address.Text = reader["Address"].ToString();

                    //如何從SQL選出Checkboxlist數值

                    string RankStr = reader["Rank"].ToString();
                    string[] RankArr = RankStr.Split(',');

                    //跑陣列的位置 跟 checkboxlist的位置去比對是不是符合的
                    for (int i = 0; i < RankArr.Length; i++)//给CheckBoxList选中的复选框 赋值
                    {
                        for (int j = 0; j < CheckBoxList1.Items.Count; j++)
                        {
                            if (RankArr[i].ToString() == CheckBoxList1.Items[j].Text)
                            {
                                CheckBoxList1.Items[j].Selected = true;
                            }
                        }
                    }

                    //將取得留言資料的標題放在標題的Text,//意同前面加上字串"RE:"

                }

                connection.Close();




            }

        }

        [Obsolete]
        protected void Button1_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];

            string config = System.Web.Configuration.WebConfigurationManager
                                   .ConnectionStrings["YachtsConnectionString"].ConnectionString;
            SqlConnection connection = new SqlConnection(config);

            SqlCommand command = new SqlCommand($"UPDATE [userinfo] SET Username=@Username,Password=@Password,@Sex=Sex, Birthdate=@Birthdate,Phone=@Phone,Address=@Address,Rank=@Rank WHERE (id=@id)", connection);


            //將選取到的Checkboxlist組字串 存到資料庫
            string Rank = "";
            for (int i = 0; i < CheckBoxList1.Items.Count; i++)
            {
                if (CheckBoxList1.Items[i].Selected == true)
                {
                    Rank += CheckBoxList1.Items[i].Value + ",";
                }
            }
            Rank = Rank.TrimEnd(',');




            command.Parameters.AddWithValue("@id", Request["id"]);
            command.Parameters.AddWithValue("@Username", Username.Text);
            command.Parameters.AddWithValue("@password", FormsAuthentication.HashPasswordForStoringInConfigFile(Password.Text, "MD5"));
            command.Parameters.AddWithValue("@Sex", Sex.Text);
            command.Parameters.AddWithValue("@Birthdate", Birthdate.Text);
            command.Parameters.AddWithValue("@Phone", Phone.Text);
            command.Parameters.AddWithValue("@Address", Address.Text);
            command.Parameters.AddWithValue("@Rank", Rank);


            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            Response.Redirect($"Permission.aspx");

        }
    }
}