using System;
using System.Globalization;
using System.Text;

namespace DevToolkit.Extensions
{
    public static class String
    {
        public static string SafeTrim(this string value) => !string.IsNullOrEmpty(value) ? value.Trim() : string.Empty;

        public static string SafeTrimStart(this string value) => !string.IsNullOrEmpty(value) ? value.TrimStart() : string.Empty;

        public static string SafeTrimEnd(this string value) => !string.IsNullOrEmpty(value) ? value.TrimEnd() : string.Empty;

        public static string SafeSubstring(this string value, int startIndex) => !string.IsNullOrEmpty(value) ? value.Substring(startIndex) : string.Empty;

        public static string SafeSubstring(this string value, int startIndex, int length) => !string.IsNullOrEmpty(value) ? value.Substring(startIndex, length) : string.Empty;

        public static string SafeRemove(this string value, int startIndex) => !string.IsNullOrEmpty(value) ? value.Remove(startIndex) : string.Empty;

        public static string SafeRemove(this string value, int startIndex, int length) => !string.IsNullOrEmpty(value) ? value.Remove(startIndex, length) : string.Empty;

        public static string SafeReplace(this string value, string oldValue, string newValue) => !string.IsNullOrEmpty(value) ? value.Replace(oldValue, newValue) : string.Empty;

        public static string SafeReplace(this string value, char oldChar, char newChar) => !string.IsNullOrEmpty(value) ? value.Replace(oldChar, newChar) : string.Empty;

        public static string SafeToUpper(this string value) => !string.IsNullOrEmpty(value) ? value.ToUpper() : string.Empty;

        public static string SafeToUpperInvariant(this string value) => !string.IsNullOrEmpty(value) ? value.ToUpperInvariant() : string.Empty;

        public static string SafeToLower(this string value) => !string.IsNullOrEmpty(value) ? value.ToLower() : string.Empty;

        public static string SafeToLowerInvariant(this string value) => !string.IsNullOrEmpty(value) ? value.ToLowerInvariant() : string.Empty;

        public static bool SafeContains(this string valueStr, char value) => !string.IsNullOrEmpty(valueStr) && valueStr.Contains(value);

        public static bool SafeContains(this string valueStr, string value) => !string.IsNullOrEmpty(valueStr) && valueStr.Contains(value);

        public static bool SafeContains(this string valueStr, char value, StringComparison comparisonType) => !string.IsNullOrEmpty(valueStr) && valueStr.Contains(value, comparisonType);

        public static bool SafeContains(this string valueStr, string value, StringComparison comparisonType) => !string.IsNullOrEmpty(valueStr) && valueStr.Contains(value, comparisonType);

        public static bool SafeStartsWith(this string valueStr, char value) => !string.IsNullOrEmpty(valueStr) && valueStr.StartsWith(value);

        public static bool SafeStartsWith(this string valueStr, string value) => !string.IsNullOrEmpty(valueStr) && valueStr.StartsWith(value);

        public static bool SafeStartsWith(this string valueStr, string value, StringComparison comparisonType) => !string.IsNullOrEmpty(valueStr) && valueStr.StartsWith(value, comparisonType);

        public static bool SafeStartsWith(this string valueStr, string value, bool ignoreCase, CultureInfo culture) => !string.IsNullOrEmpty(valueStr) && valueStr.StartsWith(value, ignoreCase, culture);

        public static bool SafeEndsWith(this string valueStr, char value) => !string.IsNullOrEmpty(valueStr) && valueStr.EndsWith(value);

        public static bool SafeEndsWith(this string valueStr, string value) => !string.IsNullOrEmpty(valueStr) && valueStr.EndsWith(value);

        public static bool SafeEndsWith(this string valueStr, string value, StringComparison comparisonType) => !string.IsNullOrEmpty(valueStr) && valueStr.EndsWith(value, comparisonType);

        public static bool SafeEndsWith(this string valueStr, string value, bool ignoreCase, CultureInfo culture) => !string.IsNullOrEmpty(valueStr) && valueStr.EndsWith(value, ignoreCase, culture);

        public static int SafeCompareTo(this string valueStr, object value) => !string.IsNullOrEmpty(valueStr) ? valueStr.CompareTo(value) : -1;

        public static int SafeCompareTo(this string valueStr, string strB) => !string.IsNullOrEmpty(valueStr) ? valueStr.CompareTo(strB) : -1;

        public static int SafeIndexOf(this string valueStr, char value) => !string.IsNullOrEmpty(valueStr) ? valueStr.IndexOf(value) : -1;

        public static int SafeIndexOf(this string valueStr, string value) => !string.IsNullOrEmpty(valueStr) ? valueStr.IndexOf(value) : -1;

        public static int SafeIndexOf(this string valueStr, char value, int startIndex) => !string.IsNullOrEmpty(valueStr) ? valueStr.IndexOf(value, startIndex) : -1;

        public static int SafeIndexOf(this string valueStr, char value, StringComparison comparisonType) => !string.IsNullOrEmpty(valueStr) ? valueStr.IndexOf(value, comparisonType) : -1;

        public static int SafeIndexOf(this string valueStr, string value, int startIndex) => !string.IsNullOrEmpty(valueStr) ? valueStr.IndexOf(value, startIndex) : -1;

        public static int SafeIndexOf(this string valueStr, string value, StringComparison comparisonType) => !string.IsNullOrEmpty(valueStr) ? valueStr.IndexOf(value, comparisonType) : -1;

        public static int SafeIndexOf(this string valueStr, char value, int startIndex, int count) => !string.IsNullOrEmpty(valueStr) ? valueStr.IndexOf(value, startIndex, count) : -1;

        public static int SafeIndexOf(this string valueStr, string value, int startIndex, int count) => !string.IsNullOrEmpty(valueStr) ? valueStr.IndexOf(value, startIndex, count) : -1;

        public static int SafeIndexOf(this string valueStr, string value, int startIndex, StringComparison comparisonType) => !string.IsNullOrEmpty(valueStr) ? valueStr.IndexOf(value, startIndex, comparisonType) : -1;

        public static int SafeIndexOf(this string valueStr, string value, int startIndex, int count, StringComparison comparisonType) => !string.IsNullOrEmpty(valueStr) ? valueStr.IndexOf(value, startIndex, count, comparisonType) : -1;

        public static int SafeLastIndexOf(this string valueStr, char value) => !string.IsNullOrEmpty(valueStr) ? valueStr.LastIndexOf(value) : -1;

        public static int SafeLastIndexOf(this string valueStr, string value) => !string.IsNullOrEmpty(valueStr) ? valueStr.LastIndexOf(value) : -1;

        public static int SafeLastIndexOf(this string valueStr, char value, int startIndex) => !string.IsNullOrEmpty(valueStr) ? valueStr.LastIndexOf(value, startIndex) : -1;

        public static int SafeLastIndexOf(this string valueStr, string value, int startIndex) => !string.IsNullOrEmpty(valueStr) ? valueStr.LastIndexOf(value, startIndex) : -1;

        public static int SafeLastIndexOf(this string valueStr, string value, StringComparison comparisonType) => !string.IsNullOrEmpty(valueStr) ? valueStr.LastIndexOf(value, comparisonType) : -1;

        public static int SafeLastIndexOf(this string valueStr, char value, int startIndex, int count) => !string.IsNullOrEmpty(valueStr) ? valueStr.LastIndexOf(value, startIndex, count) : -1;

        public static int SafeLastIndexOf(this string valueStr, string value, int startIndex, int count) => !string.IsNullOrEmpty(valueStr) ? valueStr.LastIndexOf(value, startIndex, count) : -1;

        public static int SafeLastIndexOf(this string valueStr, string value, int startIndex, StringComparison comparisonType) => !string.IsNullOrEmpty(valueStr) ? valueStr.LastIndexOf(value, startIndex, comparisonType) : -1;

        public static int SafeLastIndexOf(this string valueStr, string value, int startIndex, int count, StringComparison comparisonType) => !string.IsNullOrEmpty(valueStr) ? valueStr.LastIndexOf(value, startIndex, count, comparisonType) : -1;

        public static int SafeLength(this string value) => !string.IsNullOrEmpty(value) ? value.Length : 0;
       
        public static int SafeIndexOfAny(this string value, char[] anyOf) => !string.IsNullOrEmpty(value) && anyOf != null ? value.IndexOfAny(anyOf) : -1;
        public static int SafeIndexOfAny(this string value, char[] anyOf, int startIndex) => !string.IsNullOrEmpty(value) && anyOf != null ? value.IndexOfAny(anyOf, startIndex) : -1;
        public static int SafeIndexOfAny(this string value, char[] anyOf, int startIndex, int count) => !string.IsNullOrEmpty(value) && anyOf != null ? value.IndexOfAny(anyOf, startIndex, count) : -1;

        public static int SafeLastIndexOfAny(this string value, char[] anyOf) => !string.IsNullOrEmpty(value) && anyOf != null ? value.LastIndexOfAny(anyOf) : -1;
        public static int SafeLastIndexOfAny(this string value, char[] anyOf, int startIndex) => !string.IsNullOrEmpty(value) && anyOf != null ? value.LastIndexOfAny(anyOf, startIndex) : -1;
        public static int SafeLastIndexOfAny(this string value, char[] anyOf, int startIndex, int count) => !string.IsNullOrEmpty(value) && anyOf != null ? value.LastIndexOfAny(anyOf, startIndex, count) : -1;

        public static string SafeNormalize(this string value) => !string.IsNullOrEmpty(value) ? value.Normalize() : string.Empty;

        public static string SafeNormalize(this string value, NormalizationForm normalizationForm) => !string.IsNullOrEmpty(value) ? value.Normalize(normalizationForm): string.Empty;

        public static string SafePadLeft(this string value, int totalWidth) => !string.IsNullOrEmpty(value) ? value.PadLeft(totalWidth) : string.Empty;
        public static string SafePadLeft(this string value, int totalWidth, char paddingChar) => !string.IsNullOrEmpty(value) ? value.PadLeft(totalWidth, paddingChar) : string.Empty;
        public static string SafePadRight(this string value, int totalWidth) => !string.IsNullOrEmpty(value) ? value.PadRight(totalWidth) : string.Empty;
        public static string SafePadRight(this string value, int totalWidth, char paddingChar) => !string.IsNullOrEmpty(value) ? value.PadRight(totalWidth, paddingChar) : string.Empty;

    }
}
