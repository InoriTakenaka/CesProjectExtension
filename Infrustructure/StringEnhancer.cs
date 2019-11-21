using System;
using System.Text.RegularExpressions;

namespace Infrastructure
{
    public static class StringEnhancer
    {
        public static string ValidateStr(this string source)
        {
            if (string.IsNullOrEmpty(source))
            {
                return "-";
            }
            return source;
        }

        public static string ValidateAssign(this string source, string assign)
        {
            if (string.IsNullOrEmpty(source))
            {
                return assign;
            }
            return source;
        }

        public static int SafeParse(this string source)
        {
            int result = 0;
            if (int.TryParse(source, out result))
            {
                return result;
            }
            else return 0;
        }

        public static float SafeParseF(this string source)
        {
            float result = 0;
            if (float.TryParse(source, out result))
            {
                return result;
            }
            else return 0f;
        }

        public static string SafeParseAbs(this string source)
        {
            int numeric = 0;
            if (int.TryParse(source, out numeric))
            {
                return Math.Abs(numeric).ToString();
            }
            else return "-";
        }

        public static bool IsNullOrEmprty(this string source)
        {
            return (string.IsNullOrEmpty(source));
        }

        public static bool IsEffective(this string source)
        {
            return (!string.IsNullOrEmpty(source));
        }

        public static bool IsPattern(this string source, string pattern)
        {
            if (pattern.IsNullOrEmprty()) return false;
            return Regex.IsMatch(source, pattern);
        }

        public static string FormatWith(this string source, params object[] args)
        {
            return string.Format(source, args);
        }

        public static DateTime SafeConvertDateTime(this string source)
        {
            try
            {
                return Convert.ToDateTime(source);
            }
            catch
            {
                return new DateTime();
            }
        }

        public static bool IsNumeric(this string source)
        {
            if (source.IsNullOrEmprty()) return false;
            else
            {
                return Regex.IsMatch(source, "^[-+]?(([0-9]+)([.]([0-9]+))?|([.]([0-9]+))?)$");
            }
        }
    }
}
