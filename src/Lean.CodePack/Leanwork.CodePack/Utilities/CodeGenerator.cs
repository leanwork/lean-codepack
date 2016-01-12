using System;
using System.Linq;

namespace Leanwork.CodePack.Utilities
{
    public class CodeGenerator
    {
        const string ALPHABET = "AG8FOLE2WVT1CPY5ZH3NIUDBXSMQK7946";

        public static string New(int lenght = 6)
        {
            Random random = new Random();

            char[] keys = ALPHABET.ToCharArray();

            return Enumerable
                .Range(1, lenght) // for(i.. ) 
                .Select(k => keys[random.Next(0, keys.Length - 1)])  // generate a new random char 
                .Aggregate("", (e, c) => e + c); // join into a string
        }
    }
}
