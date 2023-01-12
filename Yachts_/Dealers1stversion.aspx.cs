using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Yachts_
{
    public partial class Dealers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["YachtsConnectionString"].ConnectionString);

            string sql = "SELECT [id],[Country] FROM [Country]";

            SqlCommand command1 = new SqlCommand(sql, connection);

            connection.Open();

            SqlDataReader reader = command1.ExecuteReader();


            while (reader.Read())
            {

                Label1.Text += $"<a href=\"Dealers.aspx?countryid={reader["id"]}\"> {reader["Country"]}";

            }


            connection.Close();



            if (Request.QueryString["countryid"] != null)
            {
                string countryid = Request.QueryString["id"];

                string sql2 = "SELECT  id,Area, Dealerphoto,Name, Contact, Address, Tel, Fax, Email, Link FROM  [Dealers] where (Country_ID = @countryid)";

                SqlCommand command2 = new SqlCommand(sql2, connection);

                command2.Parameters.Add("@countryid", SqlDbType.NVarChar);
                command2.Parameters["@countryid"].Value = Request["countryid"];

                connection.Open();

                SqlDataReader reader2 = command2.ExecuteReader();

                Repeater1.DataSource = reader2;//repeater的資料來源是從rereader來

                Repeater1.DataBind();//執行繫結

                connection.Close();

                //SqlDataAdapter dataAdapter = new SqlDataAdapter(command2);//取得command資料

                //DataTable datatabel = new DataTable();//創立一個dataset的記憶體資料庫
                //dataAdapter.Fill(datatabel);//將上面抓到的資料存入dataset內
                //Repeater2.DataSource = datatabel;//repeater的資料來源是從rereader來
                //Repeater2.DataBind();//執行繫結

                //command2.Dispose();

                //上面組字串//下面用repeat
            }





        }
    }
}