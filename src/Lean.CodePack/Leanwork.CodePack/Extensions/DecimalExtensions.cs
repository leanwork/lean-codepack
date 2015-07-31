using System;
using System.Collections.Generic;
using System.Globalization;

namespace Leanwork.CodePack
{
    public static class DecimalExtensions
    {
        /// <summary>
        /// Replace characters such as: "." e ","
        /// </summary>
        /// <param name="value"></param>
        /// <param name="caracters"></param>
        /// <returns></returns>
        public static long ToLongReplace(this decimal value, params string[] caracters)
        {
            string newValue = GetValueReplace(value, caracters);

            return Convert.ToInt64(newValue);
        }

        /// <summary>
        /// Replace characters such as: "." e ","
        /// </summary>
        /// <param name="value"></param>
        /// <param name="caracters"></param>
        /// <returns></returns>
        public static decimal ToDecimalReplace(this decimal value, params string[] caracters)
        {
            string newValue = GetValueReplace(value, caracters);

            return Convert.ToDecimal(newValue);
        }

        /// <summary>
        /// Replace characters such as: "." e ","
        /// </summary>
        /// <param name="value"></param>
        /// <param name="caracters"></param>
        /// <returns></returns>
        private static string GetValueReplace(decimal value, IEnumerable<string> caracters)
        {
            string newValue = value.ToString(CultureInfo.InvariantCulture);

            foreach (var item in caracters)
                newValue = newValue.Replace(item, String.Empty);

            return newValue;
        }

        /// <summary>
        /// Replace characters such as: "." e ","
        /// </summary>
        /// <param name="value"></param>
        /// <param name="caracters"></param>
        /// <returns></returns>
        public static int ToInt32(this decimal value)
        {   
            return Convert.ToInt32(value);
        }
    }
}