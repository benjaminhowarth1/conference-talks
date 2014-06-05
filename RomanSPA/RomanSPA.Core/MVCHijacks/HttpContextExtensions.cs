using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RomanSPA {

    public static class HttpContextExtensions {

        public static bool IsRomanModelRequest(this HttpContextBase context) {
            return context.Request.Headers.AllKeys.Any(p => p == Keywords.IsRomanModelRequest);
        }

        public static bool IsRomanViewRequest(this HttpContextBase context) {
            return context.Request.Headers.AllKeys.Any(p => p == Keywords.IsRomanViewRequest);
        }

    }
}