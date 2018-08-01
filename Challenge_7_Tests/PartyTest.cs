using System;
using System.Collections.Generic;
using Challenge_7;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenge_7_Tests
{
    [TestClass]
    public class PartyTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            PartyRepository boothRepo = new PartyRepository();
            List<Party> testPartyList = boothRepo.GetParties();
            int partyNumber = 1;
            var testFoodList = new List<Food>()
            {
                new Food("Hamburger", 20, 3.50m),
            };
            var testBoothList = new List<Booth>()
            {
                new Booth(BoothType.Food,testFoodList, 25.00m),
            };
            Party testParty = new Party(testBoothList, partyNumber);
            testPartyList.Add(testParty);

            var expected = 1;
            var actual = testPartyList.Count;

            Assert.AreEqual(expected, actual);
        }
    }
}
