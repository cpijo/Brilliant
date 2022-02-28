using School.Common.Common;
using School.Entities.Fields;
using School.Services.Interface;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Web;
using System.Web.Mvc;

namespace School.UI.Controllers
{
    public class LogInController : Controller
    {
        private  ILoginRepository loginRepository;
        private IRolesRepository permissionRepository;
        public LogInController(ILoginRepository loginRepository, IRolesRepository permissionRepository)
        {
            //File:Ghana school under the trees.jpg
            this.loginRepository = loginRepository;
            this.permissionRepository = permissionRepository;
        }

        // GET: LogIn
        #region Login page
        [HttpPost]
        public ActionResult LoginPartial(UserLogin model)
        {
            model.EmailAddress = "sphiwe@brilliant.co.za";
            model.Username = "AD00000012";
            model.Password = "Password@1";
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
                _dynamic.userName = model.Username;// = "AD00000012";// "US00000012";
                _dynamic.password = model.Password;// "7507239F3C3EB689DB85A29151C0CF5BB5F4A1FD";
                string _encodedPassword = HashingPassword.HashSHA1(model.Password);
                _dynamic.password = _encodedPassword;
                var _user = loginRepository.GetByAny(_dynamic);

                if (_user == null)
                {
                    return Json(new { result = "false", message = "Invalid Username or Password!", title = "Invalid LogIn" }, JsonRequestBehavior.AllowGet);
                }
                else
                {                   
                    Session["UserDetails"] = _user[0];


                    //List<Roles> roles= permissionRepository.GetById(_user[0].UserId);
                    List<Roles> roles = new List<Roles>();
                    roles.Add(new Roles() { RoleID = 200, RoleName = "Test0" });
                    roles.Add(new Roles() { RoleID = 500, RoleName = "Test1" });
                    Session["permissionList"] = roles;
                    appMenu menu = new appMenu();
                    menu.menuRequest.name = "login";
                    return Json(new { result = "true", name = _user[0].Name, surname = _user[0].Surname }, JsonRequestBehavior.AllowGet);

                    //return PartialView("_PartialLayoutMenu");
                }

            }
            catch (Exception ex)
            {
                return Json(new { result = "false", message = ex.Message, title = "Invalid LogIn" }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion
        #region LogOff
        [HttpGet]
        public ActionResult LogOff()
        {
            Session.RemoveAll();
            Session.Abandon();

            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
            Response.Cache.SetNoStore();

            return RedirectToAction("Index", "Home");
        }
        #endregion
    }
}