using School.Entities.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace bheboo.UI.Controllers
{
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    public class DeviceMenuController : Controller
    {
        // GET: DeviceMenu
        [HttpPost]
        public ActionResult MobileMenu(string par1, string par2)
        {
            System.Threading.Thread.Sleep(1);
            appMenu menu = new appMenu();
            return PartialView("_PartialLayoutMenu");
            //return PartialView("_PartialLayoutMenu", menu);
        }
        //[HttpGet]
        [HttpPost]
        public ActionResult DesktopMenu(string par1,string par2)
        {
            System.Threading.Thread.Sleep(1);
            appMenu menu = new appMenu();
            return PartialView("_PartialLayoutMenu");
            //return PartialView("_PartialLayoutMenu", menu);
        }
    }
}