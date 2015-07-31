using System;
using System.Collections.Generic;

namespace Leanwork.CodePack
{
    public static class ListExtensions
    {
        /// <summary>
        /// Convert a List of string to List of int
        /// </summary>
        /// <param name="list">List to convert</param>
        /// <returns>List of int</returns>
        public static List<int> StringToInt(this List<string> list)
        {
            var result = new List<int>();
            
            if (list == null)
            {
                return result;
            }
            foreach (var entry in list)
            {
                int value;
                if (int.TryParse(entry, out value))
                    result.Add(value);
            }

            return result;
        }

        /// <summary>
        /// Convert a List of string to List of int?
        /// </summary>
        /// <param name="list">List to convert</param>
        /// <returns>List of int?</returns>
        public static List<int?> StringToIntNull(this List<string> list)
        {
            var result = new List<int?>();

            if (list == null)
            {
                return result;
            }
            foreach (var entry in list)
            {
                int value;
                if (int.TryParse(entry, out value))
                    result.Add(value);
                else
                    result.Add(null);
            }

            return result;
        }

        /// <summary>
        /// Convert a List of string to List of DateTime
        /// </summary>
        /// <param name="list">List to convert</param>
        /// <returns>List of DateTime</returns>
        public static List<DateTime> StringToDate(this List<string> list)
        {
            var result = new List<DateTime>();

            if (list == null)
            {
                return result;
            }
            foreach (var entry in list)
            {
                result.Add(Convert.ToDateTime(entry));
            }

            return result;
        }

        /// <summary>
        /// Convert a List of int to List of string
        /// </summary>
        /// <param name="list">List to convert</param>
        /// <returns>List of string</returns>
        public static List<string> IntToString(this List<int> list)
        {
            var result = new List<string>();
            
            if (list == null)
            {
                return result;
            }
            foreach (var entry in list)
            {
                result.Add(entry.ToString());
            }

            return result;
        }
    }
}
