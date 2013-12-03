using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace HotTowelSPAWithSEO {

    public class DurandalPartialAttribute : ActionFilterAttribute {

        public override void OnActionExecuting(ActionExecutingContext filterContext) {
            bool executeAction = (
                filterContext.ActionDescriptor.GetCustomAttributes(typeof(DurandalPartialAttribute), true).Any() &
                    (filterContext.RequestContext.HttpContext.IsDurandalRequest() | filterContext.IsChildAction)
                    |
                    (!filterContext.ActionDescriptor.GetCustomAttributes(typeof(DurandalPartialAttribute), true).Any())
            );

            if (executeAction) {
                base.OnActionExecuting(filterContext);
            } else {
                filterContext.Result = new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
        }
    }
}