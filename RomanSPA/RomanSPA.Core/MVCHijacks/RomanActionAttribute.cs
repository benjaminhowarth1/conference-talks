namespace RomanSPA {
    using System;
    using System.Web.Mvc;
    using RomanSPA.Models;
    
    public class RomanActionAttribute : ActionFilterAttribute {

        #region Properties

        public Type Factory { get; set; }
        
        public string ControllerName { get; set; }

        public string ViewPath { get; set; }

        #endregion

        #region Fields

        private IModelFactory ModelFactory { get; set; }

        #endregion

        #region .ctors

        public RomanActionAttribute() : this(null, String.Empty, String.Empty) { }

        public RomanActionAttribute(string viewPath) : this(null, String.Empty, viewPath) { }

        public RomanActionAttribute(string controllerName, string viewPath) : this(null, controllerName, viewPath) { }

        public RomanActionAttribute(Type factory, string viewPath) : this(factory, String.Empty, viewPath) { }

        public RomanActionAttribute(Type factory, string controllerName, string viewPath) {
            Factory = factory; ControllerName = controllerName; ViewPath = viewPath;
            try {
                ModelFactory = (IModelFactory)Activator.CreateInstance(Factory);
            } catch (Exception ex) {
                throw new ArgumentException(String.Format("Could not create factory for type '{0}'", factory.Name), ex);
            }
        }

        #endregion
        
        public override void OnActionExecuting(ActionExecutingContext filterContext) {
            if (filterContext.HttpContext.IsRomanModelRequest()) {
                filterContext.Result = new JsonResult() { Data = ModelFactory.Execute() };
            } else {
                base.OnActionExecuting(filterContext);
            }
        }
    }
}
