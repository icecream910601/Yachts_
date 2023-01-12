using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Yachts_
{
    public partial class UserInsert : System.Web.UI.Page
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




        }

        [Obsolete]
        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["YachtsConnectionString"].ConnectionString);

            string sql = "select Email from [userinfo] where Email=@Email";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@Email", Email.Text);

            connection.Open();

            SqlDataReader datareader = command.ExecuteReader();

            if (datareader.HasRows)
            {
                Response.Write("<Script language='JavaScript'>alert('已有此Email');window.location.href='UserInser.aspx';</Script>");
                Response.End();
                connection.Close();

            }
            else
            {
                if (Regex.IsMatch(Email.Text, @"^[A-Za-z0-9_\-\.\+]*[@][a-z]*[.][a-z]*(.[a-z]*)$") && Regex.IsMatch(Password.Text, @"^[a-zA-Z0-9]{6,10}") && Regex.IsMatch(Birthdate.Text, @"^\d{4}-\d{2}-\d{2}$"))
                {

                    datareader.Close();

                    string sql2 = "INSERT INTO [userinfo](Username,Email,Password,Sex,Birthdate,Phone,Address,Rank) VALUES(@Username,@Email,@Password,@Sex,@Birthdate,@Phone,@Address,@Rank)";

                    SqlCommand command2 = new SqlCommand(sql2, connection);



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




                    command2.Parameters.AddWithValue("@Username", Username.Text);
                    command2.Parameters.AddWithValue("@Email", Email.Text);


                    command2.Parameters.AddWithValue("@Password", FormsAuthentication.HashPasswordForStoringInConfigFile(Password.Text, "MD5"));

                    //command2.Parameters.AddWithValue("@Password", Password.Text);

                    command2.Parameters.AddWithValue("@Sex", Sex.Text);
                    command2.Parameters.AddWithValue("@Birthdate", Birthdate.Text);
                    command2.Parameters.AddWithValue("@Phone", Phone.Text);
                    command2.Parameters.AddWithValue("@Address", Address.Text);
                    command2.Parameters.AddWithValue("@Rank", Rank);

                    //connection.Open();
                    command2.ExecuteNonQuery();  //傳回受影響的資料列數
                    connection.Close();

                    Response.Write("<Script language='JavaScript'>alert('新增完成');window.location.href='Permission.aspx';</Script>");
                    Response.End();



                }
                else
                {
                    Label1.Text = "無效的Email或密碼/生日格式錯誤";

                }






            }






        }


    }



}