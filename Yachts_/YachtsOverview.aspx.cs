using CKFinder;
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
    public partial class YatchsDetailBack : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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


            if (User.Identity.IsAuthenticated == false || result == false)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "message",
                    "<script language='javascript' defer>alert('您沒有權限拜訪此頁');</script>");
                Response.Redirect("BackIndex.aspx");
            }



            if (!IsPostBack)
            {

                FileBrowser fileBrowser = new FileBrowser();
                fileBrowser.BasePath = "/ckfinder";
                fileBrowser.SetupCKEditor(CKEditorControl1);
                loadOverviewContent();

                Show();
       

            }


        }

        private void loadOverviewContent()
        {

            LinkButton1.Enabled = false;
            LinkButton1.ForeColor = System.Drawing.Color.Black;
            LinkButton2.Enabled = true;
            LinkButton2.ForeColor = System.Drawing.Color.Blue;
            LinkButton3.Enabled = true;
            LinkButton3.ForeColor = System.Drawing.Color.Blue;


            Label1.Text = "Overview";
            Panel1.Visible = true;

            //string yatchid = Request.QueryString["yatchid"];

            //取得  頁面 HTML 資料
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["YachtsConnectionString"].ConnectionString);

            string sql = "SELECT OverviewContent FROM Yachts WHERE id = @id";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@id", Request["yatchid"]);  //要寫?後面的東西

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                //渲染畫面
                CKEditorControl1.Text = HttpUtility.HtmlDecode(reader["OverviewContent"].ToString());
            }
            connection.Close();

        }

        protected void UploadOverviewBtn_Click(object sender, EventArgs e)
        {

            if (Label1.Text == "Overview")  //要配合按鈕事件 改變label
            {
                //取得 CKEditorControl 的 HTML 內容
                string CKstr = HttpUtility.HtmlEncode(CKEditorControl1.Text);

                //更新 About Us 頁面 HTML 資料
                SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["YachtsConnectionString"].ConnectionString);
                string sql = "UPDATE Yachts SET OverviewContent = @OverviewContent WHERE id = @id";


                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@OverviewContent", CKstr);
                command.Parameters.AddWithValue("@id", Request["yatchid"]);


                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                ////渲染畫面提示
                //DateTime nowtime = DateTime.Now;
                //UploadOverviewTime.Visible = true;
                //UploadOverviewTime.Text = "*Upload Success! - " + nowtime.ToString("G");
            }
            if (Label1.Text == "Layout")
            {
                //取得 CKEditorControl 的 HTML 內容
                string CKstr = HttpUtility.HtmlEncode(CKEditorControl1.Text);

                //更新 About Us 頁面 HTML 資料
                SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["YachtsConnectionString"].ConnectionString);
                string sql = "UPDATE Yachts SET LayoutdeckplanContent = @LayoutdeckplanContent WHERE id = @id";


                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@LayoutdeckplanContent", CKstr);
                command.Parameters.AddWithValue("@id", Request["yatchid"]);


                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

            }

            if (Label1.Text == "Specification")
            {

                //取得 CKEditorControl 的 HTML 內容
                string CKstr = HttpUtility.HtmlEncode(CKEditorControl1.Text);

                //更新 About Us 頁面 HTML 資料
                SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["YachtsConnectionString"].ConnectionString);
                string sql = "UPDATE Yachts SET SpecificationContent = @SpecificationContent WHERE id = @id";


                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@SpecificationContent", CKstr);
                command.Parameters.AddWithValue("@id", Request["yatchid"]);


                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

            }

        }



        protected void LinkButton1_Click(object sender, EventArgs e)
        {

            loadOverviewContent();

        }


        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;

            LinkButton1.Enabled = true;
            LinkButton1.ForeColor = System.Drawing.Color.Blue;
            LinkButton2.Enabled = false;
            LinkButton2.ForeColor = System.Drawing.Color.Black;
            LinkButton3.Enabled = true;
            LinkButton3.ForeColor = System.Drawing.Color.Blue;


            Label1.Text = "Layout";  //要配合按鈕事件 改變label

            //取得  頁面 HTML 資料
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["YachtsConnectionString"].ConnectionString);

            string sql = "SELECT LayoutdeckplanContent FROM Yachts WHERE id = @id";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@id", Request["yatchid"]);  //要寫連結?後面的東西

           connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                //渲染畫面
                CKEditorControl1.Text = HttpUtility.HtmlDecode(reader["LayoutdeckplanContent"].ToString());
            }
            connection.Close();

        }


        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;

            LinkButton1.Enabled = true;
            LinkButton1.ForeColor = System.Drawing.Color.Blue;
            LinkButton2.Enabled = true;
            LinkButton2.ForeColor = System.Drawing.Color.Blue;
            LinkButton3.Enabled = false;
            LinkButton3.ForeColor = System.Drawing.Color.Black;

            Label1.Text = "Specification"; //要配合按鈕事件 改變label

            //取得  頁面 HTML 資料
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["YachtsConnectionString"].ConnectionString);

            string sql = "SELECT SpecificationContent FROM Yachts WHERE id = @id";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@id", Request["yatchid"]);  //要寫?後面的東西

            connection.Open();

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                //渲染畫面
                CKEditorControl1.Text = HttpUtility.HtmlDecode(reader["SpecificationContent"].ToString());
            }
            connection.Close();


        }

        protected void UploadHBtn_Click(object sender, EventArgs e)
        {

 

                SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["YachtsConnectionString"].ConnectionString);

                //取出所選檔案的本地路徑
                string fullFileName = this.FileUpload1.PostedFile.FileName;
                //從路徑中截取出檔名
                string fileName = fullFileName.Substring(fullFileName.LastIndexOf("\\") + 1);
                //限定上傳檔案的格式
                string type = fullFileName.Substring(fullFileName.LastIndexOf(".") + 1);
                if (type == "doc" || type == "docx" || type == "xls" || type == "xlsx" || type == "ppt" || type == "pptx" || type == "pdf" || type == "jpg" || type == "bmp" || type == "gif" || type == "png" || type == "txt" || type == "zip" || type == "rar")
                {
                    //將檔案儲存在伺服器中根目錄下的files資料夾中
                    string saveFileName = Server.MapPath(@"~/Yachtsupload/") + "\\" + fileName;
                    FileUpload1.PostedFile.SaveAs(saveFileName);
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('檔案上傳成功！');</script>");

                    ////向資料庫中儲存相應通知的附件的目錄
                    //BLL.news.InsertAnnexBLL insertAnnex = new BLL.news.InsertAnnexBLL();
                    //AnnexEntity annex = new AnnexEntity();     //建立附件的實體
                    //annex.AnnexName = fileName;               //附件名
                    //annex.AnnexContent = saveFileName;        //附件的儲存路徑
                    //annex.NoticeId = noticeId;              //附件所屬“通知”的ID在這裡為已知
                    //insertAnnex.InsertAnnex(annex);         //將實體存入資料庫（其實就是講實體的這些屬性insert到資料庫中的過程，具體BLL層和DAL層的程式碼這裡不再多說）

                    SqlCommand command = new SqlCommand($" UPDATE Yachts  SET  OverviewDownload =@OverviewDownload  where id = @id ", connection);

                    command.Parameters.AddWithValue("@OverviewDownload", fileName);
                    command.Parameters.AddWithValue("@id", Request["yatchid"]);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                    Show();

                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script language='javascript' defer>alert('請選擇正確的格式');</script>");
                }
      

        }


        private void Show()
        {
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["YachtsConnectionString"].ConnectionString);

            string sql = "SELECT * FROM [Yachts] where id= @id";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@id", Request["yatchid"]);

            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);//取得command資料

            DataSet dataset = new DataSet();//創立一個dataset的記憶體資料庫

            dataAdapter.Fill(dataset);//將上面抓到的資料存入dataset內

            GridView1.DataSource = dataset;//DataSource的資料來源是dataset or datatable

            GridView1.DataBind();//資料與欄位合在一起


        }





    }
}