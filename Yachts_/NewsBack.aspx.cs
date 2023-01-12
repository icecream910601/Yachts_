using CKFinder;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Yachts_
{
    public partial class News : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            SPerson person;

            string getuserData = ((FormsIdentity)(HttpContext.Current.User.Identity)).Ticket.UserData;
            person = JsonConvert.DeserializeObject<SPerson>(getuserData); //轉型別 //物件要用<括號>


            string RankStr = person.Permission;
            string[] RankArr = RankStr.Split(',');

            string yachts = "最新消息";

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

                string id = Request.QueryString["id"];

                FileBrowser fileBrowser = new FileBrowser();
                fileBrowser.BasePath = "/ckfinder";
                fileBrowser.SetupCKEditor(CKEditorControl1);
                //loadDayNewsHeadline();


                if (Request["id"] != null)
                {

                 

                    AddHeadlineBtn.Text = "修改";

                    SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["YachtsConnectionString"].ConnectionString);


                    SqlCommand command = new SqlCommand(@"SELECT  id, date, headline, isTop, summary, newsContent  FROM  [News] where (id = @id)", connection);

                    command.Parameters.AddWithValue("@id", Request["id"]);


                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();//使用DataReader


                    if (reader.Read())
                    {

                        DateTime strDate = DateTime.Parse(reader["date"].ToString());
                        Calendar.Text = String.Format("{0:yyyy-MM-dd}", strDate);
                        //Calendar.Text = reader["date"].ToString();//不能這樣寫
                        //資料庫存進去後是0000/00/00  但 calender是0000-00-00 所以要先轉型

                        headlineTbox.Text = reader["headline"].ToString();
                        CBoxIsTop.Checked = Convert.ToBoolean(reader["isTop"]);
                        summary.Text = reader["summary"].ToString();
                        CKEditorControl1.Text = HttpUtility.HtmlDecode(reader["newsContent"].ToString());

                    }
                    connection.Close();


                }

            }

        }

        protected void AddHeadlineBtn_Click(object sender, EventArgs e)
        {

            ////取得日曆選取日期
            //DateTime strDate = DateTime.Parse(Calendar.Text);
            //String.Format("{0}:yyyy/MM/dd", strDate);

            //calender.Text直接存進去就好 不用這麼麻煩



            //取得是否勾選
            string isTop = CBoxIsTop.Checked.ToString(); //得到 "True" or "False"

            //將資料存入資料庫
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["YachtsConnectionString"].ConnectionString);

            string savePath = Server.MapPath(@"~/Newsupload/");

      

            string newsContent = HttpUtility.HtmlEncode(CKEditorControl1.Text);


            if (Request["id"] == null)
            {

                if (imageUpload.FileName.Length > 0 && imageUpload.HasFile) //新增
                {

                    string fileName = imageUpload.FileName;
                    savePath = savePath + fileName;
                    imageUpload.SaveAs(savePath);

                    string sql = "INSERT INTO News (date, headline,summary,newsImageCover,newsContent, isTop) VALUES (@date, @headline, @summary,@newsImageCover,@newsContent,@isTop)";
                    SqlCommand command = new SqlCommand(sql, connection);


                    command.Parameters.AddWithValue("@date", Calendar.Text);  
                    command.Parameters.AddWithValue("@headline", headlineTbox.Text);
                    command.Parameters.AddWithValue("@summary", summary.Text);
                    command.Parameters.AddWithValue("@isTop", isTop); //存入資料庫會轉為0或1
                    command.Parameters.AddWithValue("@newsImageCover", fileName);
                    command.Parameters.AddWithValue("@newsContent", newsContent);


                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                    ////渲染畫面
                    //loadDayNewsHeadline();

                    ////清空輸入欄位
                    //headlineTbox.Text = "";
                    Response.Redirect("NewsListBack.aspx");

                }
                else
                {
                    Label1.Text = "請先挑選檔案再上傳";
                }
            }
            else
            {

                if (imageUpload.FileName.Length > 0 && imageUpload.HasFile) //修改
                {

              


                    string fileName = imageUpload.FileName;
                    savePath = savePath + fileName;
                    imageUpload.SaveAs(savePath);


                    string sql = "Update News Set date=@date,headline=@headline,summary=@summary,newsImageCover=@newsImageCover,newsContent=@newsContent, isTop=@isTop where id=@id";
                    SqlCommand command = new SqlCommand(sql, connection);

                    command.Parameters.AddWithValue("@id", Request["id"]);
                    command.Parameters.AddWithValue("@date", Calendar.Text);
                    command.Parameters.AddWithValue("@headline", headlineTbox.Text);
                    command.Parameters.AddWithValue("@summary", summary.Text);
                    command.Parameters.AddWithValue("@isTop", isTop); //存入資料庫會轉為0或1
                    command.Parameters.AddWithValue("@newsImageCover", fileName);
                    command.Parameters.AddWithValue("@newsContent", newsContent);


                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                    ////渲染畫面
                    //loadDayNewsHeadline();

                    ////清空輸入欄位
                    //headlineTbox.Text = "";

                    Response.Redirect("NewsListBack.aspx");

                }
                else
                {


                    string sql =
                        "DECLARE  @newsImageCover nvarchar(MAX) SET @newsImageCover = (SELECT newsImageCover FROM News WHERE id = @id)UPDATE News SET date = @date, headline = @headline, summary = @summary, newsContent = @newsContent, isTop = @isTop,newsImageCover = (CASE WHEN(newsImageCover IS NULL OR newsImageCover = '') then @newsImageCover ELSE(newsImageCover)END)WHERE id = @id ";

                    SqlCommand command = new SqlCommand(sql, connection);

                    command.Parameters.AddWithValue("@id", Request["id"]);
                    command.Parameters.AddWithValue("@date", Calendar.Text);
                    command.Parameters.AddWithValue("@headline", headlineTbox.Text);
                    command.Parameters.AddWithValue("@summary", summary.Text);
                    command.Parameters.AddWithValue("@isTop", isTop); //存入資料庫會轉為0或1
                    //command.Parameters.AddWithValue("@newsImageCover", fileName);
                    command.Parameters.AddWithValue("@newsContent", newsContent);


                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();

                    Response.Redirect("NewsListBack.aspx");



                    //Label1.Text = "請先挑選檔案再上傳";
                }

            }

        }

        //private void loadDayNewsHeadline()
        //{
        //    //依選取日期取得資料庫新聞內容
        //    SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["YachtsConnectionString"].ConnectionString);

        //    string sql = "SELECT * FROM News WHERE date = @date ORDER BY id ASC";
        //    SqlCommand command = new SqlCommand(sql, connection);
        //    command.Parameters.AddWithValue("@date", Calendar.Text);

        //    connection.Open();
        //    SqlDataReader reader = command.ExecuteReader();

        //    while (reader.Read())
        //    {
        //        string headlineStr = reader["headline"].ToString();
        //        string summaryStr = reader["summary"].ToString();
        //        string newsImage = reader["summary"].ToString();
        //        string isTopStr = reader["isTop"].ToString();
        //        //渲染畫面

        //    }
        //    connection.Close();

        //}
    }
}