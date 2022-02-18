using School.Entities.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToolBox.Common.Common;

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


            List<string> elemList = new List<string>()
            {
       // "AttendanceId",
        "StudentId",
        "FirstName",
        "LastName",
        "GradeId",
        "SubjectId",
        "Attendance",
    };

            ClassPropertyHelper prop1 = new ClassPropertyHelper();
            int c =0;
            StudentAttendance mod = new StudentAttendance();
            foreach (string xnode in elemList)
            {
                c++;           
                prop1.setProperty(mod, xnode, xnode+" "+c);
            }

            return View();
        }
    }
}