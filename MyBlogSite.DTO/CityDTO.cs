using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogSite.DTO
{
    public class CityDTO : IEntity
    {
        public int CityID { get; set; }
        public string CityName { get; set; }
    }
}
