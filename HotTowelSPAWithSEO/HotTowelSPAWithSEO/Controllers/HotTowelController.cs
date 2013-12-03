using System.Web.Mvc;

namespace HotTowelSPAWithSEO.Controllers
{
    public class HotTowelController : Controller
    {
        //
        // GET: /HotTowel/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Home() { return View(); }

        public ActionResult Details() { return View(); }

        [DurandalPartial]
        public ActionResult Shell() { return View(); }

        [DurandalPartial]
        public ActionResult Nav() { return View(); }

        [DurandalPartial]
        public ActionResult Footer() { return View(); }

    }
}
