using System;

namespace Leanwork.CodePack
{
    public static class BooleanExtensions
    {
        /// <summary>
        /// Return literal result of boolean value
        /// </summary>
        /// <param name="value">True or False</param>
        /// <param name="conditionTrue">String that will be returned if value is true</param>
        /// <param name="conditionFalse">String that will be returned if value is false</param>
        /// <returns>String</returns>
        public static string ToLiteral(this Boolean value, string conditionTrue, string conditionFalse)
        {
            return value ? conditionTrue : conditionFalse;
        }
    }
}
