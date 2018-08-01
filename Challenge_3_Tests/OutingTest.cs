using System;
using System.Collections.Generic;
using Challenge_3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenge_3_Tests
{
    [TestClass]
    public class OutingTest
    {
        [TestMethod]
        public void OutingRepository_AddOuting_ShouldReturnListOf1()
        {
            OutingRepository outingRepo = new OutingRepository();
            List<Outing> testList = outingRepo.GetList();
            outingRepo.AddOuting(EventType.AmusementPark, 5, DateTime.Today, 5m, 20m);

            var expected = 1;
            var actual = outingRepo.GetList().Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OutingRepository_TotalCost_ShouldReturnTotal()
        {
            OutingRepository outingRepo = new OutingRepository();
            List<Outing> testList = outingRepo.GetList();
            outingRepo.AddOuting(EventType.AmusementPark, 5, DateTime.Today, 5m, 20m);
            outingRepo.AddOuting(EventType.AmusementPark, 5, DateTime.Today, 5m, 20m);

            var expected = 40m;
            var actual = outingRepo.TotalCost();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void OutingRepository_GetCostByType_ShouldReturnTypeTotalCost()
        {
            OutingRepository outingRepo = new OutingRepository();
            List<Outing> testList = outingRepo.GetList();
            outingRepo.AddOuting(EventType.AmusementPark, 5, DateTime.Today, 5m, 150m);
            outingRepo.AddOuting(EventType.Bowling, 5, DateTime.Today, 5m, 30m);

            var expected = 150m;
            var actual = outingRepo.GetCostByType(EventType.AmusementPark);

            Assert.AreEqual(expected, actual);
        }
    }
}
