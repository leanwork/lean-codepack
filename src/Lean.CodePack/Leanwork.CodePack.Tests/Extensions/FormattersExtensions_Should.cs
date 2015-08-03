using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leanwork.CodePack;

namespace Leanwork.CodePack.Tests.Extensions
{
    [TestClass]
    public class FormattersExtensions_Should
    {
        [TestMethod]
        public void Apply_format_string_to_brazilian_phone_number_with_10_digits()
        {
            //arrange
            string value = "4399990000";

            //act
            string result = value.BrazilianPhoneNumber();

            //assert
            Assert.AreEqual("(43) 9999-0000", result);
        }

        [TestMethod]
        public void Apply_format_string_to_brazilian_phone_number_with_11_digits()
        {
            //arrange
            string value = "43999990000";

            //act
            string result = value.BrazilianPhoneNumber();

            //assert
            Assert.AreEqual("(43) 99999-0000", result);
        }

        [TestMethod]
        public void Not_apply_format_string_to_brazilian_phone_number_for_incorrect_value()
        {
            //arrange
            string value = "999990000";

            //act
            string result = value.BrazilianPhoneNumber();

            //assert
            Assert.AreEqual("999990000", result);
        }
    }
}
