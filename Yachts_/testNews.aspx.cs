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
    public partial class testNews : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

            }

            SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["YachtsConnectionString"].ConnectionString);

            string sql = "select * from[dbo].[News] Order by isTop Desc,date Desc";

            SqlCommand command = new SqlCommand(sql, connection);

            connection.Open();

            SqlDataReader reader1 = command.ExecuteReader();

            Repeater1.DataSource = reader1;//repeater的資料來源是從rereader來

            Repeater1.DataBind();//執行繫結

            connection.Close();

            loadList(); //這個要寫才會讀分頁

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
            PageControl.targetpage = "testNews.aspx";

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

            string sql = $"WITH temp as (SELECT ROW_NUMBER() OVER(ORDER BY isTop Desc, date Desc) AS rowindex,* FROM[dbo].[News] ) select *  FROM temp WHERE rowindex between {floor} and {ceiling}";

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