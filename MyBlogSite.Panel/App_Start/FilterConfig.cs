﻿using System.Web;
using System.Web.Mvc;

namespace MyBlogSite.Panel
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
