using System.Xml;
using System.Xml.Serialization;

namespace Leanwork.CodePack
{
    public static class ParseXmlExtensions
    {
        public static T ParseXML<T>(this string value) where T : class
        {
            value = value.Replace("%26lt;", "<").Replace("%26gt;", ">");

            XmlReader reader = XmlReader.Create(value.Trim().ToStream(), new XmlReaderSettings() { ConformanceLevel = ConformanceLevel.Document });

            return new XmlSerializer(typeof(T)).Deserialize(reader) as T;
        }     
    }
}
