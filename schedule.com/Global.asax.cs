using schedule.com.Models.sessions;
using System;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace schedule.com
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            data.helpers.SqlHelper.ConnectString = System.Configuration.ConfigurationManager.ConnectionStrings["HospitalAdo"].ConnectionString;
        }
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            //try
            //{
            //    var encryptQueryString = System.Web.HttpContext.Current.Request.QueryString["q"];
            //    if (encryptQueryString != null)
            //    {
            //        System.Web.HttpContext.Current.RewritePath("/quanhuyen?matinh=02");
            //    }
            //}
            //catch
            //{
            //}
        }

    }
}
