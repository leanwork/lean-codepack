using System;
using System.Collections.Generic;
using JovemCar;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Leanwork.CodePack;
using Leanwork.CodePack.Dynamic;

namespace Leanwork.CodePack.Tests.Extensions
{
    [TestClass]
    public class ObjectExtensions_Should
    {
        /// <summary>
        /// Class created only for test purposes
        /// </summary>
        public class Person
        {
            public string FirstName { get; set; }

            public string LastName { get; set; }
        }

        [TestMethod]
        public void Returns_empty_values_a_null_object()
        {
            //arrange
            Person person = null;

            //act
            Dictionary<string, string> values = person.GetPropertiesValues();

            //assert
            Assert.AreEqual(0, values.Count);
        }

        [TestMethod]
        public void Returns_values_a_object()
        {
            //arrange
            Person person = new Person
            {
                FirstName = "Bill",
                LastName = "Gates"
            };

            //act
            Dictionary<string, string> values = person.GetPropertiesValues();

            //assert
            Assert.AreEqual(2, values.Count);
            Assert.AreEqual("Bill", values["FirstName"]);
            Assert.AreEqual("Gates", values["LastName"]);
        }

        [TestMethod]
        public void Returns_empty_values_a_anonymous_null_object()
        {
            //arrange
            var person = new { };

            //act
            Dictionary<string, string> values = person.GetPropertiesValues();

            //assert
            Assert.AreEqual(0, values.Count);
        }

        [TestMethod]
        public void Returns_values_a_anonymous_object()
        {
            //arrange
            var person = new
            {
                FirstName = "Bill",
                LastName = "Gates"
            };

            //act
            Dictionary<string, string> values = person.GetPropertiesValues();

            //assert
            Assert.AreEqual(2, values.Count);
            Assert.AreEqual("Bill", values["FirstName"]);
            Assert.AreEqual("Gates", values["LastName"]);
        }

        [TestMethod]
        public void Returns_empty_values_a_null_dynamic_object()
        {
            //arrange
            dynamic person = null;

            //act
            Dictionary<string, object> values = ((object)person).GetDynamicValues();

            //assert
            Assert.AreEqual(0, values.Count);
        }

        [TestMethod]
        public void Returns_empty_values_if_dynamic_object_is_not_ExpandableObject_type()
        {
            //arrange
            dynamic person = new System.Dynamic.ExpandoObject();
            person.FirstName = "Bill";
            person.LastName = "Gates";

            //act
            Dictionary<string, object> values = ((object)person).GetDynamicValues();

            //assert
            Assert.AreEqual(0, values.Count);
        }

        [TestMethod]
        public void Returns_values_a_dynamic_object()
        {
            //arrange
            dynamic person = new ExpandableObject();
            person.FirstName = "Bill";
            person.LastName = "Gates";

            //act
            Dictionary<string, object> values = ((object)person).GetDynamicValues();

            //assert
            Assert.AreEqual(2, values.Count);
            Assert.AreEqual("Bill", values["FirstName"]);
            Assert.AreEqual("Gates", values["LastName"]);
        }
    }    
}
