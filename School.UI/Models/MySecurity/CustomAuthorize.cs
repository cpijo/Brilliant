using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace School.UI.Models.MySecurity
{
    public class CustomAuthorize : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool result = base.AuthorizeCore(httpContext);

            if (result == true)
            {
                if (httpContext.Session["UserDetails"] == null)
                {
                    result = false;
                }
            }
            return result;
        }

    }
}