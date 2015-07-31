using System;
using System.ComponentModel;
using System.Reflection;

namespace Leanwork.CodePack
{
    public static class EnumExtensions
    {
        /// <summary>
        /// Gets description of Enum.
        /// </summary>
        /// <param name="value">Valor do Enum.</param>
        /// <returns>
        /// Returns description of an Enum.
        /// </returns>
        public static string GetDescription(this Enum value)
        {
            if (value == null)
            { 
                return String.Empty;
            }

            FieldInfo fieldInfo = value.GetType().GetField(value.ToString());
            if (fieldInfo == null)
            { 
                return string.Empty;
            }

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes == null || attributes.Length.Equals(0))
            { 
                return value.ToString();
            }

            var attribute = attributes[0];
            return (attribute.Description.Trim() == String.Empty) ? value.ToString() : attribute.Description.Trim();
        }
    }
}
