using Microsoft.AspNet.FriendlyUrls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace Yachts_
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            // 設定不顯示副檔名 (如果只想隱藏副檔名做到此區塊就好)
            var routes = RouteTable.Routes;
            var settings = new FriendlyUrlSettings();
            settings.AutoRedirectMode = RedirectMode.Permanent;
            //routes.EnableFriendlyUrls(settings);

            //修改避免 CKFinder 上傳功能錯誤
            routes.EnableFriendlyUrls(settings, new Microsoft.AspNet.FriendlyUrls.Resolvers.IFriendlyUrlResolver[] { new MyWebFormsFriendlyUrlResolver() });

            // 執行短網址路由方法
            RegisterRouters(RouteTable.Routes);
        }

        private void RegisterRouters(RouteCollection routes)
        {
         
        }

        public class MyWebFormsFriendlyUrlResolver : Microsoft.AspNet.FriendlyUrls.Resolvers.WebFormsFriendlyUrlResolver
        {
            public override string ConvertToFriendlyUrl(string path)
            {
                //字串為 ckfinder 固定內容
                if (!string.IsNullOrEmpty(path) && path.ToLower().Contains("/ckfinder/core/connector/aspx/connector.aspx"))
                {
                    return path;
                }
                return base.ConvertToFriendlyUrl(path);
            }
        }
    }
}