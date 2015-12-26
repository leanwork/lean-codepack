using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Leanwork.CodePack.Tests.Extensions
{
    [TestClass]
    public class EnumerableExtensions_Should
    {
        [TestMethod]
        public void Intercalate_values_from_lists()
        {
            string[] values = new string[] { "1", "a", "@", "2", "b", "#", "3", "c" };

            //arrange
            var items = new List<List<string>>();

            //"1", "2", "3"
            items.Add(new List<string> { values[0], values[3], values[6] });

            //"a", "b", "c"
            items.Add(new List<string> { values[1], values[4], values[7] });

            //"@", "#"
            items.Add(new List<string> { values[2], values[5] });            

            //act
            var result = items
                .IntercalateValues()
                .SelectMany(g => g)
                .ToArray();

            //assert
            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(values[i], result[i]);    
            }
        }
    }
}
