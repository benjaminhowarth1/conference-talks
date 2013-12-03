using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotTowelSPAWithSEO {

    public static class HttpContextExtensions {

        public static bool IsDurandalRequest(this HttpContextBase context) {
            return context.Request.Headers.AllKeys.Any(p => p == Keywords.IsHTML5SPARequest);
        }

        public static bool NeedsKOBindings(this HttpContextBase context) {
            return context.Request.Headers.AllKeys.Any(p => p == Keywords.NeedsKOBindings);
        }

    }
}