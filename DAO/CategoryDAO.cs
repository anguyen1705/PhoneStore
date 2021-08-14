using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PhoneStore.Models.db;
using PhoneStore.Models.Entities;

namespace PhoneStore.DAO
{
    public class CategoryDAO
    {
        PhoneStoreEntities db = new PhoneStoreEntities();
        public List<Category> GetCategories()
        {
            String sql = "SELECT c.id,c.name,c.code,c.description,c.activeFlag,c.createDate,c.updateDate,c.parentId FROM category p join category c on c.parentId= p.id";

            List<category> categories = db.categories.SqlQuery(sql).ToList<category>();
            List<Category> cates = new List<Category>();
            foreach (category c in categories)
            {
                cates.Add(new Category(c));
            }

            return cates;
        }
    }
}