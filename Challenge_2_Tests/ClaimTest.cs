using System;
using System.Collections.Generic;
using Challenge_2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenge_2_Tests
{
    [TestClass]
    public class ClaimTest
    {
        [TestMethod]
        public void ClaimRepository_GetClaims_ShouldReturnEqualList()
        {
            ClaimRepository claimRepo = new ClaimRepository();
            Queue<Claim> claimQueue = new Queue<Claim>();
            claimRepo.AddClaim(ClaimType.Car, "desc", 30m, DateTime.Now, DateTime.Now);

            claimQueue = claimRepo.GetClaims();

            int expected = 1;
            int actual = claimQueue.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ClaimRepository_AddClaim_ShouldReturnQueueOfOne()
        {
            ClaimRepository claimRepo = new ClaimRepository();
            Queue<Claim> claimQueue = new Queue<Claim>();

            claimRepo.AddClaim(ClaimType.Car, "desc", 30m, DateTime.Now, DateTime.Now);
            claimQueue = claimRepo.GetClaims();

            int expected = 1;
            int actual = claimQueue.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ClaimRepository_CountDown_ShouldCountDown()
        {
            ClaimRepository claimRepo = new ClaimRepository();
            claimRepo.CountDown();

            int expected = -1;
            int actual = claimRepo.claimCount;

            Assert.AreEqual(expected, actual);
        }
    }
}
