using System;
using System.Collections.Generic;
using System.Linq;

namespace Leanwork.CodePack
{
    public static class DictionaryExtensions
    {
        public static TValue GetValue<TKey, TValue>(this Dictionary<TKey, TValue> dic, TKey key)
        {
            TValue value = default(TValue);

            if (key == null)
            {
                return value;    
            }

            dic.TryGetValue(key, out value);
            return value;
        }
    }
}
