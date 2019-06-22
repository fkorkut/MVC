using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyBlogSite.DTO;
using MyBlogSite.Service;

namespace MyBlogSite.UnitTest
{
    [TestClass]
    public class UserUT
    {
        private UserService service;
        [TestInitialize]

        public void SetUp()
        {
            service = new UserService();
        }
        [TestMethod]
        public void RegisterMember()
        {
            UserDTO user = new UserDTO
            {

                FirstName = "Firdevs Gül ",
                LastName = "Korkut",
                MobilePhone = "5556667788",
                TownId = 1166,
                EmailAddress = "firdevsgulkorkut@gmail.com",
                Password = "12dxwwqq",
                UserTypeID = 2,



            };
            var result = service.Register(user);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void List()
        {
            var result = service.List();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Get()
        {
            int id = 7;
            var result = service.Get(id);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Verify()
        {
            int id = 7;
            string token = "9e42528b-2c94-4553-9705-3f4e7d53ea94";
            var result = service.Verify(token);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Update()
        {
            UserDTO user = new UserDTO
            {
                UserId = 7,
                FirstName = "Firdevs Gül ",
                LastName = "Korkut",
                MobilePhone = "5556667788",
                TownId = 1166,
                EmailAddress = "firdevsgulkorkut@gmail.com",
                Password = "1wqq",
                UserTypeID = 2,
                RecordStatusId = 1,
                CreatedDate = DateTime.Now,
                IsEmailVerified = true,
                Token = "9e42528b-2c94-4553-9705-3f4e7d53ea94",
                TokenValidUntil = DateTime.Now.AddDays(1)

            };
            var result = service.Update(user);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Authenticate()
        {
            string email = "firdevsgulkorkut@gmail.com";
            string password = "1wqq";

            var result = service.Authenticate(email, password);
            Assert.IsNotNull(result);
        }
    }
}
