using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhoneStore.Models.db;

namespace PhoneStore.Controllers
{
    public class HomeController : Controller
    {
        PhoneStoreEntities db = new PhoneStoreEntities();
        public ActionResult Index()
        {
            return View();
        }

        // load menu tu dong

        public ActionResult MenuPartial()
        {
            var lstSP = db.products;
            return PartialView(lstSP);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}