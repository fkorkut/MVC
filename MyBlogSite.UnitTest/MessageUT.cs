using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyBlogSite.DTO;
using MyBlogSite.Service;

namespace MyBlogSite.UnitTest
{
    [TestClass]
    public class MessageUT
    {
        private MessageService service;

        [TestInitialize]
        public void SetUp()
        {
            service = new MessageService();
        }
        [TestMethod]
        public void SendMessage()
        {
            MessageDTO message = new MessageDTO
            {
                SenderName = "Firdevs Gül",
                SenderEmail = "frdvskrkt@gmail.com",
                MessageContent = "katılmıyorum."
            };

            var result = service.SendMessage(message);
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void List()
        {
            var result = service.List();
            Assert.IsNotNull(result);

        }
    }
}
