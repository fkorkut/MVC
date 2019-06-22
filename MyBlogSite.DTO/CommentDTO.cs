using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogSite.DTO
{
    public class CommentDTO : IEntity
    {
        public int CommentId { get; set; }
        public int BlogId { get; set; }
        public int UserId { get; set; }
        public string CommentContent { get; set; }
        public bool IsConfirmed { get; set; }
        public System.DateTime CreatedDate { get; set; }
    }
}

