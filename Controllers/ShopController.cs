using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhoneStore.Models.db;
using PhoneStore.DAO;


namespace PhoneStore.Controllers
{
    public class ShopController : Controller
    {
        // GET: Shop
        private ProductDAO productDAO = new ProductDAO();
        public ActionResult List(int pageId)
        {
            using (PhoneStoreEntities db = new PhoneStoreEntities())
            {
                int start = 0;
                if (pageId != 0)
                {
                    start = (pageId - 1) * 3 + 1;
                }
                List<product> products = productDAO.getListProduct(start);
                List<product> productsAll = productDAO.getAllListProduct();
                double pagging = (double)productsAll.Count() / 3;
                double tongsopage = Math.Ceiling(pagging);

                ViewBag.ListPro = products;
                ViewBag.tongsopage = tongsopage;

            }

            return View();
        }

        public ActionResult ListByPage(int pageId)
        {
            
            return RedirectToAction("List", "Shop");
        }

        public ActionResult ListSp()
        {
            return PartialView();
        }
    }
}