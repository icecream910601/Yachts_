using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Yachts_
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        [Obsolete]
        protected void Button1_Click(object sender, EventArgs e)
        {

            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["YachtsConnectionString"].ConnectionString);

            string sql = "select Username,Email,Password,Rank from userinfo where Email = @Email and Password=@Password";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@Email", Email.Text);
            command.Parameters.AddWithValue("@password", BitConverter.ToString(MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(Password.Text))).Replace("-", null)); //新的方式


            connection.Open();  //連結資料庫
            SqlDataReader reader = command.ExecuteReader();  //執行指令取出資料

            if (reader.HasRows)
            {
                reader.Read(); //讀取指令 select 撈出每一筆紀錄


                //型別=自製類別
                SPerson person = new SPerson();
                person.email = reader["Email"].ToString();
                person.name = reader["Username"].ToString();
                person.Permission = reader["Rank"].ToString();

                string userData = JsonConvert.SerializeObject(person); 
                SetAuthenTicket(userData, Email.Text);

                command.Cancel();
                reader.Close();
                connection.Close(); //先關閉資源後 再來轉換頁面
                Response.Redirect("BackIndex.aspx"); //通過帳號與密碼的認證 可進入後端管理區
            }
            else
            {

                Response.Write("<Script language='JavaScript'>alert('登入失敗！');window.location.href='Login.aspx';</Script>");
                Response.End();

                command.Cancel();
                reader.Close();
                connection.Close();  //程式終止離開
                return;
            }


        }

        void SetAuthenTicket(string userData, string userId)
        {
            //宣告一個驗證票  //版本
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, userId, DateTime.Now, DateTime.Now.AddHours(3), false, userData);
            //加密驗證票
            string encryptedTicket = FormsAuthentication.Encrypt(ticket);
            //建立Cookie
            HttpCookie authenticationcookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            //將Cookie寫入回應
            Response.Cookies.Add(authenticationcookie);
            authenticationcookie.Expires = DateTime.Now.AddHours(3);

        }





    }
}