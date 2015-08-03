using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leanwork.CodePack
{
    public static class ValidateExtensions
    {
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
    }
}
