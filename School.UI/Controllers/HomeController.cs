using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace School.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
           // HttpApplication http = new HttpApplication();
           // var c = http.Request.IsLocal;
           //// if (http.Request.IsLocal)
           // var callingUrl = Request.Headers["Referer"].ToString();
           // var isLocal = Url.IsLocalUrl(callingUrl); // return if URL is local

            return View();
        }
    }
}