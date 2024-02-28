using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Helpers
{
    public class IsLogIn : ActionFilterAttribute
    {
        int? usercod = 0;
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            usercod = string.IsNullOrEmpty(context.HttpContext.Request.Cookies["usrcod"])?null:Convert.ToInt32(context.HttpContext.Request.Cookies["usrcod"]);
            if(!usercod.HasValue)
            {
                var redirect = new RouteValueDictionary
                {
                    {"action","Login" },{ "controller","Home"}
                };
                context.Result = new RedirectResult("/Home/Login");
            }
            base.OnActionExecuted(context);
        }
    }
}
