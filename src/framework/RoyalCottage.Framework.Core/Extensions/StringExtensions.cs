using System;
using System.Collections.Generic;
using System.Text;

namespace RoyalCottage.Framework.Core.Extensions
{
    public static class StringExtensions
    {
        public static string ToCamelCase(this string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                text = $"{char.ToLower(text[0])}{text.Substring(1)}";
            }
            return text;
        }
    }
}
