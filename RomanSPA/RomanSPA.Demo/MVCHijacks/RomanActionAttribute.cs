using RomanSPA.Demo.MVCHijacks;

namespace RomanSPA.Demo {
    using System;
    using System.Web.Mvc;

    public class RomanActionAttribute : ActionFilterAttribute {

        public Type Factory { get; set; }

        public string ControllerName { get; set; }
        
        public string ViewPath { get; set; }

        public RomanActionAttribute() : this(null, String.Empty, String.Empty) { }

        public RomanActionAttribute(string viewPath) : this(null, String.Empty, viewPath) { }

        public RomanActionAttribute(string controllerName, string viewPath) : this(null, controllerName, viewPath) { }

        public RomanActionAttribute(Type factory, string viewPath) : this(factory, String.Empty, viewPath) { }

        public RomanActionAttribute(Type factory, string controllerName, string viewPath) {
            Factory = factory; ControllerName = controllerName; ViewPath = viewPath;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext) {
            if (filterContext.HttpContext.IsRomanModelRequest()) {
                var modelFactory = (IModelFactory)Activator.CreateInstance(Factory);
                filterContext.Result = new JsonResult() { Data = modelFactory.Execute() };
            } else {
                base.OnActionExecuting(filterContext);
            }
        }

    }
}
