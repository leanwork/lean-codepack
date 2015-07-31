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
        public static String ToSlug(this string text, string separator = "-")
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
        /// CPF validator
        /// </summary>
        /// <param name="cpf">CPF number</param>
        /// <returns>True if valid, otherwise is false</returns>
        public static bool IsCpf(this string cpf)
        {
            if (cpf.IsNullOrWhiteSpace())
                return false;
            cpf = cpf.RemoveAlphabetic().Trim();

            int[] multiply1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiply2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digit;
            int sum;
            int rest;

            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
            {
                return false;
            }

            tempCpf = cpf.Substring(0, 9);
            sum = 0;
            for (int i = 0; i < 9; i++)
            {
                sum += int.Parse(tempCpf[i].ToString()) * multiply1[i];
            }

            rest = sum % 11;
            if (rest < 2)
            {
                rest = 0;
            }
            else
            {
                rest = 11 - rest;
            }

            digit = rest.ToString();
            tempCpf = tempCpf + digit;
            sum = 0;
            for (int i = 0; i < 10; i++)
            {
                sum += int.Parse(tempCpf[i].ToString()) * multiply2[i];
            }

            rest = sum % 11;
            if (rest < 2)
            {
                rest = 0;
            }
            else
            {
                rest = 11 - rest;
            }

            digit = digit + rest.ToString();
            return cpf.EndsWith(digit);
        }

        /// <summary>
        /// CNPJ validator
        /// </summary>
        /// <param name="cnpj">CNPJ number</param>
        /// <returns>True if valid, otherwise is false</returns>
        public static bool IsCnpj(this string cnpj)
        {
            if (cnpj.IsNullOrWhiteSpace())
                return false;
            cnpj = cnpj.RemoveAlphabetic().Trim();

            int[] multiply1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiply2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int sum;
            int rest;
            string digit;
            string tempCnpj;

            cnpj = cnpj.RemoveAlphabetic().Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
            {
                return false;
            }
            
            tempCnpj = cnpj.Substring(0, 12);
            sum = 0;
            for (int i = 0; i < 12; i++)
            {
                sum += int.Parse(tempCnpj[i].ToString()) * multiply1[i];
            }

            rest = (sum % 11);
            if (rest < 2)
            {
                rest = 0;
            }
            else
            {
                rest = 11 - rest;
            }

            digit = rest.ToString();
            tempCnpj = tempCnpj + digit;
            sum = 0;
            for (int i = 0; i < 13; i++)
            {
                sum += int.Parse(tempCnpj[i].ToString()) * multiply2[i];
            }

            rest = (sum % 11);
            if (rest < 2)
            {
                rest = 0;
            }
            else
            {
                rest = 11 - rest;
            }

            digit = digit + rest.ToString();
            return cnpj.EndsWith(digit);
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

        public static Int32 ToInt32(this string value)
        {
            int result = 0;
            Int32.TryParse(value, out result);
            return result;
        }

        public static long ToLong(this string value)
        {
            long result = 0;
            Int64.TryParse(value, out result);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsDate(this string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                DateTime dt;
                return (DateTime.TryParse(input, out dt));
            }
            return false;
        }

        public static bool IsNumeric(this string theValue)
        {
            long retNum;
            return long.TryParse(theValue, System.Globalization.NumberStyles.Integer, System.Globalization.NumberFormatInfo.InvariantInfo, out retNum);
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
