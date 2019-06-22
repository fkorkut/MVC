using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogSite.DTO
{
    public class NewsLetterDTO : IEntity
    {
        public int NewsLetterId { get; set; }
        public string EmailAddress { get; set; }
    }
}
