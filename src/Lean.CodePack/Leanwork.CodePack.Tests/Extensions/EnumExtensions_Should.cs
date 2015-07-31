using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Leanwork.CodePack;

namespace Leanwork.CodePack.Tests.Extensions
{
    [TestClass]
    public class EnumExtensions_Should
    {
        /// <summary>
        /// Enum created only for test purposes
        /// </summary>
        public enum Genre
        {
            MALE,
            [System.ComponentModel.Description("Female Description")]
            FEMALE
        }

        [TestMethod]
        public void Returns_string_empty_when_enum_is_null()
        {
            //act
            string description = EnumExtensions.GetDescription(null);

            //assert
            Assert.AreEqual(string.Empty, description);
        }

        [TestMethod]
        public void Returns_name_of_enum_when_do_not_have_attribute_description()
        {
            //arrange
            Genre male = Genre.MALE;

            //act
            string description = male.GetDescription();
            
            //assert
            Assert.AreEqual("MALE", description);
        }

        [TestMethod]
        public void Returns_description_of_enum_when_do_have_attribute_description()
        {
            //arrange
            Genre female = Genre.FEMALE;

            //act
            string description = female.GetDescription();

            //assert
            Assert.AreEqual("Female Description", description);
        }
    }
}
