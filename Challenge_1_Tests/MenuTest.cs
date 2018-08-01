using System;
using System.Collections.Generic;
using Challenge_1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenge_1_Tests
{
    [TestClass]
    public class MenuTest
    {
        [TestInitialize]
        public void Arrange()
        {
        }

        [TestMethod]
        public void MenuRepository_DisplayList_ShouldReturnEqualLists()
        {
            MenuRepository testRepo = new MenuRepository();
            List<Menu> testMenu = testRepo.DisplayList();
            Menu menu = new Menu(1, "Hamburger", "HamburgerDesc", "HamburgerIngr", 55.50m);
            testRepo.AddItem(menu);

            var expected = 1;
            var actual = testMenu.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MenuRepository_AddItem_ShouldReturnListOfOne()
        {
            MenuRepository testRepo = new MenuRepository();
            List<Menu> testMenu = testRepo.DisplayList();
            Menu menu = new Menu(1, "Hamburger", "HamburgerDesc", "HamburgerIngr", 55.50m);
            testRepo.AddItem(menu);

            var expected = 1;
            var actual = testMenu.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MenuRepository_RemoveItem_ShouldReturnEmptyList()
        {
            MenuRepository testRepo = new MenuRepository();
            List<Menu> testMenu = testRepo.DisplayList();
            Menu menu = new Menu(1, "Hamburger", "HamburgerDesc", "HamburgerIngr", 55.50m);
            testRepo.AddItem(menu);

            testRepo.RemoveItem(menu);

            var expected = 0;
            var actual = testMenu.Count;

            Assert.AreEqual(expected, actual);
        }
    }
}
