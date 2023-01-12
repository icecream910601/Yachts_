﻿using CKFinder;
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
    public partial class Certificate : System.Web.UI.Page
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

                FileBrowser fileBrowser = new FileBrowser();
                fileBrowser.BasePath = "/ckfinder"; 
                fileBrowser.SetupCKEditor(CKEditorControl1);
                loadCertificatContent();
               
            }
        }

        private void loadCertificatContent()
        {
            //取得 About Us 頁面 HTML 資料
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["YachtsConnectionString"].ConnectionString);

            string sql = "SELECT Certificate FROM Company WHERE id = 1";
            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                //渲染畫面
                CKEditorControl1.Text = HttpUtility.HtmlDecode(reader["Certificate"].ToString());
            }
            connection.Close();
        }


        protected void UploadCertificateBtn_Click(object sender, EventArgs e)
        {
            //取得 CKEditorControl 的 HTML 內容
            string Certificate = HttpUtility.HtmlEncode(CKEditorControl1.Text);
            
            //更新 About Us 頁面 HTML 資料
            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["YachtsConnectionString"].ConnectionString);
            string sql = "UPDATE Company SET Certificate = @Certificate WHERE id = 1";

            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Certificate", Certificate);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            //渲染畫面提示
            DateTime nowtime = DateTime.Now;
            UploadCertificateTime.Visible = true;
            UploadCertificateTime.Text = "*Upload Success! - " + nowtime.ToString("G");
        }

        protected void CertificateImage_Click(object sender, EventArgs e)
        {
            Response.Redirect("CertificateImageBack" +
                ".aspx");
        }
    }



}