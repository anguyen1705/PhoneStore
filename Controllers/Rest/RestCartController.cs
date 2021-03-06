using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhoneStore.DAO;
using PhoneStore.Models.Entities;
using PhoneStore.Models.db;

namespace PhoneStore.Controllers.Rest
{
    public class RestCartController : Controller
    {
        ProductDetailDAO productDetailDAO = new ProductDetailDAO();
        PhoneStoreEntities db = new PhoneStoreEntities();

        [NonAction]
        private int ktTrungSP(int idPD)
        {
            List<Cart> carts = Session["cart"] as List<Cart>;
            for (int i = 0; i < carts.Count; i++)
            {
                if (carts[i].ProductDetail.id == idPD)
                {
                    return i;
                }
            }

            return -1;
        }

        // GET: RestCart


        public JsonResult addToCart()
        {


            /*try
            {
                int productDetailId = int.Parse(Request.QueryString["idProductDetail"]);
                ProductDetail productDetail = this.productDetailDAO.findProductDetailById(productDetailId);
                productDetail.spec.getValueByName("Bộ nhớ trong");

                if (Session["cart"] == null)
                {
                    List<Cart> carts = new List<Cart>();
                    Cart cart = new Cart();
                    cart.ProductDetail = productDetail;
                    cart.Quantity = 1;
                    cart.TotalPrice = cart.ProductDetail.price;
                    carts.Add(cart);

                    Session["cart"] = carts;

                }
                else
                {
                    List<Cart> carts = Session["cart"] as List<Cart>;
                    int index = ktTrungSP(productDetail.id);
                    if (index == -1)
                    {
                        Cart cart = new Cart();

                        cart.ProductDetail = productDetail;
                        cart.Quantity = 1;
                        cart.TotalPrice = cart.ProductDetail.price;
                        carts.Add(cart);
                        Session["cart"] = carts;
                    }
                    else
                    {
                        carts[index].Quantity = carts[index].Quantity + 1;
                        carts[index].TotalPrice = carts[index].TotalPrice * 2;
                        Session["cart"] = carts;
                    }
                }
                string message = "SUCCESS";
                return Json(new { Message = message }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                string message = "FAIL";
                return Json(new { Message = message }, JsonRequestBehavior.AllowGet);

            }*/


            //new version
            try
            {
                int productDetailId = int.Parse(Request.QueryString["idProductDetail"]);
                product product = db.products.Find(productDetailId);
                ProductDetail productdetail = null;
                foreach (productdetail pd in product.productdetails)
                {
                    if (pd.activeFlag == 1)
                    {
                        productdetail = new ProductDetail(pd);
                    }
                }

                if (Session["cart"] == null)
                {
                    List<Cart> carts = new List<Cart>();
                    Cart cart = new Cart();
                    cart.ProductDetail = productdetail;
                    cart.Quantity = 1;
                    cart.TotalPrice = cart.ProductDetail.price;
                    carts.Add(cart);

                    Session["cart"] = carts;
                    Session["numCartItem"] = carts.Count;
                }
                else
                {
                    List<Cart> carts = Session["cart"] as List<Cart>;
                    int index = ktTrungSP(productdetail.id);
                    if (index == -1)
                    {
                        Cart cart = new Cart();

                        cart.ProductDetail = productdetail;
                        cart.Quantity = 1;
                        cart.TotalPrice = cart.ProductDetail.price;
                        carts.Add(cart);
                        Session["cart"] = carts;
                    }
                    else
                    {
                        carts[index].Quantity = carts[index].Quantity + 1;
                        carts[index].TotalPrice = carts[index].TotalPrice * 2;
                        Session["cart"] = carts;
                    }
                    Session["numCartItem"] = carts.Count;
                }


                string message = "SUCCESS";
                return Json(new { Message = message }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                string message = "FAIL";
                return Json(new { Message = message }, JsonRequestBehavior.AllowGet);

            }
        }


        public JsonResult updateCart()
        {
            try
            {
                int productDetailId = int.Parse(Request.QueryString["idProductDetail"]);
                int quantity = int.Parse(Request.QueryString["quantity"]);
                int totalPrice = int.Parse(Request.QueryString["totalPrice"]);
                if (Session["cart"] != null)
                {
                    ProductDetail productDetail = this.productDetailDAO.findProductDetailById(productDetailId);
                    List<Cart> carts = Session["cart"] as List<Cart>;
                    int index = ktTrungSP(productDetail.id);
                    if (index != -1)
                    {
                        carts[index].Quantity = quantity;
                        carts[index].TotalPrice = totalPrice;
                    }
                }
                string message = "SUCCESS";
                return Json(new { Message = message }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception exc)
            {
                string message = "FAIL";
                return Json(new { Message = message }, JsonRequestBehavior.AllowGet);
            }
        }


        public JsonResult deleteItemInCart()
        {
            string message = "";
            try
            {
                int productDetailId = int.Parse(Request.QueryString["idPD"]);

                if (Session["cart"] != null)
                {
                    ProductDetail productDetail = this.productDetailDAO.findProductDetailById(productDetailId);
                    List<Cart> carts = Session["cart"] as List<Cart>;
                    int index = ktTrungSP(productDetail.id);
                    if (index != -1)
                    {
                        carts.RemoveAt(index);
                        message = "SUCCESS";

                    }

                    if (carts.Count == 0 || carts == null)
                    {
                        message = "EMPTY";

                    }
                }
                else
                {
                    message = "EMPTY";
                }
                return Json(new { Message = message }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                message = "FAIL";
                return Json(new { Message = message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
