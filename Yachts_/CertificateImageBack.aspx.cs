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
    public partial class CertificateImage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SPerson person;

            string getuserData = ((FormsIdentity)(HttpContext.Current.User.Identity)).Ticket.UserData;
            person = JsonConvert.DeserializeObject<SPerson>(getuserData); //轉型別 //物件要用<括號>


            string RankStr = person.Permission;
            string[] RankArr = RankStr.Split(',');

            string yachts = "公司資料";

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
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["YachtsConnectionString"].ConnectionString);

            string sql = "SELECT * FROM [Certificate]";

            SqlCommand command = new SqlCommand(sql, connection);


            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);//取得command資料

            DataSet dataset = new DataSet();//創立一個dataset的記憶體資料庫

            dataAdapter.Fill(dataset);//將上面抓到的資料存入dataset內

            GridView1.DataSource = dataset;//DataSource的資料來源是dataset or datatable

            GridView1.DataBind();//資料與欄位合在一起


        }

        protected void UploadHBtn_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["YachtsConnectionString"].ConnectionString);

            string savePath = Server.MapPath(@"~/Companyupload/");

            if (imageUpload.FileName.Length > 0 && imageUpload.HasFile)
            {

                string fileName = imageUpload.FileName;
                savePath = savePath + fileName;
                imageUpload.SaveAs(savePath);

                SqlCommand command = new SqlCommand($" INSERT INTO Certificate (CertificateImage ) VALUES (@CertificateImage) ", connection);

                command.Parameters.AddWithValue("@CertificateImage", fileName);

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

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            string id = GridView1.DataKeys[e.RowIndex].Value.ToString();//取得點擊這列的id

            string get = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["YachtsConnectionString"].ConnectionString;
            SqlConnection Connection = new SqlConnection(get);

            SqlCommand command = new SqlCommand($"DELETE  FROM Certificate WHERE  (id = @id) ", Connection);
            command.Parameters.AddWithValue("@id", id);


            Connection.Open();
            command.ExecuteNonQuery();
            Connection.Close();

            Show();

        }
    }
}