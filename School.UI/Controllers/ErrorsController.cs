using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace School.UI.Controllers
{
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    public class ErrorsController : Controller
    {
        public ActionResult ErrorPermission()
        {
            var msg = new
            {
                title = "ERROR PERMISSION",
                result = "false",
                Error = "error",
                message = "You have no PERMISSION",
                errorCode = "permission"
            };
            return Json(msg, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ErrorExeptionsMessage(string ErrorInfo)
        {
            Errormodel respondMessage = new Errormodel
            {
                title = "ERROR",
                result = "false",
                type = "error",
                message = "Sorry Request Not Successfull",
                //message = ErrorInfo,
                waitingTime = ""
            };
            return Json(respondMessage, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ErrorSQLSever(string ErrorInfo)
        {
            Errormodel respondMessage = new Errormodel
            {
                title = "Cannot open database",
                result = "false",
                type = "error",
                message = ErrorInfo,
                waitingTime = ""
            };
            return Json(respondMessage, JsonRequestBehavior.AllowGet);
        }

        public ActionResult reloadHomePage(string ErrorInfo)
        {
            return RedirectToAction("Index", "Home", new { controller = "", action = "", task = "reloadApp", reload = "yes", login = "yes" });
        }

        // Public action method that can be invoked using a URL request
        public ActionResult Index_URL()
        {
            return View();
        }
        [ChildActionOnly]
        public ActionResult Countries(List<string> countryData)
        {
            return View(countryData);
        }


    }

    public class Errormodel
    {
        public string result { get; set; }
        public string waitingTime { get; set; }
        public string title { get; set; }
        public string message { get; set; }
        public string StakeTrace { get; set; }
        public bool status { get; set; }
        public string type { get; set; }
    }
}