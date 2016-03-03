using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leanwork.CodePack
{
    public static class MathExtensions
    {
        public static decimal Percentage(this int total, int amount)
        {
            decimal result = 0;
            if (total > 0)
            {
                result = ((decimal)amount / total) * 100;
            }
            return result;
        }
    }
}
