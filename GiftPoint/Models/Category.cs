//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GiftPoint.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Category
    {
        public int CategoryId { get; set; }
        public string CategoryTitle { get; set; }
        public int ParentId { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<int> LastUpdatedBy { get; set; }
        public Nullable<System.DateTime> LastUpdatedOn { get; set; }
    }
}
