using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using uComponents.Mapping;
using umbraco.NodeFactory;
using Umbraco.Web.Mvc;

namespace UmbracoStrongTypeViews.Controllers {
    public class BassFunkyController : RenderMvcController {

        public override System.Web.Mvc.ActionResult Index(Umbraco.Web.Models.RenderModel model) {
            try {
                var hasMapping = uMapper.Engine.NodeMappers;
                if (hasMapping.Any(p => p.Value.SourceDocumentType.Alias == model.Content.DocumentTypeAlias)) {
                    // We're able to map current node type to a POCO.
                    Type resultType = hasMapping.First(p => p.Value.SourceDocumentType.Alias == model.Content.DocumentTypeAlias).Value.DestinationType;
                    var typeConversion = typeof(uMapper).GetMethod("Map").MakeGenericMethod(resultType);
                    var rawObject = typeConversion.Invoke(resultType, new object[] { new Node(model.Content.Id), false });
                    return CurrentTemplate(rawObject);
                } else {
                    // No POCO model, so return Rendermodel
                    return base.Index(model);
                }
            } catch (InvalidOperationException NoObjectException) {
                // Exception, return base RenderModel
                return base.Index(model);
            }
        }

    }
}