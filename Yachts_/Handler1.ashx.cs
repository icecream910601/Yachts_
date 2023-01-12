using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using Newtonsoft.Json;

namespace Yachts_
{
    /// <summary>
    /// Handler1 的摘要描述
    /// </summary>
    public class Handler1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {


            //SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["YachtsConnectionString"].ConnectionString);

            //string sql = $"WITH temp as (SELECT ROW_NUMBER() OVER(ORDER BY isTop Desc, date Desc) AS rowindex,* FROM[dbo].[News] ) select * ,case when isTop = 'True' then N'置頂'else N'' end as [status] FROM temp WHERE rowindex between 1 and 5 ";

            //SqlCommand cmd = new SqlCommand(sql, conn);

            //conn.Open();

            //SqlDataReader reader2 = cmd.ExecuteReader();

            //string str = JsonConvert.SerializeObject(reader2);


            //reader2.Close();
            //cmd.Cancel();
            //conn.Close();
            //conn.Dispose();


            //context.Response.ContentType = "application/json";
            //context.Response.Write(str);






            //context.Response.ContentType = "application/json";
            //context.Response.Write("Hello World");  //組文字給前端丟出去


            //context.Response.ContentType = "application/vnd.ms-powerpoint";
            //context.Response.WriteFile("C:/Users/user/Downloads");  //實體路徑

            //追蹤下載統計

            //將物件變成文件
            //DATATABLE式物件 序列成 成string



            SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["YachtsConnectionString"].ConnectionString);

            string sql = $"WITH temp as (SELECT ROW_NUMBER() OVER(ORDER BY isTop Desc, date Desc) AS rowindex,* FROM[dbo].[News] ) select * ,case when isTop = 'True' then N'置頂'else N'' end as [status] FROM temp WHERE rowindex between 1 and 5 ";

            SqlCommand cmd = new SqlCommand(sql, conn);


            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);//取得command資料

            DataTable datatabel = new DataTable();//創立一個dataset的記憶體資料庫
            dataAdapter.Fill(datatabel);//將上面抓到的資料存入dataset內
            //Repeater1.DataSource = datatabel;//repeater的資料來源是從rereader來
            //Repeater1.DataBind();//執行繫結

            cmd.Dispose();

            string str = JsonConvert.SerializeObject(datatabel);

            context.Response.ContentType = "application/json";
            context.Response.Write(str);





        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}