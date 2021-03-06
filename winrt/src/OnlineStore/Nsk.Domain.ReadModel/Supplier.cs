//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Nsk.Domain.ReadModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Supplier
    {
        public Supplier()
        {
            this.Products = new HashSet<Product>();
            this.ContactInfo = new ContactInfo();
            this.MainPostalAddress = new PostalAddress();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string HomePage { get; set; }
    
        public ContactInfo ContactInfo { get; set; }
        public PostalAddress MainPostalAddress { get; set; }
    
        public virtual ICollection<Product> Products { get; set; }
    }
}
