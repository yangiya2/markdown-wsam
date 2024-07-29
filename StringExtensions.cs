using System.Diagnostics.CodeAnalysis;
using System.Text;
using static System.Net.WebRequestMethods;

namespace markdown_wsam
{
    public static class StringExtensions
    {
        public static string OrStr(this string? str, string orValue = "")
        {
            if (str == null || str.Length == 0 || str.Trim().Length == 0) return orValue;
            return str;
        }
    }
}
