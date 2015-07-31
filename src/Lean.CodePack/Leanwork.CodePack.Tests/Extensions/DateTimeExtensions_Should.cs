using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Leanwork.CodePack;

namespace Leanwork.CodePack.Tests.Extensions
{
    [TestClass]
    public class DateTimeExtensions_Should
    {
        [TestMethod]
        public void Returns_true_if_date_in_range()
        {
            //arrange
            DateTime date1 = DateTime.Now.AddDays(-1);
            DateTime date2 = DateTime.Now.AddDays(1);

            //act
            bool result = DateTime.Now.InRange(date1, date2);

            //assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Returns_false_if_date_is_not_in_range()
        {
            //arrange
            DateTime date1 = DateTime.Now.AddDays(-10);
            DateTime date2 = DateTime.Now.AddDays(-5);

            //act
            bool result = DateTime.Now.InRange(date1, date2);

            //assert
            Assert.IsFalse(result);
        }
    }
}
