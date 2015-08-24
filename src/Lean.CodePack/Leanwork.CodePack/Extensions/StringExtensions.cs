using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;
using System.Web;
using System.Collections.Specialized;

namespace Leanwork.CodePack
{
    /// <summary>
    /// String's Extensions 
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Capitalize the first letter of the text
        /// </summary>
        /// <param name="value">Text to capitalize</param>
        /// <returns>Text with first letter capitalized</returns>
        public static string Capitalize(this string value)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value);
        }

        /// <summary>
        /// Remove all accents of the string
        /// </summary>
        /// <param name="value">Text to remove accents</param>
        /// <returns>Text with accents removed</returns>
        public static string RemoveAccents(this string value)
        {
            byte[] bytes = Encoding.GetEncoding("Cyrillic").GetBytes(value);
            return Encoding.ASCII.GetString(bytes);
        }

        /// <summary>
        /// Truncate a string
        /// </summary>
        /// <param name="text">Text to truncate</param>
        /// <param name="maxLength">Max length</param>
        /// <param name="suffix">Suffix</param>
        /// <returns>Truncated string</returns>
        public static string Truncate(this string text, int maxLength, string suffix = "...")
        {
            string truncatedString = text;

            if (maxLength <= 0) return truncatedString;
            int strLength = maxLength - suffix.Length;

            if (strLength <= 0) return truncatedString;

            if (text == null || text.Length <= maxLength) return truncatedString;

            truncatedString = text.Substring(0, strLength);
            truncatedString = truncatedString.TrimEnd();
            truncatedString += suffix;
            return truncatedString;
        }

        /// <summary>
        /// Slug the string
        /// </summary>
        /// <param name="text">Text to slug</param>
        /// <param name="separator">Separator (Default is "-")</param>
        /// <returns>Slugged string</returns>
        public static string ToSlug(this string text, string separator = "-")
        {
            text = text ?? String.Empty;
            separator = separator ?? string.Empty;
            String value = text.Normalize(NormalizationForm.FormD).Trim();
            StringBuilder builder = new StringBuilder();

            foreach (char c in text.ToCharArray())
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                { 
                    builder.Append(c);
                }
            }

            value = builder.ToString();
            byte[] bytes = Encoding.GetEncoding("Cyrillic").GetBytes(text);
            value = Regex.Replace(Regex.Replace(Encoding.ASCII.GetString(bytes), @"\s{2,}|[^\w]", " ", RegexOptions.ECMAScript).Trim(), @"\s+", separator);

            return value.ToLowerInvariant();
        }
        
        /// <summary>
        /// Verify if the string is null or empty space
        /// </summary>
        /// <param name="value">String to verify</param>
        /// <returns>True or False</returns>
        public static bool IsNullOrWhiteSpace(this string value)
        {
            return String.IsNullOrWhiteSpace(value);
        }

        /// <summary>
        /// Convert string to enum
        /// </summary>
        /// <typeparam name="T">Type to convert</typeparam>
        /// <param name="value">String value enum</param>
        /// <returns>Enum</returns>
        public static TEnum ToEnum<TEnum>(this string value)
        {
            if (value.IsNullOrWhiteSpace())
            {
                return default(TEnum);
            }
            if (Enum.IsDefined(typeof(TEnum), value) == false)
            {
                return default(TEnum);
            }
            
            return (TEnum)Enum.Parse(typeof(TEnum), value);
        }

        /// <summary>
        /// Remove characters
        /// </summary>
        /// <param name="value">Value where characters will be removed</param>
        /// <param name="characters">Characters</param>
        /// <returns>Value without characters</returns>
        public static string RemoveCharacters(this string value, params string[] characters)
        {
            if (value.IsNullOrWhiteSpace() || characters == null)
            {
                return value;
            }
            foreach (var character in characters)
            {
                value = value.Replace(character, "");
            }
            return value;
        }

        /// <summary>
        /// Remove alphabetic characters
        /// </summary>
        /// <param name="value">Value where alphabetic characters will be removed</param>
        /// <param name="characters">Alphabetic characters</param>
        /// <returns>Value without alphabetic characters</returns>
        public static string RemoveAlphabetic(this string value)
        {
            if (value.IsNullOrWhiteSpace())
            {
                return value;
            }
            return Regex.Replace(value, "[^0-9]", "");
        }

        /// <summary>
        /// Convert string to byte array
        /// </summary>
        /// <param name="value">String to convert</param>
        /// <returns>Array of bytes from string</returns>
        public static byte[] ToByteArray(this string value)
        {
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            return encoding.GetBytes(value);
        }

        /// <summary>
        /// Convert decimal to price USA
        /// </summary>
        /// <param name="value">value</param>
        /// <returns>String value</returns>
        public static string ToPriceUSA(this decimal value)
        {
            return ToPriceUSA(value.ToString());
        }

        /// <summary>
        /// Convert string to price USA
        /// </summary>
        /// <param name="value">value</param>
        /// <returns>String value</returns>
        public static string ToPriceUSA(this string value)
        {
            if (String.IsNullOrWhiteSpace(value))
                return String.Empty;

            return String.Format("{0:0.00}", value).Replace(",", ".");
        }

        public static Int16 ToInt16(this string value)
        {
            Int16 result = 0;
            if (!Int16.TryParse(value, out result))
            {
                result = 0;
            }
            return result;
        }

        public static Int32 ToInt32(this string value)
        {
            Int32 result = 0;
            if (!Int32.TryParse(value, out result))
            {
                result = 0;
            }
            return result;
        }

        public static Int64 ToInt64(this string value)
        {
            Int64 result = 0;
            if (!Int64.TryParse(value, out result))
            {
                result = 0;
            }
            return result;
        }

        public static Boolean ToBoolean(this string value)
        {
            Boolean result = false;
            if (!Boolean.TryParse(value, out result))
            {
                result = false;
            }
            return result;
        }

        public static Decimal ToDecimal(this string value)
        {
            decimal result = 0;
            Decimal.TryParse(value, out result);
            return result;
        }

        public static Decimal? ToDecimalNullable(this string value)
        {
            if(value.IsNullOrWhiteSpace())
            {   
                return null;
            }
            decimal result = 0;
            Decimal.TryParse(value, out result);
            return result;
        }

        public static string HtmlEncode(this string data)
        {
            return HttpUtility.HtmlEncode(data);
        }

        public static string HtmlDecode(this string data)
        {
            return HttpUtility.HtmlDecode(data);
        }

        public static NameValueCollection ParseQueryString(this string query)
        {
            return HttpUtility.ParseQueryString(query);
        }

        public static string UrlEncode(this string url)
        {
            return HttpUtility.UrlEncode(url);
        }

        public static string UrlDecode(this string url)
        {
            return HttpUtility.UrlDecode(url);
        }

        public static string UrlPathEncode(this string url)
        {
            return HttpUtility.UrlPathEncode(url);
        }

        /// <summary>
        /// Count all words in a given string
        /// </summary>
        /// <param name="input">string to begin with</param>
        /// <returns>int</returns>
        public static int WordCount(this string input)
        {
            var count = 0;
            try
            {
                // Exclude whitespaces, Tabs and line breaks
                var re = new Regex(@"[^\s]+");
                var matches = re.Matches(input);
                count = matches.Count;
            }
            catch
            {
            }
            return count;
        }
    }
}
