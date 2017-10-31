using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using xiaoshuai.Repository;
using xiaoshuai.Repository.Entity;

namespace xiaoshuai.Test
{
    [TestClass]
    public class EFHelperTest
    {
        [TestMethod]
        public void InserTest()
        {
            pub_CategoryEntity category = new pub_CategoryEntity();
            category.CategoryName = "随笔";
            category.CategoryRemark = "人生的一些感悟";
            category.SortId = 0;
            Assert.AreEqual(EFHelper.Insert<pub_CategoryEntity>(category), 1);
        }

        [TestMethod]
        public void InserErrorTest()
        {
            pub_CategoryEntity category = new pub_CategoryEntity();
            category.CategoryName = "随笔aaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            category.CategoryRemark = "人生的一些感悟";
            category.SortId = 0;
            Assert.AreEqual(EFHelper.Insert<pub_CategoryEntity>(category), 0);
        }

        [TestMethod]
        public void UpdateTest()
        {
            pub_CategoryEntity category = new pub_CategoryEntity();
            category.Id = 1;
            category.CategoryName = "随笔11";
            category.CategoryRemark = "人生的一些感悟11";
            category.SortId = 2;
            Assert.AreEqual(EFHelper.Update<pub_CategoryEntity>(category), 1);
        }

        [TestMethod]
        public void DeleteTest()
        {
            Assert.AreEqual(EFHelper.Delete<pub_CategoryEntity>(x => x.CategoryName == "随笔"), 1);
        }

        [TestMethod]
        public void QueryTest()
        {
           var s= EFHelper.Query<pub_CategoryEntity>(x => x.CategoryName == "随笔");
        }
    }
}
