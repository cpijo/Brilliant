using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace School.UI
{
    public class MvcApplication : System.Web.HttpApplication
    {

        private static HttpRequest initialRequest;

        static MvcApplication()
        {
            initialRequest = HttpContext.Current.Request;
            string hostName = System.Web.HttpContext.Current.Server.MachineName;
            var hostName1 = System.Environment.GetEnvironmentVariable("COMPUTERNAME");
            var host = HttpContext.Current.Request.UserHostName;
            var clientBrowser = HttpContext.Current.Request.Browser.Browser;

            if (hostName1.ToLower().Contains("sphiwe"))
            {
                string visitors = ConfigurationManager.AppSettings["urlHost"];
                ConfigurationManager.AppSettings["urlHost"] = "isLocalHost";
            }
            else
            {
                ConfigurationManager.AppSettings["urlHost"] = "notLocalHost";
            }
        }





        static void  Not_In_Used_MvcApplication()
        {
            initialRequest = HttpContext.Current.Request;
            var _host = System.Net.Dns.GetHostEntry(HttpContext.Current.Request.ServerVariables["REMOTE_HOST"]);
            string hostName1 = System.Web.HttpContext.Current.Server.MachineName;
            var hostName2 = System.Environment.GetEnvironmentVariable("COMPUTERNAME");
            //string host = HttpContext.Current.Request.Url.Host.ToLower();
            //var IsLocal = HttpContext.Current.Request.Url.AbsoluteUri.StartsWith("http://localhost:");
            //var yo = HttpContext.Current.Request.UserHostAddress.ToString();
            var host = HttpContext.Current.Request.UserHostName;
            var clientBrowser = HttpContext.Current.Request.Browser.Browser;

            if (host == "localhost" || host == "127.0.0.1")
            {
                string visitors = ConfigurationManager.AppSettings["urlHost"];
                ConfigurationManager.AppSettings["urlHost"] = "isLocalHost";
            }
            else
            {
                ConfigurationManager.AppSettings["urlHost"] = "notLocalHost";
            }
        }






        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //BundleTable.EnableOptimizations = false;
            UnityConfig.RegisterComponents();

           // HostFinder.OnTestingServer();
        }


        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError();
            HttpRequest request = HttpContext.Current.Request;
            var values = new System.Web.Routing.RouteValueDictionary();

            string StakeTrace = exception.StackTrace;
            string massage = exception.Message;
            var exceptionName = exception.GetType().Name;
            string urlPath = request.Url.AbsolutePath;
            string urlPath1 = request.AppRelativeCurrentExecutionFilePath;

            var httpContext = ((MvcApplication)sender).Context;
            string currentController = "";
            string currentAction = "";

            var currentRouteData = RouteTable.Routes.GetRouteData(new HttpContextWrapper(httpContext));
            if (currentRouteData != null)
            {
                if (currentRouteData.Values["controller"] != null && !String.IsNullOrEmpty(currentRouteData.Values["controller"].ToString()))
                {
                    currentController = currentRouteData.Values["controller"].ToString();
                }

                if (currentRouteData.Values["action"] != null && !String.IsNullOrEmpty(currentRouteData.Values["action"].ToString()))
                {
                    currentAction = currentRouteData.Values["action"].ToString();
                }
            }

            if (exceptionName == "HttpException")
            {
                if (massage.Contains("A public action method") && massage.Contains("A public action method"))
                {
                    string view = massage.Substring(massage.IndexOf("'"));
                    massage = view.Substring(1, view.IndexOf("."));
                    Server.ClearError();
                    Response.Redirect("~/Errors/ErrorExeptionsMessage/?ErrorInfo=" + massage);
                }
                else if (massage.Contains("The partial view"))
                {
                    string view = massage.Substring(massage.IndexOf("'"));
                    massage = view.Substring(1, view.IndexOf("."));
                    Server.ClearError();
                    Response.Redirect("~/Errors/ErrorExeptionsMessage/?ErrorInfo=" + massage);
                }
                else
                {
                    Server.ClearError();
                    Response.Redirect("~/Errors/ErrorExeptionsMessage/?ErrorInfo=" + massage);
                }
            }

            else if(exceptionName == "SqlException")
            {
                Server.ClearError();
                Response.Redirect("~/Errors/ErrorSQLSever/?ErrorInfo=" + massage.Replace("\n", "").Replace("\r", "").Replace("\r", ""));
            }
            else
            {
                try
                {
                    Server.ClearError();
                    Response.Redirect("~/Errors/ErrorExeptionsMessage/?ErrorInfo=" + massage);
                }
                catch (Exception ex)
                {
                    Server.ClearError();
                    Response.Redirect("~/Errors/ErrorExeptionsMessage/?ErrorInfo=" + ex.Message.ToString().Replace("\n\r", ""));
                }

            }
        }
        protected void Application_PreSendRequestHeaders()
        {
            if (HttpContext.Current != null)
            {
                HttpContext.Current.Response.Headers.Remove("Server");
                HttpContext.Current.Response.Headers.Remove("X-AspNet-Version");
            }
        }
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            HttpCookie SelectedCookie = HttpContext.Current.Request.Cookies["SelectedLanguage"];
            //HttpContext.Current.Session["userProfileList"] = null;
            //HttpContext.Current.Session["usersPerPage"] = null;

            string host = HttpContext.Current.Request.Url.Host.ToLower();
            var IsLocal = HttpContext.Current.Request.Url.AbsoluteUri.StartsWith("http://localhost:");

            if (SelectedCookie != null && SelectedCookie.Value != null)
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(SelectedCookie.Value);
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(SelectedCookie.Value);
            }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("En");
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("En");
            }
        }
    }
}



/*
 * 
 https://andrewlock.net/5-ways-to-set-the-urls-for-an-aspnetcore-app/
    public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
                webBuilder.UseUrls("http://localhost:5003", "https://localhost:5004");
            });
}
 * 
 */
