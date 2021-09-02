using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PhoneStore.Models.db;
using PhoneStore.Models.Entities;

namespace PhoneStore.DAO
{
    public class ProductDAO
    {
        PhoneStoreEntities db = new PhoneStoreEntities();
        public Product findProductById(int id)
        {

            Product p = new Product(db.products.Find(id));
            return p;

        }
        public List<product> getProductByCategoryId(int cateId)
        {

            String sql = "SELECT* FROM `product` WHERE product.categoryId =" + cateId;

            List<product> products = db.products.SqlQuery(sql).ToList<product>();


            return products;

        }

        public List<product> getListProduct(int begin)
        {

            String sql = "select * from (select ROW_NUMBER() OVER(ORDER BY(select 0)) AS RowNumber, * from product) a where a.RowNumber between "+begin +" and "+ 4;

            List<product> products = db.products.SqlQuery(sql).ToList<product>();


            return products;

        }

        public List<product> getAllListProduct()
        {

            String sql = "SELECT * FROM product";

            List<product> products = db.products.SqlQuery(sql).ToList<product>();


            return products;

        }


        public List<product> Apple()
        {

            String sql = "SELECT * FROM product WHERE categoryId=4";

            List<product> products = db.products.SqlQuery(sql).ToList<product>();


            return products;

        }
        public List<product> SamSung()
        {

            String sql = "SELECT * FROM product WHERE categoryId=3";

            List<product> products = db.products.SqlQuery(sql).ToList<product>();


            return products;

        }
        public List<product> PhuKien()
        {

            String sql = "SELECT * FROM product WHERE categoryId=2";

            List<product> products = db.products.SqlQuery(sql).ToList<product>();


            return products;

        }


        public List<comment> comments()
        {

            String sql = "SELECT * FROM comment";

            List<comment> comment = db.comments.SqlQuery(sql).ToList<comment>();


            return comment;

        }
    }
}