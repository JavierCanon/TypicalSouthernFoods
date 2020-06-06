using System.Web.Mvc;

namespace TypicalSouthernFoods.Web.Controllers
{
    public partial class PagesController : Controller
    {
        public ActionResult Clients()
        {
            return View();
        }
    }
}