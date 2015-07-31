using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Leanwork.CodePack;

namespace Leanwork.CodePack.Tests.Extensions
{
    [TestClass]
    public class StringExtensions_Should
    {
        [TestMethod]
        public void Returns_capitalized_string()
        {
            //arrange
            string value = "jovem car";

            //act
            string expected = "Jovem Car";
            string result = value.Capitalize();

            //assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Returns_string_without_accents()
        {
            //arrange
            string value = "áàâãäéèêëíìîïóòôõöúùûü";

            //act
            string expected = "aaaaaeeeeiiiiooooouuuu";
            string result = value.RemoveAccents();

            //assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Returns_truncated_string()
        {
            //arrange
            string value = "Jovem Car Ecommerce";

            //act
            string expected = "Jovem Car Ec...";
            string result = value.Truncate(15);

            //assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Returns_truncated_string_where_the_last_character_is_empty()
        {
            //arrange
            string value = "Jovem Car Ecommerce Platform";

            //act
            string expected = "Jovem Car Ecommerce...";
            string result = value.Truncate(22);

            //assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Returns_slugged_string()
        {
            //arrange
            string value = "Jovem Car Ecommerce";

            //act
            string expected = "jovem-car-ecommerce";
            string result = value.ToSlug();

            //assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Returns_true_if_string_is_null()
        {
            //arrange
            string value = null;

            //act
            bool result = value.IsNullOrWhiteSpace();

            //assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Returns_true_if_string_is_empty()
        {
            //arrange
            string value = "";

            //act
            bool result = value.IsNullOrWhiteSpace();

            //assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Returns_false_if_string_is_not_empty_or_null()
        {
            //arrange
            string value = "Jovem Car";

            //act
            bool result = value.IsNullOrWhiteSpace();

            //assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Convert_string_to_enum()
        {
            //arrange
            string value = "VALUE_ONE";

            //act
            EnumToTest result = value.ToEnum<EnumToTest>();

            //assert
            Assert.AreEqual(EnumToTest.VALUE_ONE, result);
        }

        [TestMethod]
        public void Convert_string_to_enum_value_default_if_value_not_exist_in_enum()
        {
            //arrange
            string value = "AAA";

            //act
            EnumToTest result = value.ToEnum<EnumToTest>();

            //assert
            Assert.AreEqual(EnumToTest.NONE, result);
        }

        [TestMethod]
        public void Convert_string_null_to_enum_default()
        {
            //arrange
            string value = null;

            //act
            EnumToTest result = value.ToEnum<EnumToTest>();

            //assert
            Assert.AreEqual(EnumToTest.NONE, result);
        }

        [TestMethod]
        public void Returns_true_if_cpf_is_valid()
        {
            //arrange
            string value1 = "12938174144";
            string value2 = "129.381.741-44";

            //act
            bool result1 = value1.IsCpf();
            bool result2 = value2.IsCpf();

            //assert
            Assert.IsTrue(result1);
            Assert.IsTrue(result2);
        }

        [TestMethod]
        public void Returns_false_if_cpf_is_invalid()
        {
            //arrange
            string value1 = "12345678912";
            string value2 = "123.456.789-12";

            //act
            bool result1 = value1.IsCpf();
            bool result2 = value2.IsCpf();

            //assert
            Assert.IsFalse(result1);
            Assert.IsFalse(result2);
        }

        [TestMethod]
        public void Returns_true_if_cnpj_is_valid()
        {
            //arrange
            string value1 = "43315687000167";
            string value2 = "43.315.687/0001-67";

            //act
            bool result1 = value1.IsCnpj();
            bool result2 = value2.IsCnpj();

            //assert
            Assert.IsTrue(result1);
            Assert.IsTrue(result2);
        }

        [TestMethod]
        public void Returns_false_if_cnpj_is_invalid()
        {
            //arrange
            string value1 = "12345678912345";
            string value2 = "12.345.678/9123-45";

            //act
            bool result1 = value1.IsCnpj();
            bool result2 = value2.IsCnpj();

            //assert
            Assert.IsFalse(result1);
            Assert.IsFalse(result2);
        }

        [TestMethod]
        public void Remove_characteres_from_a_string()
        {
            //arrange
            string value = "Jovem Car Ecommerce Platform";

            //act
            string result = value.RemoveCharacters("Jovem ", " Platform");

            //assert
            Assert.AreEqual("Car Ecommerce", result);
        }

        [TestMethod]
        public void Remove_alpha_characteres_from_a_string()
        {
            //arrange
            string value = "1*23ABC-8(797KW8V_a88764@$#";

            //act
            string result = value.RemoveAlphabetic();

            //assert
            Assert.AreEqual("1238797888764", result);
        }
    }
}
