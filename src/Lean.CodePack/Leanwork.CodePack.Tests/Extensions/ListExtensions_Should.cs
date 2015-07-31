using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Leanwork.CodePack;

namespace Leanwork.CodePack.Tests.Extensions
{
    [TestClass]
    public class ListExtensions_Should
    {
        [TestMethod]
        public void Convert_list_of_string_to_int()
        {
            //arrange
            List<string> numbers = new List<string> { "1", "2", "100", "53" };

            //act
            List<int> expected = numbers.StringToInt();
            int[] values = expected.ToArray();

            //assert
            Assert.AreEqual(1, values[0]);
            Assert.AreEqual(2, values[1]);
            Assert.AreEqual(100, values[2]);
            Assert.AreEqual(53, values[3]);
        }

        [TestMethod]
        public void Convert_list_of_string_to_int_null()
        {
            //arrange
            List<string> numbers = new List<string> { "1", "a", "100", "53", "" };

            //act
            List<int?> expected = numbers.StringToIntNull();
            int?[] values = expected.ToArray();

            //assert
            Assert.AreEqual(1, values[0]);
            Assert.IsNull(values[1]);
            Assert.AreEqual(100, values[2]);
            Assert.AreEqual(53, values[3]);
            Assert.IsNull(values[4]);
        }

        [TestMethod]
        public void Convert_list_of_string_to_datetime()
        {
            //arrange
            List<string> dates = new List<string> 
            { 
                "2013-01-01", 
                "2013-04-28 19:00:00"
            };

            //act
            List<DateTime> expected = dates.StringToDate();
            DateTime[] values = expected.ToArray();

            //assert
            Assert.AreEqual("2013-01-01", values[0].ToString("yyyy-MM-dd"));
            Assert.AreEqual("2013-04-28 19:00:00", values[1].ToString("yyyy-MM-dd HH:mm:ss"));
        }

        [TestMethod]
        public void Convert_list_of_int_to_string()
        {
            //arrange
            List<int> numbers = new List<int> { 1, 2, 100, 53 };

            //act
            List<string> expected = numbers.IntToString();
            string[] values = expected.ToArray();

            //assert
            Assert.AreEqual("1", values[0]);
            Assert.AreEqual("2", values[1]);
            Assert.AreEqual("100", values[2]);
            Assert.AreEqual("53", values[3]);
        }
    }
}
