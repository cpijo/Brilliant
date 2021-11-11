using School.Entities.Fields;
using School.Services.Interface;
using System;
using System.Web.Mvc;

namespace School.UI.Controllers
{
    public class LogInController : Controller
    {
        public ILoginRepository loginRepository;
        public LogInController(ILoginRepository loginRepository)
        {
            this.loginRepository = loginRepository;
        }

        // GET: LogIn
        #region Login page
        [HttpPost]
        public ActionResult LoginPartial(UserLogin model)
        {
            model.EmailAddress = "sphiwe@brilliant.co.za";
            model.Password = "Password1";
            return PartialView("_LoginPage", model);
        }
        #endregion

        #region Login authentication 
        [HttpPost]
        public ActionResult Login(UserLogin model)
        {
            try
            {
                if (model.EmailAddress == "sphiwe@brilliant.co.za" && model.Password == "Password1")
                {
                    appMenu menu = new appMenu();
                    menu.menuRequest.name = "login";

                    return PartialView("_PartialLayoutMenu");
                }
                return Json(new { result = "false", message = "Username or Password is incorrect", title = "Invalid LogIn" }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new { result = "false", message = ex.Message, title = "Invalid LogIn" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion
    }
}