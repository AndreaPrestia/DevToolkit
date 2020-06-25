using System;

namespace DevToolkit.Extensions
{
    public static class Object
    {
        public static string SafeToString(this object obj) => obj == null ? string.Empty : obj.ToString();

        public static int SafeIntParse(this object obj)
        {
            if (int.TryParse(obj.SafeToString(), out int result))
            {
                return result;
            }

            return result;
        }

        public static double SafeDoubleParse(this object obj)
        {
            if (double.TryParse(obj.SafeToString(), out double result))
            {
                return result;
            }

            return result;
        }

        public static float SafeFloatParse(this object obj)
        {
            if (float.TryParse(obj.SafeToString(), out float result))
            {
                return result;
            }

            return result;
        }

        public static decimal SafeDecimalParse(this object obj)
        {
            if (decimal.TryParse(obj.SafeToString(), out decimal result))
            {
                return result;
            }

            return result;
        }

        public static long SafeLongParse(this object obj)
        {
            if (long.TryParse(obj.SafeToString(), out long result))
            {
                return result;
            }

            return result;
        }

        public static byte SafeByteParse(this object obj)
        {
            if (byte.TryParse(obj.SafeToString(), out byte result))
            {
                return result;
            }

            return result;
        }

        public static DateTime SafeDateTimeParse(this object obj)
        {
            if (DateTime.TryParse(obj.SafeToString(), out DateTime result))
            {
                return result;
            }

            return result;
        }

        public static DateTime? SafeDateTimeNullableParse(this object obj)
        {
            if (DateTime.TryParse(obj.SafeToString(), out DateTime result))
            {
                return result;
            }

            return result;
        }

        public static bool SafeBoolParse(this object obj)
        {
            if (bool.TryParse(obj.SafeToString(), out bool result))
            {
                return result;
            }

            return result;
        }
    }
}
