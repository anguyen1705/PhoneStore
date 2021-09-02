using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PhoneStore.Models.db;
using PhoneStore.Models.Entities;

namespace PhoneStore.DAO
{
    public class ProductDetailDAO
    {
        public ProductDetail findProductDetailById(int id)
        {
            PhoneStoreEntities db = new PhoneStoreEntities();

            ProductDetail pd = new ProductDetail(findByProductID(id));
            return pd;
        }

        public productdetail findByProductID(int id)
        {
            String sql = "select * from productdetail where productId=" + id +" and activeFlag="+1;
            using (PhoneStoreEntities db = new PhoneStoreEntities())
            {

                productdetail productdetail = db.Database.SqlQuery<productdetail>(sql).FirstOrDefault();
                productdetail.spec = db.specs.Find(productdetail.specId);
                productdetail.color = db.colors.Find(productdetail.colorId);
                productdetail.product = db.products.Find(productdetail.productId);
                return productdetail;

            }
        }

        public decimal getMinValue(int specID)
        {

            String sql = "select MIN(price) from productdetail where specId=" + specID;
            using (PhoneStoreEntities db = new PhoneStoreEntities())
            {

                decimal minPrice = db.Database.SqlQuery<decimal>(sql).FirstOrDefault();
                return minPrice;

            }

        }
    }
}