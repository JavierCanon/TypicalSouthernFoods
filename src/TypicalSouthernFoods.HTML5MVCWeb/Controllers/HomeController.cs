using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TypicalSouthernFoods.HTML5MVCWeb.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            return View();
        }
    }
}