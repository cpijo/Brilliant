//using Microsoft.AspNet.Identity;
using School.Entities.Fields;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace School.UI.Models.MySecurity
{

    public class userPagePermissionAttribute : ActionFilterAttribute
    {
        public int[] permissionID { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var isLogin = HttpContext.Current.Session["UserDetails"];
            if (isLogin != null)
            {
                List<Roles> permissionList = HttpContext.Current.Session["permissionList"] as List<Roles>;
                string hasPermission = "False";
                foreach (int permission in permissionID)
                {
                    for (int i = 0; i < permissionList.Count; i++)
                    {
                        if (permission == permissionList[i].RoleID)
                        {
                            hasPermission = "True";
                            break;
                        }
                    }
                }

                if (hasPermission == "False")
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                    {
                        { "controller", "Errors" },
                        { "action", "ErrorPermission" }
                    });
                }
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    { "controller", "Account" },
                    { "action", "Login" }
                });
            }
            base.OnActionExecuting(filterContext);

        }
    }
}