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
    
    public partial class user
    {
        public user()
        {
            this.comments = new HashSet<comment>();
            this.orders = new HashSet<order>();
            this.roleusers = new HashSet<roleuser>();
        }
    
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public int activeFlag { get; set; }
        public System.DateTime createDate { get; set; }
        public System.DateTime updateDate { get; set; }
    
        public virtual ICollection<comment> comments { get; set; }
        public virtual ICollection<order> orders { get; set; }
        public virtual ICollection<roleuser> roleusers { get; set; }
    }
}