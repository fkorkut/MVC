using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyBlogSite.Service;

namespace MyBlogSite.UnitTest
{
    [TestClass]
    public class CommnetUT
    {
        private CommentService service;
        [TestInitialize]
        public void Setup()
        {
            service = new CommentService();
        }

        [TestMethod]
        public void GetComments()
        {
            int id =1;

            var result = service.GetComments(id);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetConfirmed()
        {
            int id = 3;//yorum id'i

            var result = service.GetConfirmed(id);
            Assert.IsNotNull(result);
        }
    }
}
