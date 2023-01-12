using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Yachts_
{
    public partial class backstagemaster : System.Web.UI.MasterPage
    {

        protected void Page_Init(object sender, EventArgs e)
        {
            ////清除Cache，避免登出後按上一頁還會顯示Cache頁面
            //Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            //Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //Response.Cache.SetNoStore();

            //驗證身份
            if (Page.User.Identity.IsAuthenticated ==false)
            {
                Response.Redirect("Login.aspx");
            }
           
        }

        protected void Page_Load(object sender, EventArgs e)
        {


            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.Cache.SetNoServerCaching();
            HttpContext.Current.Response.Cache.SetNoStore();

            if (Page.IsPostBack == false)
            {
               


            }

        }

        protected void LoginStatus1_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("Login.aspx");
        }



    }
}