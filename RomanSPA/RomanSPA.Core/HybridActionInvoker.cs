using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using RomanSPA.Models;

namespace RomanSPA {
    public class RomanActionInvoker : ControllerActionInvoker {
        
        protected override ActionResult InvokeActionMethod(ControllerContext controllerContext, ActionDescriptor actionDescriptor, IDictionary<string, object> parameters) {
            ActionResult result;
            var attributes = actionDescriptor.GetCustomAttributes(typeof(RomanActionAttribute), false);
            if (attributes.Any()) {
                var attribute = attributes.Cast<RomanActionAttribute>().Single();
                if (attribute.Factory != null) {
                    result = new JsonResult() { Data = attribute.Factory.Execute(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                } else {
                    result = (ViewResult)base.InvokeActionMethod(controllerContext, actionDescriptor, parameters);
                }
            } else {
                result = (ViewResult)base.InvokeActionMethod(controllerContext, actionDescriptor, parameters);
            }
            return result;
        }
    }
}
