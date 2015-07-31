using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Leanwork.CodePack;

namespace Leanwork.CodePack.Tests.Extensions
{
    [TestClass]
    public class BooleanExtensions_Should
    {
        [TestMethod]
        public void Returns_yes_if_value_is_true()
        {
            //arrange
            bool value = true;

            //act
            string result = value.ToLiteral("YES", "NO");

            //assert
            Assert.AreEqual("YES", result);
        }

        [TestMethod]
        public void Returns_no_if_value_is_false()
        {
            //arrange
            bool value = false;

            //act
            string result = value.ToLiteral("YES", "NO");

            //assert
            Assert.AreEqual("NO", result);
        }
    }
}
