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
        public ActionResult List()
        {
            using (PhoneStoreEntities db = new PhoneStoreEntities())
            {
                List<product> products = productDAO.getListProduct(0);
                List<product> productsAll = productDAO.getAllListProduct();
                double pagging = (double)productsAll.Count() / 3;
                double tongsopage = Math.Ceiling(pagging);

                ViewBag.ListPro = products;
                ViewBag.tongsopage = tongsopage;

            }

            return View();
        }

        public ActionResult ListSp()
        {
            return PartialView();
        }
    }
}