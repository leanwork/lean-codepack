using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Leanwork.CodePack
{
    public static class FormattersExtensions
    {
        public static string BrazilianCpf(this string cpf)
        {
            return Regex.Replace(cpf, @"^(\d{3})(\d{3})(\d{3})(\d{2})$", "$1.$2.$3-$4");
        }

        public static string BrazilianCnpj(this string cnpj)
        {
            return Regex.Replace(cnpj, @"^(\d{2})(\d{3})(\d{3})(\d{4})(\d{2})$", "$1.$2.$3/$4-$5");
        }

        public static string BrazilianPhoneNumber(this string phoneNumber)
        {
            return Regex.Replace(phoneNumber, @"^(\d{2})(\d{4,5})(\d{4})$", "($1) $2-$3");
        }

        public static string BrazilianPostalCode(this string postalCode)
        {
            return Regex.Replace(postalCode, @"^(\d{5})(\d{3})$", "$1-$2");
        }
    }
}
