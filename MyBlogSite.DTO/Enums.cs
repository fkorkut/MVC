using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlogSite.DTO
{
    public class Enums
    {
        public enum UserType : byte
        {
            Admin = 1,
            GuestAuthor = 2,
            Member = 3
        }

        public enum RecordStatus : byte
        {
            Aktif = 1,
            Pasif = 2
        }
    }
}

