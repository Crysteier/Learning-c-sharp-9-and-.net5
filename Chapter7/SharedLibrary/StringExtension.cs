using System.Text.RegularExpressions;
using System;

namespace SharedLibrary
{
    public static class StringExtension
    {
        public static bool IsValidXmlTag(this string input)
        {
            return Regex.IsMatch(input, @"^<([a-z]+)([^<]+)*(?:>(.*)<\/\1>|\s+\/>)$");
        }
        public static bool IsValidPassword(this string input)
        {
            //minimum of 8 valid characters
            return Regex.IsMatch(input, "^[a-zA-Z0-9_-]{8,}$");
        }
        public static bool IsValidHex(this string input)
        {
            //three or six valid hex number characters
            return Regex.IsMatch(input, "^#?([a-fA-F0-9]{3}|[a-fA-F0-9]{6})$");
        }
    }
}
