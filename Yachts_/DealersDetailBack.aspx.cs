using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Yachts_
{
    public partial class DealersDetailBack : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {



            SPerson person;

            string getuserData = ((FormsIdentity)(HttpContext.Current.User.Identity)).Ticket.UserData;
            person = JsonConvert.DeserializeObject<SPerson>(getuserData); //轉型別 //物件要用<括號>


            string RankStr = person.Permission;
            string[] RankArr = RankStr.Split(',');

            string yachts = "代理商資料";

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
            string countryid = Request.QueryString["countryid"];

            //1.連線資料庫
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["YachtsConnectionString"].ConnectionString);

            //2.執行sql語法
            string sql = "SELECT * FROM [Dealers] WHERE(Country_ID = @countryid)";

            //3.創建command物件
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@countryid", Request["countryid"]);


            if (Request["itemId"] != null)

            {
                Button1.Text = "修改";

                SqlCommand itemCommand = new SqlCommand(@"SELECT  Area, Dealerphoto,Name, Contact, Address, Tel, Fax, Email, Link FROM  [Dealers] where (id = @countryid)", connection);

                itemCommand.Parameters.AddWithValue("@countryid", Request["itemId"]);

                connection.Open();

                SqlDataReader reader = itemCommand.ExecuteReader();//使用DataReader


                if (reader.Read())
                {
                    Area.Text = reader["Area"].ToString();
                    Name.Text = reader["Name"].ToString();
                    Contact.Text = reader["Contact"].ToString();
                    Address.Text = reader["Address"].ToString();
                    Tel.Text = reader["Tel"].ToString();
                    Fax.Text = reader["Fax"].ToString();
                    Email.Text = reader["Email"].ToString();
                    Link.Text = reader["Link"].ToString();
                }
                connection.Close();

            }

            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);//取得command資料

            DataSet dataset = new DataSet();//創立一個dataset的記憶體資料庫

            dataAdapter.Fill(dataset);//將上面抓到的資料存入dataset內

            GridView1.DataSource = dataset;//DataSource的資料來源是dataset or datatable

            GridView1.DataBind();//資料與欄位合在一起


        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Request["itemId"] == null)
            {

                SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["YachtsConnectionString"].ConnectionString);

                string path = Server.MapPath(@"~/Dealersphoto/");



                if (FileUpload1.HasFile)
                {

                    string fileName = FileUpload1.FileName;
                    path = path + fileName;
                    FileUpload1.SaveAs(path);


                    SqlCommand command = new SqlCommand($" INSERT INTO Dealers ( Country_ID, Area, Dealerphoto, Name, Contact, Address, Tel, Fax, Email, Link ) VALUES ( @Country_ID, @Area, @Dealerphoto, @Name, @Contact, @Address, @Tel, @Fax, @Email, @Link ) ", connection);

                    command.Parameters.AddWithValue("@Country_ID", Request["countryid"]);
                    command.Parameters.AddWithValue("@Area", Area.Text);
                    command.Parameters.AddWithValue("@Dealerphoto", fileName);
                    command.Parameters.AddWithValue("@Name", Name.Text);
                    command.Parameters.AddWithValue("@Contact", Contact.Text);
                    command.Parameters.AddWithValue("@Address", Address.Text);
                    command.Parameters.AddWithValue("@Tel", Tel.Text);
                    command.Parameters.AddWithValue("@Fax", Fax.Text);
                    command.Parameters.AddWithValue("@Email", Email.Text);
                    command.Parameters.AddWithValue("@Link", Link.Text);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                    Show();
                }
                else
                {

                    Label1.Text = "請先挑選檔案再上傳";
                }

            }
            else
            {


                SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["YachtsConnectionString"].ConnectionString);

                string path = Server.MapPath(@"~/Dealersphoto/");

                if (FileUpload1.HasFile)
                {
                    string fileName = FileUpload1.FileName;
                    path = path + fileName;
                    FileUpload1.SaveAs(path);

                    SqlCommand command2 = new SqlCommand($"UPDATE  Dealers SET  Area=@Area, Name=@Name,Dealerphoto=@Dealerphoto, Contact=@Contact, Address=@Address, Tel=@Tel, Fax=@Fax, Email=@Email, Link=@Link where id = @itemId ", connection);



                    command2.Parameters.AddWithValue("@itemId", Request["itemId"]);
                    command2.Parameters.AddWithValue("@Area", Area.Text);
                    command2.Parameters.AddWithValue("@Dealerphoto", fileName);
                    command2.Parameters.AddWithValue("@Name", Name.Text);
                    command2.Parameters.AddWithValue("@Contact", Contact.Text);
                    command2.Parameters.AddWithValue("@Address", Address.Text);
                    command2.Parameters.AddWithValue("@Tel", Tel.Text);
                    command2.Parameters.AddWithValue("@Fax", Fax.Text);
                    command2.Parameters.AddWithValue("@Email", Email.Text);
                    command2.Parameters.AddWithValue("@Link", Link.Text);

                    connection.Open();//開啟通道
                    command2.ExecuteNonQuery();//執行command的SQL語法，回傳受影響的資料數目
                    connection.Close();//關閉通道

                    Show();

                }

                else
                {
                    SqlCommand command2 = new SqlCommand($"DECLARE  @Dealerphoto nvarchar(MAX)  SET  @Dealerphoto = (SELECT Dealerphoto FROM Dealers WHERE id = @itemId) UPDATE  Dealers SET Area = @Area, Name = @Name, Contact = @Contact, Address = @Address, Tel = @Tel, Fax = @Fax, Email = @Email, Link = @Link,Dealerphoto=(CASE WHEN(Dealerphoto IS NULL OR Dealerphoto = '') then @Dealerphoto ELSE(Dealerphoto)END)WHERE id = @itemId ", connection);
                    //Label1.Text = "請先挑選檔案再上傳";


                    command2.Parameters.AddWithValue("@itemId", Request["itemId"]);
                    command2.Parameters.AddWithValue("@Area", Area.Text);
                    //command2.Parameters.AddWithValue("@Dealerphoto", fileName);
                    command2.Parameters.AddWithValue("@Name", Name.Text);
                    command2.Parameters.AddWithValue("@Contact", Contact.Text);
                    command2.Parameters.AddWithValue("@Address", Address.Text);
                    command2.Parameters.AddWithValue("@Tel", Tel.Text);
                    command2.Parameters.AddWithValue("@Fax", Fax.Text);
                    command2.Parameters.AddWithValue("@Email", Email.Text);
                    command2.Parameters.AddWithValue("@Link", Link.Text);

                    connection.Open();//開啟通道
                    command2.ExecuteNonQuery();//執行command的SQL語法，回傳受影響的資料數目
                    connection.Close();//關閉通道

                    Show();


                }



            }


        }


        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            string id = GridView1.DataKeys[e.RowIndex].Value.ToString();//取得點擊這列的id

            string get = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["YachtsConnectionString"].ConnectionString;
            SqlConnection Connection = new SqlConnection(get);

            SqlCommand command = new SqlCommand($"DELETE  FROM Dealers WHERE  (id = @id) ", Connection);
            command.Parameters.AddWithValue("@id", id);

            Connection.Open();
            command.ExecuteNonQuery();
            Connection.Close();

            Show();

        }


        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            string itemId = GridView1.DataKeys[e.NewEditIndex].Value.ToString();//取得點擊這列的id
            Response.Redirect($"DealersDetailBack.aspx?countryid={Request["countryid"]}&itemId={itemId}");

        }

    }
}
