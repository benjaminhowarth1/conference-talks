using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web.Mvc;
using RomanSPA.Models;

namespace RomanSPA {
    
    public class RomanActionAttribute : ActionFilterAttribute, IResultFilter {

        public IModelFactory Factory { get; set; }

        public string ClientViewName { get; set; }

        #region .ctors

        public RomanActionAttribute() : this(null, String.Empty) { }
        
        public RomanActionAttribute(Type factory) : this(factory, String.Empty) { }
        
        public RomanActionAttribute(string viewName) : this(null, viewName) { }

        public RomanActionAttribute(Type factory, string viewName = "") {
            if (factory != null) Factory = (IModelFactory)Activator.CreateInstance(factory);
            ClientViewName = viewName;
        }

        #endregion

        public override void OnResultExecuting(ResultExecutingContext filterContext) {
            if (String.IsNullOrEmpty(ClientViewName)) ClientViewName = filterContext.HttpContext.Request.Url.AbsolutePath;

            if (Factory != null) {
                // var modelFactory = FactoryType.GetInterfaces().First(p => p.Name == "IModelFactory");
                filterContext.Result = new JsonResult() { Data = Factory.Execute(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
        }
    }
}
