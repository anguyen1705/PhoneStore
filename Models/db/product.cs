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
    
    public partial class product
    {
        public product()
        {
            this.comments = new HashSet<comment>();
            this.discounts = new HashSet<discount>();
            this.importproducts = new HashSet<importproduct>();
            this.productdetails = new HashSet<productdetail>();
            this.vouchers = new HashSet<voucher>();
            this.vouchers1 = new HashSet<voucher>();
        }
    
        public int id { get; set; }
        public int categoryId { get; set; }
        public int brandId { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public string description { get; set; }
        public string imgMain { get; set; }
        public int activeFlag { get; set; }
        public System.DateTime createDate { get; set; }
        public System.DateTime updateDate { get; set; }
    
        public virtual brand brand { get; set; }
        public virtual category category { get; set; }
        public virtual ICollection<comment> comments { get; set; }
        public virtual ICollection<discount> discounts { get; set; }
        public virtual ICollection<importproduct> importproducts { get; set; }
        public virtual ICollection<productdetail> productdetails { get; set; }
        public virtual ICollection<voucher> vouchers { get; set; }
        public virtual ICollection<voucher> vouchers1 { get; set; }
    }
}
