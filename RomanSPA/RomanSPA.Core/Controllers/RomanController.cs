using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using RomanSPA.Models;

namespace RomanSPA.Controllers {
    public abstract class RomanController : Controller {

        protected override ViewResult View(string viewName, string masterName, object model) {
            if (model == null) {
                var methodAttr = MethodBase.GetCurrentMethod().GetCustomAttributes(typeof(RomanActionAttribute), false);
                if (methodAttr.Any()) {
                    var attrInvoker = methodAttr.Cast<RomanActionAttribute>().First();
                    model = attrInvoker.Factory.Execute();
                } else {
                    return base.View(viewName, masterName, model);
                }
            } 
            return base.View(viewName, masterName, model);
        }
    }
}