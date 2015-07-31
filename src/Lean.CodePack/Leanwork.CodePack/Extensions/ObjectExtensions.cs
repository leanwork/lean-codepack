using Leanwork.CodePack.Dynamic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Leanwork.CodePack
{
    /// <summary>
    /// Object's Extensions 
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// Get PropertyName/Value of an object
        /// </summary>
        /// <param name="object">An object</param>
        /// <returns>Dictionary of PropertyName/Value</returns>
        public static Dictionary<string, string> GetPropertiesValues(this object @object)
        {
            var values = new Dictionary<string, string>();
            if (@object == null)
            { 
                return values;
            }

            var properties = @object.GetType().GetProperties();
            foreach (var property in properties)
            {
                object propertyValue = property.GetValue(@object);
                string value = (propertyValue == null) ? "" : propertyValue.ToString();
                values.Add(property.Name, value);
            }

            return values;
        }

        /// <summary>
        /// Get PropertyName/Value of a dynamic object
        /// </summary>
        /// <param name="object">A dynamic object</param>
        /// <returns>Dictionary of PropertyName/Value</returns>
        public static Dictionary<string, object> GetDynamicValues(this object @object)
        {
            var values = new Dictionary<string, object>();
            if (@object == null)
            { 
                return values;
            }

            var dynamicObject = @object as ExpandableObject;
            if (dynamicObject == null)
            {
                return values;
            }

            foreach (var memberName in dynamicObject.GetMemberNames())
            {
                object value = (dynamicObject[memberName] == null) ? "" : dynamicObject[memberName];
                values.Add(memberName, value);
            }

            return values;
        }

        /// <summary>
        /// Makes a copy of the object
        /// </summary>
        /// <typeparam name="T">The type object being copied.</typeparam>
        /// <param name="source">The instance object to be copied.</param>
        /// <returns>Object copied.</returns>
        public static T Clone<T>(this T source)
        {
            if (!typeof(T).IsSerializable)
            {
                throw new ArgumentException("type marking object must be serializable", "source");
            }

            // Don't serialize a null object, simply return the default for that object
            if (Object.ReferenceEquals(source, null))
            {
                return default(T);
            }

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new MemoryStream();
            using (stream)
            {
                formatter.Serialize(stream, source);
                stream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(stream);
            }
        }

        /// <summary>
        /// Retorna se o objeto está vazio ou nulo.
        /// </summary>
        /// <param name="objeto">Objeto que será verificado.</param>
        /// <returns>Verdadeiro se estiver nulo, se não, falso</returns>
        public static bool IsNull(this Object objeto)
        {
            return (objeto == String.Empty || objeto == null);
        }

        /// <summary>
        /// Retorna se o objeto não está vazio ou nulo.
        /// </summary>
        /// <param name="objeto">Objeto que será verificado.</param>
        /// <returns>Verdadeiro se NÃO estiver nulo, se não, falso</returns>
        public static bool IsNotNull(this Object objeto)
        {
            return !objeto.IsNull();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="o"></param>
        /// <returns></returns>
        public static string ToXML<T>(this T o) where T : new()
        {
            string retVal;
            using (var ms = new MemoryStream())
            {
                var xs = new XmlSerializer(typeof(T));
                xs.Serialize(ms, o);
                ms.Flush();
                ms.Position = 0;
                var sr = new StreamReader(ms);
                retVal = sr.ReadToEnd();
            }
            return retVal;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="obj"></param>
        /// <param name="obj1"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        public static bool Equals<T, TResult>(this T obj, object obj1, Func<T, TResult> selector)
        {
            return obj1 is T && selector(obj).Equals(selector((T)obj1));
        }
    }
}
