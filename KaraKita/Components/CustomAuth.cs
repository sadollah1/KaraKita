using KaraKita.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace KaraKita.Components
{
    public class CustomAuth: System.Web.Mvc.AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Session["IsAdminLogin"] != null)
            {
                if (filterContext.HttpContext.Session["IsAdminLogin"].ToString() != "true")
                {

                    
                }
            }
            else {
                filterContext.HttpContext.Response.Clear();
                filterContext.HttpContext.Response.StatusCode = 403;
                filterContext.HttpContext.Response.End();
            }

        }
   
    }
}