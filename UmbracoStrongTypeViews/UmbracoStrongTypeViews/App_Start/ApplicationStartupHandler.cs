using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core;
using Umbraco.Web.Mvc;
using UmbracoStrongTypeViews.Controllers;

namespace UmbracoStrongTypeViews.App_Start {
    public class ApplicationStartupHandler : IApplicationEventHandler {
        public void OnApplicationInitialized(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext) {
            throw new NotImplementedException();
        }

        public void OnApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext) {
            DefaultRenderMvcControllerResolver.Current.SetDefaultControllerType(typeof(BassFunkyController));
        }

        public void OnApplicationStarting(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext) {
            throw new NotImplementedException();
        }
    }
}