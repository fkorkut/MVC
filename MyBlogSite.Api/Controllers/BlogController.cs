using MyBlogSite.DTO;
using MyBlogSite.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MyBlogSite.Api.Controllers
{
    public class BlogController : ApiController
    {
        [HttpPost]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult Save(BlogDTO obj)
        {
            using (BlogService blogService = new BlogService())
            {
                obj.ImagePath = "";
                var result = blogService.Save(obj);

                if (result > 0)
                {
                    return Content(HttpStatusCode.OK, true);
                }
                else
                {
                    return InternalServerError();
                }
            }
        }


    }
}