using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyBlogSite.Service;

namespace MyBlogSite.UnitTest
{
    [TestClass]
    public class DefinitionUT
    {
        private DefinitionService service;
        [TestInitialize]
        public void Setup()
        {
            service = new DefinitionService();
        }
        [TestMethod]
        public void GetCategories()
        {
            var result = service.GetCategories();

            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void GetRecordStatus()
        {
            var result = service.GetRecordStatuses();
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void GetCities()
        {
            var result = service.GetCities();
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void GetTownsByCityId()
        {
            int id =77;//cityId olmalı
            var result = service.GetTownsByCity(id);
            Assert.IsNotNull(result);
        }
    }
}
