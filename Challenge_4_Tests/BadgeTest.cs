using System;
using System.Collections.Generic;
using Challenge_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenge_4_Tests
{
    [TestClass]
    public class BadgeTest
    {
        [TestMethod]
        public void BadgeRepository_CreateBadge_ShouldReturnDictionaryWithBadge()
        {
            BadgeRepository badgeRepo = new BadgeRepository();
            Dictionary<int, List<string>> testDictionary = badgeRepo.GetDictionary();
            List<string> testList = new List<string>();
            testList.Add("testString");

            badgeRepo.CreateBadge(1,testList);

            var expected = 1;
            var actual = testDictionary.Count;

            Assert.AreEqual(expected, actual);
        }
    }
}
