using System.Web;
using System.Web.Mvc;

namespace TypicalSouthernFoods.HTML5MVCWeb {
    public class FilterConfig {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
