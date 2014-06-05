using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace RomanSPA {

    public class RomanPartialAttribute : ActionFilterAttribute {

        public override void OnActionExecuting(ActionExecutingContext filterContext) {
            bool executeAction = (
                filterContext.ActionDescriptor.GetCustomAttributes(typeof(RomanPartialAttribute), true).Any() &
                    (filterContext.RequestContext.HttpContext.IsRomanViewRequest() | filterContext.IsChildAction)
                    |
                    (!filterContext.ActionDescriptor.GetCustomAttributes(typeof(RomanPartialAttribute), true).Any())
            );

            if (executeAction) {
                base.OnActionExecuting(filterContext);
            } else {
                filterContext.Result = new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
        }
    }
}