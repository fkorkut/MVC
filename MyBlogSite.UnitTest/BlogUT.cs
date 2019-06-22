using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyBlogSite.DTO;
using MyBlogSite.Service;

namespace MyBlogSite.UnitTest
{
    [TestClass]
    public class BlogUT
    {
        private BlogService service;
        [TestInitialize]
        public void SetUp()
        {

            service = new BlogService();
        }

        [TestMethod]
        public void GetBlogs()
        {
            var result = service.GetBlogs();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void SaveBlog()
        {
            BlogDTO blog = new BlogDTO
            {

                Title = "Iphone 15",
                BlogContent = "ModelViewController ModelViewController ModelViewController ModelViewController ",
                UserId = 7,
                CategoryId = 1,//ilk kategori eklemeliyiz.
                ImagePath = "h"

            };

            var result = service.Save(blog);
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void Confirm()
        {
            int id = 5;

            var result = service.Confirm(id);
            Assert.IsTrue(result);
        }


        [TestMethod]
        public void Update()
        {
            BlogDTO blog = new BlogDTO
            {
                BlogId = 8,
                IsConfirmed = true,
                CreatedDate = DateTime.Now,
                RecordStatusId = 1,
                Title = "Iphone",
                BlogContent = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus ac finibus ipsum, ac dictum sapien. Nunc ligula libero, sollicitudin sit amet viverra vel, egestas vitae sem. Donec arcu velit, mattis ut ligula eu, tristique elementum ante. Suspendisse ut mi tortor. Nunc eu pretium augue, sit amet ultricies elit. Sed pretium turpis leo, tristique auctor dui tempus vitae. Proin ut nisl sit amet sem faucibus fermentum. Suspendisse sagittis semper erat, sit amet pharetra enim. Nunc sagittis, tortor in laoreet faucibus, libero felis hendrerit ante, tristique auctor lacus nibh eget ipsum. Donec ut risus in eros rutrum suscipit. Etiam pretium a libero vel pharetra. Nulla fringilla, nunc et pulvinar finibus, quam massa tincidunt ipsum, sed ullamcorper augue ligula a diam.Phasellus nisl libero," +
                "commodo a pulvinar quis," +
               " mattis at eros.Nam ullamcorper eros turpis," +
               " vehicula aliquam velit facilisis a.Etiam lectus lorem," +
                "sodales eget convallis id," +
               " pharetra faucibus nunc.Sed eu volutpat lectus," +
               " vitae consectetur tellus.Duis malesuada elit metus," +
               " sit amet iaculis ex fringilla non.Sed laoreet," +
               " ante id vulputate venenatis," +
               " orci orci tempor massa," +
                "a fermentum massa metus non dui.Curabitur et ornare leo.Nulla ultrices tortor at felis varius," +
               " non tincidunt magna finibus." +

"Orci varius natoque penatibus et magnis dis parturient montes," +
               " nascetur ridiculus mus.Proin fringilla justo nibh," +
               " ac facilisis felis feugiat a.Donec tincidunt nulla eget sodales placerat.Proin aliquam," +
                "nibh eu suscipit fermentum," +
               " nunc odio eleifend felis," +
               " a pretium sem ante aliquet dolor.Pellentesque sollicitudin," +
                "magna a malesuada egestas," +
                "odio enim ullamcorper est," +
               " vel placerat est massa eget orci.Integer quis laoreet enim.Pellentesque habitant morbi",
                UserId = 7,
                CategoryId = 1,
                ImagePath = "h"

            };

            var result = service.Update(blog);
            Assert.IsTrue(result);
        }


        [TestMethod]
        public void GetBlogsByCategory()
        {
            //kategori id
            int id = 2;

            var result = service.GetBlogsByCategory(id);
            Assert.IsNotNull(result);
        }
    }
}
