using System;
using System.Collections.Generic;
using ChallengeThree.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChallengeThree.Tests
{
    [TestClass]
    public class BadgeTests
    {
        private Badge _badge;
        private BadgeRepository _badgeRepo;

        [TestInitialize]
        public void Arrange() 
        {
            _badge = new Badge(22, new List<string> { "C","P0" });
            _badgeRepo = new BadgeRepository();
        }

        [TestMethod]
        public void AddBadgeToDictionar_ShouldReturnTrue()
        {
            bool badgeWasAdded = _badgeRepo.AddBadgeToDictionary(_badge);

            Assert.IsTrue(badgeWasAdded);
        }

        [TestMethod]
        public void GetAllBadges_ShouldReturnTrue()
        {
            _badgeRepo.AddBadgeToDictionary(_badge);
            Dictionary<int, List<string>> newDictionary = _badgeRepo.GetAllBadges();
            bool dictionaryContents = newDictionary.ContainsKey(22);
            Assert.IsTrue(dictionaryContents);
        }
    }
}
