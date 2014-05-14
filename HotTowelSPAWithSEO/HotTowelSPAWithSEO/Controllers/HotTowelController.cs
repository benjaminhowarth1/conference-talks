using System.Web.Mvc;
using RomanSPA;
using RomanSPA.Controllers;
using RomanSPA.Models;

namespace HotTowelSPAWithSEO.Controllers
{
    public class HotTowelController : RomanController
    {
        //
        // GET: /HotTowel/
        public ActionResult Index() { return View(); }

        [RomanAction]
        public ActionResult Home() { return View(); }

        [RomanAction(typeof(Models.MyModelFactory<object>))]
        public ActionResult Details() { return View(); }

        [RomanAction(typeof(Models.MyModelFactory<object>))]
        public ActionResult Blog() { return View(); }

        [RomanPartial]
        public ActionResult Shell() { return View(); }

        [RomanPartial]
        public ActionResult Nav() { return View(); }

        [RomanPartial]
        public ActionResult Footer() { return View(); }

        protected override IActionInvoker CreateActionInvoker() { return new RomanActionInvoker(); }
    }
}
