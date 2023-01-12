using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Yachts_
{
    public partial class testCompany2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

            }

            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["YachtsConnectionString"].ConnectionString);
            string sql = "SELECT Certificate FROM Company WHERE id = 1";
            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                //渲染畫面
                Literal1.Text = HttpUtility.HtmlDecode(reader["Certificate"].ToString());
            }
            connection.Close();


            string sql2 = "SELECT CertificateImage FROM Certificate";
            SqlCommand command2 = new SqlCommand(sql2, connection);
            connection.Open();

            SqlDataReader reader2 = command2.ExecuteReader();

            Repeater1.DataSource = reader2;//repeater的資料來源是從rereader來

            Repeater1.DataBind();//執行繫結

            connection.Close();


        }
    }
}