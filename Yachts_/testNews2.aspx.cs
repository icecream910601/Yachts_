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
    public partial class testNews2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

            }

            string id = Request.QueryString["id"];

            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["YachtsConnectionString"].ConnectionString);
            string sql = "SELECT headline,newsContent FROM News WHERE id = @id";

            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@id", Request["id"]);

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                //渲染畫面
                Label1.Text = reader["headline"].ToString();
                Literal1.Text = HttpUtility.HtmlDecode(reader["newsContent"].ToString());
            }
            connection.Close();



        }
    }
}