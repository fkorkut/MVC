//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyblogSite.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Comment
    {
        public int CommentId { get; set; }
        public int BlogId { get; set; }
        public int UserId { get; set; }
        public string CommentContent { get; set; }
        public bool IsConfirmed { get; set; }
        public System.DateTime CreatedDate { get; set; }
    
        public virtual Blog Blog { get; set; }
        public virtual User User { get; set; }
    }
}