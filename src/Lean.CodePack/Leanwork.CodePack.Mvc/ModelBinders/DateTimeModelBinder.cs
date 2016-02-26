using System;
using System.Globalization;

namespace Leanwork.CodePack.Mvc
{
    public class DateTimeModelBinder : ModelBinder
    {
        public override object ConvertTo(string value)
        {
            return Convert.ToDateTime(value, CultureInfo.CurrentCulture);
        }
    }
}
