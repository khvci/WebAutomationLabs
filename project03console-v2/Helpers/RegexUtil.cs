using System.Text.RegularExpressions;

namespace project03console_v2.Helpers
{
    public static class RegexUtil
    {
        public static string Clear(this string input)
        {
            return Regex.Replace(input, "&#(\\d+);", match => ".");
        }
    }
}
