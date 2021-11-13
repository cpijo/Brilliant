using School.Entities.Fields;
using School.Services.Interface;
using System;
using System.Collections.Generic;
using System.Dynamic;
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
                dynamic _dynamic = new ExpandoObject();
                _dynamic.userName = model.Username= "TC00000008";
                _dynamic.password = model.Password= "C69DA0293EBC7A8E9F5F4F8974B64809BD21F874";
                //UserLogin _user = null;
                List<UserLogin> _user = loginRepository.GetByAny(_dynamic);

                if (_user == null)
                {
                    return Json(new { result = "false", message = "Invalid Username or Password!", title = "Invalid LogIn" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    appMenu menu = new appMenu();
                    menu.menuRequest.name = "login";
                    return PartialView("_PartialLayoutMenu");
                }

            }
            catch (Exception ex)
            {
                return Json(new { result = "false", message = ex.Message, title = "Invalid LogIn" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion
    }
}