using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Leanwork.CodePack.Dynamic;

namespace Leanwork.CodePack.Tests.Dynamic
{
    [TestClass]
    public class CustomObject_Should
    {
        /// <summary>
        /// Class created only for test purposes
        /// </summary>
        public class Person : CustomObject
        {
        }

        [TestMethod]
        public void Gets_and_sets_using_custom_object()
        {
            //arrange
            Person person = new Person();

            //act
            person.Custom.FirstName = "Bill";
            person.Custom.LastName = "Gates";

            //assert
            Assert.AreEqual("Bill", person.Custom.FirstName);
            Assert.AreEqual("Gates", person.Custom.LastName);
        }

        [TestMethod]
        public void Gets_and_sets_of_custom_object_using_based_index_access()
        {
            //arrange
            Person person = new Person();

            //act
            person["FirstName"] = "Bill";
            person["LastName"] = "Gates";

            //assert
            Assert.AreEqual("Bill", person["FirstName"]);
            Assert.AreEqual("Gates", person["LastName"]);
        }
    }
}
