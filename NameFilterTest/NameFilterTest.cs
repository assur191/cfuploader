using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CFUploader.RegExFilters;
using System.Collections;

namespace NameFilterTest
{
    [TestClass]
    public class NameFilterTest
    {
        [TestMethod]
        public void ItReturnsFirstAndLastNameFromNameWithoutComma()
        {
            //Arrange
            var name = "Eyvind Alnaes";
            var firstName = "Eyvind";
            var lastName = "Alnaes";            

            //Act
            Hashtable names = NameFilter.GetNames(name);

            //Assert
            Assert.AreEqual(firstName, names["first_name"]);
            Assert.AreEqual(lastName, names["last_name"]);            
        }

        [TestMethod]
        public void ItReturnsFirstMiddleAndLastNameFromNameWithoutComma()
        {
            //Arrange
            var name = "Eyvind test Alnaes";
            var firstName = "Eyvind";
            var lastName = "Alnaes";
            var middleName = "test";

            //Act
            Hashtable names = NameFilter.GetNames(name);

            //Assert
            Assert.AreEqual(firstName, names["first_name"]);
            Assert.AreEqual(lastName, names["last_name"]);
            Assert.AreEqual(middleName, names["middle_name"]);
        }

        [TestMethod]
        public void ItReturnsFirstAndLastNameFromNameWithComma()
        {
            //Arrange
            var name = "Alnaes, Eyvind";
            var firstName = "Eyvind";
            var lastName = "Alnaes";

            //Act
            Hashtable names = NameFilter.GetNames(name);

            //Assert
            Assert.AreEqual(firstName, names["first_name"]);
            Assert.AreEqual(lastName, names["last_name"]);
        }

        [TestMethod]
        public void ItReturnsFirstMiddleAndLastNameFromNameWithComma()
        {
            //Arrange
            var name = "Alnaes, Eyvind test";
            var firstName = "Eyvind";
            var lastName = "Alnaes";
            var middleName = "test";

            //Act
            Hashtable names = NameFilter.GetNames(name);

            //Assert
            Assert.AreEqual(firstName, names["first_name"]);
            Assert.AreEqual(lastName, names["last_name"]);
            Assert.AreEqual(middleName, names["middle_name"]);
        }
    }
}
