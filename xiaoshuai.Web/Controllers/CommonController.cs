using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using xiaoshuai.Services;
using xiaoshuai.ViewModel;

namespace xiaoshuai.Web.Controllers
{
    public class CommonController : Controller
    {
        private ManageService service = new ManageService();
        //
        // GET: /Common/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Category()
        {
            List<CategoryNavViewModel> model = service.GetCategoryNav();
            return PartialView("CategoryPartialPage", model);
        }

        public ActionResult Menu()
        {
            List<CategoryNavViewModel> model = service.GetMenu();
            return PartialView("MenuPartialPage", model);
        }

    }
}
