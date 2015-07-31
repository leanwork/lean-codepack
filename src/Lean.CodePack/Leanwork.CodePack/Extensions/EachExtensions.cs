using System;
using System.Collections.Generic;

namespace Leanwork.CodePack
{
    public static class EachExtensions
    {
        public static void Each<T>(this IEnumerable<T> collection, Action<T, int> action)
        {
            int index = 0;
            foreach (var obj in collection)
            {
                action(obj, index++);
            }
        }
    }
}
