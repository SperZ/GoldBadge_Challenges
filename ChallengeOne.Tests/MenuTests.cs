using System;
using System.Collections.Generic;
using ChallengeOne.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChallengeOne.Tests
{
    [TestClass]
    public class MenuTests
    {

        private MenuItem _newItem; // create a field of the menuItem object 
        private MenuItemRepository _repo;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new MenuItemRepository();
            _newItem = new MenuItem(5, "Hard Taco Meal", "2 Hard Tacos", new List<string> { "tortilla", "meat", " cheese" }, 3.45);
            _repo.AddMenuItems(_newItem); // adding the menuItem newItem to the repository so the repository can preform the methods
        }

        [TestMethod]
        public void AddItemToMenu_ShouldReturnCorrect()
        {
            bool newItemAdded = _repo.AddMenuItems(_newItem);


            Assert.IsTrue(newItemAdded);
        }

        [TestMethod]

        public void GetMenuItems_ShouldReturnTrue()
        {
            _repo.AddMenuItems(_newItem);

            List<MenuItem> menuItems = _repo.ReturnMenuItems();

            bool menuHasItems = menuItems.Contains(_newItem);

            Assert.IsTrue(menuHasItems);
        }

        [TestMethod]

        public void GetMenuItemByMealNumber_ShouldReturnTrue()
        {
            MenuItem mealNumber = _repo.GetMenuItemByMealNumber(5);

            Assert.AreEqual(_newItem, mealNumber);


        }

        [TestMethod]

        public void RemoveItems()
        {

            //Act
            bool wasDeleted = _repo.RemoveMenuItem(_newItem);

            //assert
            Assert.IsTrue(wasDeleted);
        }




    }


}
