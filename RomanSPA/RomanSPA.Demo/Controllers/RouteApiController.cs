namespace RomanSPA.Demo.Controllers {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Reflection;
    using System.Text.RegularExpressions;
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Routing;
    using RomanSPA.Demo.Models;

    public class RouteApiController : ApiController {

        private const string DefaultJsController = "GenericCtrl";
        
        public IQueryable<JsRouteModel> ServerRoutes() {
            
            var allRoutes = RouteTable.Routes
                .Where(route => route.GetType().IsEquivalentTo(typeof(Route)))
                .Cast<Route>().ToList();

            // foreach (route)
            // if (controller param) {
            // - foreach (RomanController)
            // - - foreach (RomanAction)
            // - - - parse(route, controller, action)
            // 

            // var routeControllerMagic = 

            List<JsRouteModel> jsRoutes = new List<JsRouteModel>();
            foreach (var controller in GetControllers()) {
                foreach (var action in GetActionsOnController(controller)) {
                    var metadata = action.GetCustomAttribute<RomanActionAttribute>();
                    jsRoutes.Add(
                        new JsRouteModel() {
                        // controller.Name.Replace("Controller", String.Empty);
                        // action.Name
                        RoutePattern = ""
                        });
                    // route.Url.
                }
            }
            return jsRoutes.AsQueryable();
        }

        private JsRouteModel TransformRoute(Route route) {
            throw new NotImplementedException();
        }

        private IEnumerable<MethodInfo> GetActionsOnController(Type controller) {
            return controller.GetMethods(BindingFlags.Public | BindingFlags.Instance)
                             .Where(method => (method.GetCustomAttribute<RomanActionAttribute>() != null));
        }

        private IEnumerable<Type> GetControllers() {
            return Assembly.GetExecutingAssembly().GetTypes().Where(p => p.BaseType.IsEquivalentTo(typeof(RomanController)));
        }

        private string ReplaceTokensWithDefaults(Route route) {
            string url = route.Url;
            foreach (var item in route.Defaults) {
                if (route.Url.IndexOf(String.Format("{{0}}", item.Key)) > -1) {
                    url = url.Replace(String.Format("{{0}}", item.Key), item.Value.ToString());
                }
                // route.Defaults.Where(p => p.Value == UrlParameter.Optional);
            }
            var captureVariables = new Regex(@"\{(?:[^n]+)\}");
            var angularParams = captureVariables.Replace(url, ":{0}");
            return url;
        }
    }
}
