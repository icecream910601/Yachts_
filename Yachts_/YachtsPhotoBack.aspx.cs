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
    public partial class YachtsPhotoBack : System.Web.UI.Page
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
                Show();
            }

        }








        private void Show()
        {


            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["YachtsConnectionString"].ConnectionString);

            string sql = "SELECT * FROM [YachtsPhoto] where yachts_id=@yachts_id";

            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@yachts_id", Request["yatchid"]);


            //SqlDataAdapter dataAdapter = new SqlDataAdapter(command);//取得command資料
            //DataSet dataset = new DataSet();//創立一個dataset的記憶體資料庫
            //dataAdapter.Fill(dataset);//將上面抓到的資料存入dataset內
            //GridView1.DataSource = dataset;//DataSource的資料來源是dataset or datatable
            //GridView1.DataBind();//資料與欄位合在一起
            //command.Dispose();



            connection.Open();


            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);//取得command資料
            DataTable datatabel = new DataTable();//創立一個dataset的記憶體資料庫

            dataAdapter.Fill(datatabel); //將上面抓到的資料存入dataset內
            GridView1.DataSource = datatabel; //repeater的資料來源是從rereader來
            GridView1.DataBind(); //執行繫結



            //RadioButton RadioButton1 = (RadioButton)GridView1.Rows[0].FindControl("RadioButton1");



            //for (int i = 0; i < GridView1.Rows.Count; i++)
            //{

            //    string strValue = GridView1.Rows[i].Cells[0].Text.ToString().Trim();  // 取得 GridView 第i行，第一列的值

            //    RadioButton RadioButton1 = (RadioButton)GridView1.Rows[i].FindControl("RadioButton1") as RadioButton;  // 抓取 GridView 內元件的值


            //    if (strValue == "True")
            //    {
            //        RadioButton1.Checked = true;
            //    }
            //    else
            //    {
            //        RadioButton1.Checked = false;
            //    }

            //}


            connection.Close();



            //判斷撈出來的資料 在gridview 每一行資料


            //foreach (GridViewRow row in GridView1.Rows)
            //{
            //    string isCover = GridView1.DataKeys[row.RowIndex].Value.ToString();//Id field
            //    RadioButton RadioButton1 = row.FindControl("RadioButton1") as RadioButton; 

            //   sql2 = "SELECT * FROM [YachtsPhoto] where yachts_id=@yachts_id";

            //    connection.Open();

            //    SqlCommand command2 = new SqlCommand(sql2, connection);
            //    command2.Parameters.AddWithValue("@yachts_id", Convert.ToInt32(isCover));

            //    SqlDataReader reader2 = command2.ExecuteReader();//使用DataReader


            //    if (reader2.Read()) //每讀入一行(這邊只會讀進一行因為SQL下的條件只會取得一筆資料)
            //    {
            //        if (reader2["isCover"].ToString() == "1")
            //        {
            //            RadioButton1.Checked = true;
            //        }
            //        else
            //        {
            //            RadioButton1.Checked = false;
            //        }
            //    }
            //    connection.Close();
            //}

            //command.Dispose();


        }

        protected void UploadHBtn_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["YachtsConnectionString"].ConnectionString);

            string savePath = Server.MapPath(@"~/Yachtsupload/");

            if (imageUpload.FileName.Length > 0 && imageUpload.HasFile)
            {

                string fileName = imageUpload.FileName;
                savePath = savePath + fileName;
                imageUpload.SaveAs(savePath);

                SqlCommand command = new SqlCommand($" INSERT INTO YachtsPhoto (yachts_id,yachts_photo ) VALUES (@yachts_id,@yachts_photo) ", connection);

                command.Parameters.AddWithValue("@yachts_id", Request["yatchid"]);
                command.Parameters.AddWithValue("@yachts_photo", fileName);

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

            SqlCommand command = new SqlCommand($"DELETE  FROM YachtsPhoto WHERE  (id = @id) ", Connection);
            command.Parameters.AddWithValue("@id", id);


            Connection.Open();
            command.ExecuteNonQuery();
            Connection.Close();

            Show();

        }



        protected void rbSelector_CheckedChanged(object sender, System.EventArgs e)
        {
            foreach (GridViewRow oldrow in GridView1.Rows)
            {
                ((RadioButton)oldrow.FindControl("RadioButton1")).Checked = false;
            }

            //Set the new selected row
            RadioButton rb = (RadioButton)sender;
            GridViewRow row = (GridViewRow)rb.NamingContainer;
            ((RadioButton)row.FindControl("RadioButton1")).Checked = true;

        }


        protected void Button1_Click(object sender, EventArgs e)
        {

            foreach (GridViewRow row in GridView1.Rows)
            {

                string isCover = GridView1.DataKeys[row.RowIndex].Value.ToString();//Id field
                RadioButton RadioButton1 = row.FindControl("RadioButton1") as RadioButton;

                if (RadioButton1.Checked)
                {

                    SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["YachtsConnectionString"].ConnectionString);


                    SqlCommand command1 = new SqlCommand($" UPDATE YachtsPhoto SET isCover = '1' WHERE id = @id ", connection);


                    command1.Parameters.AddWithValue("@id", isCover);

               

                    connection.Open();
                    command1.ExecuteNonQuery();
                    connection.Close();


                }
                else
                {
                    SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["YachtsConnectionString"].ConnectionString);


                    SqlCommand command2 = new SqlCommand($" UPDATE YachtsPhoto SET isCover = '0' WHERE id = @id ", connection);


                    command2.Parameters.AddWithValue("@id", isCover);

                    connection.Open();
                    command2.ExecuteNonQuery();
                    connection.Close();
                }



            }

            Show();



            //foreach (GridViewRow row in GridView1.Rows)
            //{

            //    RadioButtonList RadioButtonList1 = row.FindControl("RadioButton1") as RadioButtonList;
            //    row.Cells[0].Text = RadioButtonList1.SelectedValue;
            //    //string isCover = RadioButtonList1.SelectedValue.ToString();

            //    SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["YachtsConnectionString"].ConnectionString);

            //    SqlCommand command = new SqlCommand($" UPDATE YachtsPhoto SET isCover = @isCover WHERE id = @id ", connection);

            //    command.Parameters.AddWithValue("@id", Request["yatchid"]);
            //    command.Parameters.AddWithValue("@isCover", RadioButtonList1.SelectedValue);

            //    connection.Open();
            //    command.ExecuteNonQuery();
            //    connection.Close();
            //}

            //還沒寫顯示

        }

        protected void GridView1_RowDataBound1(object sender, GridViewRowEventArgs e)
        {
            //for (int i = 0; i < GridView1.Rows.Count; i++)
            //{
            //    RadioButton RadioButton1 = (RadioButton)GridView1.Rows[i].FindControl("RadioButton1") as RadioButton;

            //    //判斷是否為資料列
            //    if (e.Row.RowType == DataControlRowType.DataRow)
            //    {
            //        string a = DataBinder.Eval(e.Row.DataItem, "IsCover").ToString();

            //        //若code = 01時，Row的背景色變成藍色
            //        if (DataBinder.Eval(e.Row.DataItem, "IsCover").ToString() == "True")
            //        {
            //            RadioButton1.Checked = true;
            //        }
            //    }
            //}

            RadioButton RadioButton1 = (RadioButton)e.Row.FindControl("RadioButton1");

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (DataBinder.Eval(e.Row.DataItem, "IsCover").ToString() == "True")
                {
                    RadioButton1.Checked = true;
                }
                else { } 
            }
            else { }


            //加入專案



        }


    }
}
