using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyBlogSite.DTO;
using MyBlogSite.Service;

namespace MyBlogSite.UnitTest
{
    [TestClass]
    public class CategoryUT
    {
        private CategoryService service;
        [TestInitialize]
        public void SetUp()
        {
            service = new CategoryService();
        }
        [TestMethod]
        public void SaveCategory()
        {
            CategoryDTO category1 = new CategoryDTO { CategoryName = "Technology" };
                   
            var result = service.Save(category1);

            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void GetCategories()
        {
            var result = service.GetCategories();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Update()
        {

            CategoryDTO category4 = new CategoryDTO
            {
                CategoryId = 1,
                CategoryName = "Shopping",
                RecordStatusId = 1
            };


            var result = service.Update(category4);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetCategory()
        {
            int id = 2;
            var result = service.Get(id);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetTop5Categories()
        {

            var result = service.GetTop5Categories();

            Assert.IsNotNull(result);
        }
    }
}
