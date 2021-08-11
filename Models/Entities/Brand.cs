using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PhoneStore.Models.db;

namespace PhoneStore.Models.Entities
{
    public class Brand
    {
        public Brand(brand brand)
        {
            this.id = brand.Id;
            this.name = brand.name;
        }

        public Brand(int id, String name)
        {
            this.id = id;
            this.name = name;
        }

        public int id { get; set; }
        public string name { get; set; }
        public int activeFlag { get; set; }
        public System.DateTime createDate { get; set; }
        public System.DateTime updateDate { get; set; }
    }
}