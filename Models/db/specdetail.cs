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
    
    public partial class specdetail
    {
        public int id { get; set; }
        public int specId { get; set; }
        public string name { get; set; }
        public string value { get; set; }
        public int activeFlag { get; set; }
        public System.DateTime createDate { get; set; }
        public System.DateTime updateDate { get; set; }
    
        public virtual spec spec { get; set; }
    }
}