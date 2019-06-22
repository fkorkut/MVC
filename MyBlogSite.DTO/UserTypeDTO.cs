using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogSite.DTO
{
    public class UserTypeDTO : IEntity
    {
        public byte UserTypeId { get; set; }
        public string UserTypeName { get; set; }
    }
}
