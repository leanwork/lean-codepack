using System;
using System.Collections.Generic;
using System.Runtime.Caching;
using System.Text.RegularExpressions;

namespace Leanwork.CodePack
{
    /// <summary>
    /// Responsável por gerenciar cache em memória
    /// </summary>
    public class MemoryCacheManager : ICacheManager
    {
        protected ObjectCache Cache
        {
            get
            {
                return MemoryCache.Default;
            }
        }

        /// <summary>
        /// Obtém um item do cache
        /// </summary>
        /// <typeparam name="T">Item</typeparam>
        /// <param name="key">Chave</param>
        /// <returns>Item em cache</returns>
        public virtual T Get<T>(string key)
        {
            return (T)Cache[key];
        }

        /// <summary>
        /// Seta um objeto em cache
        /// </summary>
        /// <param name="key">Chave</param>
        /// <param name="data">Dados</param>
        /// <param name="cacheTime">Duração</param>
        public virtual void Set(string key, object data, int cacheTime)
        {
            if (data == null)
                return;

            var policy = new CacheItemPolicy();
            policy.AbsoluteExpiration = DateTime.Now + TimeSpan.FromMinutes(cacheTime);
            Cache.Add(new CacheItem(key, data), policy);
        }

        /// <summary>
        /// Verifica se já existe um cache setado para uma determinada chave
        /// </summary>
        /// <param name="key">Chave</param>
        /// <returns>Está em cache ou não</returns>
        public virtual bool IsSet(string key)
        {
            return (Cache.Contains(key));
        }

        /// <summary>
        /// Remove um item do cache para determinada chave
        /// </summary>
        /// <param name="key">Chave</param>
        public virtual void Remove(string key)
        {
            Cache.Remove(key);
        }

        /// <summary>
        /// Remove itens do cache seguindo um determinado padrão de chave
        /// </summary>
        /// <param name="pattern"></param>
        public virtual void RemoveByPattern(string pattern)
        {
            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var keysToRemove = new List<String>();

            foreach (var item in Cache)
                if (regex.IsMatch(item.Key))
                    keysToRemove.Add(item.Key);

            foreach (string key in keysToRemove)
            {
                Remove(key);
            }
        }

        /// <summary>
        /// Esvazia o cache
        /// </summary>
        public virtual void Clear()
        {
            foreach (var item in Cache)
                Remove(item.Key);
        }
    }
}