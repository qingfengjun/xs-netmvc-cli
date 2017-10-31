using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xiaoshuai.Common;

namespace xiaoshuai.Test
{
    [TestClass]
    public class MailHelperTest
    {
        [TestMethod]
        public void MailTest()
        {
            MailDto dto = new MailDto();
            dto.Subject = "您的文章《九宫山游记》有新的评论，请注意查收！";
            dto.Body = "中国武汉网友：写的真心不错！";
            Assert.AreEqual(MailHelper.Send(dto), true);
        }
    }
}
