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
    public partial class test2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }

            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["YachtsConnectionString"].ConnectionString);

            string sql = "SELECT [id],[Country] FROM [Country]";

            SqlCommand command1 = new SqlCommand(sql, connection);

            connection.Open();

            SqlDataReader reader1 = command1.ExecuteReader();


            Repeater1.DataSource = reader1;//repeater的資料來源是從rereader來

            Repeater1.DataBind();//執行繫結

            connection.Close();



            loadContent();



            //if (Request.QueryString["countryid"] != null)
            //{
            //    //string countryid = Request.QueryString["id"];

            //    string sql2 = "SELECT  id,Area, Dealerphoto,Name, Contact, Address, Tel, Fax, Email, Link FROM  [Dealers] where (Country_ID = @countryid)";

            //    SqlCommand command2 = new SqlCommand(sql2, connection);

            //    command2.Parameters.Add("@countryid", SqlDbType.NVarChar);
            //    command2.Parameters["@countryid"].Value = Request["countryid"];

            //    connection.Open();

            //    SqlDataReader reader2 = command2.ExecuteReader();



            //    Repeater2.DataSource = reader2;//repeater的資料來源是從rereader來

            //    Repeater2.DataBind();//執行繫結

            //    connection.Close();
        }


        private void loadContent()
        {


            string config = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["YachtsConnectionString"].ConnectionString; //從config找到資料庫位置

            SqlConnection connection = new SqlConnection(config);
            SqlCommand itemCommand = new SqlCommand(@"SELECT  Country,Dealers.id,Country_ID,Area, Dealerphoto,Name, Contact, Address, Tel, Fax, Email, Link FROM  [Country] INNER JOIN
                            [Dealers] ON Country.id = Dealers.Country_ID  where Dealers.Country_ID = @countryid", connection);//對資料庫下令的SQL語法

            if (Request["countryid"] == null)
            {
                itemCommand.Parameters.AddWithValue("@countryid", 5);
            }
            else
            {
                itemCommand.Parameters.AddWithValue("@countryid", Request["countryid"]);
            }

            connection.Open();

            SqlDataAdapter dataAdapter = new SqlDataAdapter(itemCommand);//取得command資料

            DataTable datatabel = new DataTable();//創立一個dataset的記憶體資料庫


            dataAdapter.Fill(datatabel);//將上面抓到的資料存入dataset內
            Repeater2.DataSource = datatabel;//repeater的資料來源是從rereader來
            Repeater2.DataBind();//執行繫結



            SqlDataReader ItemReader = itemCommand.ExecuteReader();//使用DataReader
            if (ItemReader.Read())
            {
                Label1.Text = ItemReader["Country"].ToString();
                HyperLink5.Text = ItemReader["Country"].ToString();
            }

            connection.Close();

            itemCommand.Dispose();



            //connection.Open();
            //SqlDataReader ItemReader = itemCommand.ExecuteReader();//使用DataReader


            //if (ItemReader.Read())
            //{
            //    Label1.Text = ItemReader["Country"].ToString();
            //    HyperLink5.Text = ItemReader["Country"].ToString();
            //}


            //Repeater2.DataSource = ItemReader;
            //Repeater2.DataBind();

            ////Reader 只能讀一次

            //connection.Close();

        }




    }
}




//    //SqlDataAdapter dataAdapter = new SqlDataAdapter(command2);//取得command資料

//    //DataTable datatabel = new DataTable();//創立一個dataset的記憶體資料庫
//    //dataAdapter.Fill(datatabel);//將上面抓到的資料存入dataset內
//    //Repeater2.DataSource = datatabel;//repeater的資料來源是從rereader來
//    //Repeater2.DataBind();//執行繫結

//    //command2.Dispose();

//    //上面組字串//下面用repeat
//}