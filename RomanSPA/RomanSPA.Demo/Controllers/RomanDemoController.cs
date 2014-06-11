namespace RomanSPA.Demo.Controllers {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using RomanSPA.Controllers;
    using RomanSPA.Demo.Models;

    public class RomanDemoController : RomanController {

        private RomanSPA.Demo.Models.RomanSPAStarterKitEntities _context;

        public RomanDemoController() : base() {
            // Yes, I'm not using dependency injection for my DB context, cause this is a demo ;-)
            if (_context == null) _context = new Models.RomanSPAStarterKitEntities();
        }

        [RomanAction]
        public ActionResult Index() { return View(new IndexModel()); }

        [RomanAction(Factory=typeof(BlogListFactory), ControllerName="BlogController", ViewPath="/assets/blog-list.html")]
        public ActionResult Blog() { return View(_context.BlogPosts); }

        [RomanAction(ControllerName="BlogPostController")]
        public ActionResult BlogPost(string slug) {
            if (_context.BlogPosts.Any(p => MakeTitleUrlFriendly(p.Title) == slug)) {
                return View(_context.BlogPosts.First(p => MakeTitleUrlFriendly(p.Title) == slug));
            } else {
                return HttpNotFound();
            }
        }

        [RomanAction]
        public ActionResult About() { return View(); }

        private string MakeTitleUrlFriendly(string title) {
            return title.ToLower().Replace(" ", "-");
        }
    }
}