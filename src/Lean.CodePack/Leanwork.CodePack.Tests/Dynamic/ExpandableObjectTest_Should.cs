using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Leanwork.CodePack.Dynamic;

namespace Leanwork.CodePack.Tests.Dynamic
{
    [TestClass]
    public class ExpandableObjectTest_Should
    {
        [TestMethod]
        public void Return_the_same_value_was_set()
        {
            dynamic test = new ExpandableObject();

            var expected = "Jovem Car";
            test.Company = expected;

            Assert.AreEqual(expected, test.Company);
            Assert.AreEqual(expected, test["Company"]);
        }

        [TestMethod]
        public void Return_null_if_property_was_not_definied()
        {
            dynamic test = new ExpandableObject();
            Assert.IsNull(test.Company);
            Assert.IsNull(test["Company"]);
        }

        [TestMethod]
        public void Return_the_same_values_when_object_was_created_with_default_values()
        {
            var company = "Jovem Car";
            var city = "Londrina";

            var values = new Dictionary<string, object>();
            values.Add("Company", company);
            values.Add("City", city);

            dynamic test = new ExpandableObject(values);

            Assert.AreEqual(company, test.Company);
            Assert.AreEqual(company, test["Company"]);
            Assert.AreEqual(city, test.City);
            Assert.AreEqual(city, test["City"]);
        }        
    }
}
