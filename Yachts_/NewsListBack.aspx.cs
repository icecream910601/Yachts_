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
    public partial class NewsListBack : System.Web.UI.Page
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

                SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["YachtsConnectionString"].ConnectionString);

                string sql = "select *,CONVERT(char(10),CAST([date] AS datetime),111)as fix,case when isTop = 'True' then N'置頂'else N'' end as [status] from[dbo].[News] Order by isTop Desc, date Desc";

                SqlCommand command = new SqlCommand(sql, connection);

                connection.Open();


                if (Request["did"] != null)  //用JS的寫法把資料存到cookie //跳出視窗 按是或否  按是的時候把數值 存到 cookie
                {
                    Response.Write($"<Script language='JavaScript'>if(confirm('確定要刪除嗎?')){{document.cookie = 'deleteid={Request["did"]}';}};window.location.href='NewsListBack.aspx';</Script>");   //動作 跟 原本預設的did要取不同名稱
                }

                if (Request.Cookies["deleteid"] != null && Request.Cookies["deleteid"].Value != null)   //C#的寫法 //把cookie撈出來 判斷有沒有這個cookie 且 值是不是空的 
                {

                    //Response.Write("<Script language='JavaScript'>alert('確定要刪除嗎?');window.location.href='NewsListBack.aspx';</Script>");


                    SqlCommand Dcommand = new SqlCommand($"DELETE  FROM News WHERE  (id = @did) ", connection);
                    Dcommand.Parameters.AddWithValue("@did", int.Parse(Request.Cookies["deleteid"].Value));

                    Dcommand.ExecuteNonQuery();

                    //connection.Close();

                    Request.Cookies["deleteid"].Value = "";

                    //Response.End();

                }

                SqlDataReader reader2 = command.ExecuteReader();

                Repeater1.DataSource = reader2;//repeater的資料來源是從rereader來

                Repeater1.DataBind();//執行繫結


                connection.Close();

                loadList(); //這個要寫才會讀
            }

        }

        protected void AddNews_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewsBack.aspx");
        }


        private void loadList()
        {

            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["YachtsConnectionString"].ConnectionString);

            //預設為第1頁
            int page = 1;


            //判斷網址後有無參數
            //也可用String.IsNullOrWhiteSpace
            if (!String.IsNullOrEmpty(Request.QueryString["page"]))
            {
                page = Convert.ToInt32(Request.QueryString["page"]);
            }

            //設定頁面參數屬性
            //設定控制項參數: 一頁幾筆資料
            PageControl.limit = 5;

            //設定控制項參數: 作用頁面完整網頁名稱
            PageControl.targetpage = "NewsListBack.aspx";

            //建立計算分頁資料顯示邏輯 (每一頁是從第幾筆開始到第幾筆結束)
            //計算每個分頁的第幾筆到第幾筆
            var floor = (page - 1) * PageControl.limit + 1; //每頁的第一筆
            var ceiling = page * PageControl.limit; //每頁的最末筆

            //將取得的資料數設定給參數 count
            //int count = 36;
            string countTotal = "SELECT COUNT(*)FROM NEWS"; //總資料數，可修改數字測試分頁功能是否正常
            SqlCommand commandForTotal = new SqlCommand(countTotal, connection);

            connection.Open();

            int count = Convert.ToInt32(commandForTotal.ExecuteScalar());
            connection.Close();
            connection.Dispose();

            //設定控制項參數: 總共幾筆資料
            PageControl.totalitems = count;

            //渲染分頁控制項
            PageControl.showPageControls();

            PagedData(floor, ceiling);

            ////設定模擬資料內容
            //StringBuilder listHtml = new StringBuilder();
            //for (int i = floor; i <= ceiling; i++)
            //{
            //    if (i <= count)
            //    {
            //        listHtml.Append($"<a href=''> --------- 第 {i} 筆資料 --------- </a></li><br /><br />");
            //    }
            //}
            //Literal1.Text = listHtml.ToString();
        }

        private void PagedData(int floor, int ceiling)
        {

            SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["YachtsConnectionString"].ConnectionString);

            string sql = $"WITH temp as (SELECT ROW_NUMBER() OVER(ORDER BY isTop Desc, date Desc) AS rowindex,* FROM[dbo].[News] ) select * ,case when isTop = 'True' then N'置頂'else N'' end as [status] FROM temp WHERE rowindex between {floor} and {ceiling}";

              SqlCommand cmd = new SqlCommand(sql, conn);

            //conn.Open();

            //SqlDataReader reader2 = cmd.ExecuteReader();

            //Repeater1.DataSource = reader2;//repeater的資料來源是從rereader來

            //Repeater1.DataBind();//執行繫結

            //reader2.Close();
            //cmd.Cancel();
            //conn.Close();
            //conn.Dispose();


            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);//取得command資料

            DataTable datatabel = new DataTable();//創立一個dataset的記憶體資料庫
            dataAdapter.Fill(datatabel);//將上面抓到的資料存入dataset內
            Repeater1.DataSource = datatabel;//repeater的資料來源是從rereader來
            Repeater1.DataBind();//執行繫結

            cmd.Dispose();




        }

    }
}


