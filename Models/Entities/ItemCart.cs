using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhoneStore.Models.Entities
{
    public class ItemCart
    {
        private ProductDetail productDetail;
        private int quantity;
        private decimal totalPrice;
        private decimal totalCart;

        public ProductDetail ProductDetail { get => productDetail; set => productDetail = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public decimal TotalPrice { get => totalPrice; set => totalPrice = value; }
        public decimal TotalCart { get => totalCart; set => totalCart = value; }
    }
}