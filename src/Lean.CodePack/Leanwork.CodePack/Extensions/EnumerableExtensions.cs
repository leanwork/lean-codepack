using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Leanwork.CodePack
{
    public static class EnumerableExtensions
    {
        public static bool IsNullOrEmpty<TSource>(this IEnumerable<TSource> coll)
        {
            return (coll == null) || (!coll.Any());
        }

        public static bool In<T>(this T source, params T[] list)
        {
            if (null == source) throw new ArgumentNullException("source");
            return list.Contains(source);
        }

        public static IEnumerable<T> Randomize<T>(this IEnumerable<T> target)
        {
            Random r = new Random();
            return target.OrderBy(x => (r.Next()));
        }

        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (T item in enumerable)
                action(item);
        }

        public static void Each<T>(this IEnumerable<T> collection, Action<T, int> action)
        {
            int index = 0;
            foreach (var obj in collection)
                action(obj, index++);
        }

        public static string ToCSV<T>(this IEnumerable<T> instance, char separator)
        {
            StringBuilder csv;
            if (instance != null)
            {
                csv = new StringBuilder();
                instance.ForEach(value => csv.AppendFormat("{0}{1}", value, separator));
                return csv.ToString(0, csv.Length - 1);
            }
            return null;
        }

        public static string ToCSV<T>(this IEnumerable<T> instance)
        {
            StringBuilder csv;
            if (instance != null)
            {
                csv = new StringBuilder();
                instance.ForEach(v => csv.AppendFormat("{0},", v));
                return csv.ToString(0, csv.Length - 1);
            }
            return null;
        }
    }
}
