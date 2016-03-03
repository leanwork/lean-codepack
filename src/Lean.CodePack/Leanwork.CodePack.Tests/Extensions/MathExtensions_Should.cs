using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Leanwork.CodePack;

namespace Leanwork.CodePack.Tests.Extensions
{
    [TestClass]
    public class MathExtensions_Should
    {
        [TestMethod]
        public void Returns_percentage_amount()
        {
            //arrange
            int total = 120;
            int amount = 60;

            //act
            decimal expected = 50;
            decimal result = total.Percentage(amount);

            //assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Returns_percentage_amount_equals_zero()
        {
            //arrange
            int total = 0;
            int amount = 60;

            //act
            decimal expected = 0;
            decimal result = total.Percentage(amount);

            //assert
            Assert.AreEqual(expected, result);
        }
    }
}
