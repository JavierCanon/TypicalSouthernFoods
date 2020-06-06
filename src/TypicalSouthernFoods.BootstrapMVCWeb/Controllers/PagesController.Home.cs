using System.Web.Mvc;

namespace TypicalSouthernFoods.Web.Controllers
{
    public partial class PagesController : Controller
    {
        public ActionResult Home()
        {
            return View();
        }
    }
}