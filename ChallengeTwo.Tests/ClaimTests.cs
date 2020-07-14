using System;
using System.Collections.Generic;
using ChallengeTwo.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChallengeTwo.Tests
{
    [TestClass]
    public class ClaimTests
    {
        private Claim _claimItem;
        private ClaimRepository _claimRepo;

        [TestInitialize]
        public void Arrange()
        {
            _claimRepo = new ClaimRepository();
            _claimItem = new Claim(5, TypeOfClaim.Car, "Car theft", 10000d, new DateTime(2020, 6, 5), new DateTime(2020, 7, 1));
            _claimRepo.AddClaimToQeue(_claimItem);
        }
        

        [TestMethod]
        public void AddIClaimToQueue_ShouldReturnCorrect()
        {
            //Act
            bool newItemAdded = _claimRepo.AddClaimToQeue(_claimItem);
            //Assert
            Assert.IsTrue(newItemAdded);
        }

        [TestMethod]
        public void GetClaimItems_ShouldReturnTrue()
        {
            Queue<Claim> queueItems = _claimRepo.GetAllClaims();
            bool hasClaimItem = queueItems.Contains(_claimItem);
            //Assert
            Assert.IsTrue(hasClaimItem);
        }

        [TestMethod]
        public void ClaimNextInQueue_ShouldReturnTrue()
        {
            //
            Claim claimOne = _claimRepo.ClaimNextInQueue();

            Assert.AreEqual(_claimItem, claimOne);
        }

        [TestMethod]

        public void ItemPulledFrom__ShouldReturnTrue()
        {
            bool claimPulled = _claimRepo.PullItemFromQueue();

            Assert.IsTrue(claimPulled);
        }

    }
}
