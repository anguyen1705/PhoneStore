//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PhoneStore.Models.db
{
    using System;
    using System.Collections.Generic;
    
    public partial class productdetail
    {
        public productdetail()
        {
            this.importproductdetails = new HashSet<importproductdetail>();
            this.orderdetails = new HashSet<orderdetail>();
            this.storages = new HashSet<storage>();
        }
    
        public int id { get; set; }
        public int productId { get; set; }
        public int specId { get; set; }
        public int colorId { get; set; }
        public decimal price { get; set; }
        public string imgUrl { get; set; }
        public int activeFlag { get; set; }
        public System.DateTime createDate { get; set; }
        public System.DateTime updateDate { get; set; }
    
        public virtual color color { get; set; }
        public virtual ICollection<importproductdetail> importproductdetails { get; set; }
        public virtual ICollection<orderdetail> orderdetails { get; set; }
        public virtual product product { get; set; }
        public virtual spec spec { get; set; }
        public virtual ICollection<storage> storages { get; set; }
        public int status;
    }
}
