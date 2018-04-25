using System;

namespace Umrbrwn.Objtention
{
    public static class ObjUtils
    {
        /// <summary>
        /// Converts provided text to upper case using current culture scheme
        /// </summary>
        /// <param name="text">Input string</param>
        /// <returns>Upper case string</returns>
        public static string ToTitleCase(this string text)
        {
            return System.Threading.Thread.CurrentThread
                .CurrentCulture.TextInfo.ToTitleCase(text.ToLower());
        }

        /// <summary>
        /// Does case-insensitive comparison of two strings
        /// </summary>
        /// <param name="str1">This string</param>
        /// <param name="str2">String to compare with</param>
        /// <returns>True when strings are equals</returns>
        public static bool EqualsIgnoreCase(this string str1, string str2)
        {
            return str1.Equals(str2, StringComparison.OrdinalIgnoreCase);
        }
        
        /// <summary>
        /// Checks if this sring equals to any given string params, while ignoring case
        /// </summary>
        /// <param name="str">This string</param>
        /// <param name="val">String array to compare with</param>
        /// <returns>Returns true if string params contains this string</returns>
        public static bool EqualsIgnoreCase(this string str, params string[] val)
        {
            return val.Any(e => e.IndexOf(str, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        /// <summary>
        /// Converts this object into integer
        /// </summary>
        /// <param name="obj">This object</param>
        /// <returns>Returns 0 when object is null, DBNull or empty string type</returns>
        public static int ToInt(this object obj)
        {
            if (obj == null || string.IsNullOrEmpty(obj.ToString()) || obj == DBNull.Value)
                return 0;

            return Convert.ToInt32(obj);
        }

        /// <summary>
        /// Converts this object to primitive type
        /// </summary>
        /// <typeparam name="T">Target primitive type</typeparam>
        /// <param name="obj">This object</param>
        /// <returns>Returns default value of type T when object is null, DBNull or empty string type</returns>
        public static T ToType<T>(this object obj) where T : struct
        {
            if (obj == null || string.IsNullOrEmpty(obj.ToString()) || obj == DBNull.Value)
                return default(T);

            return (T)obj;
        }

        ///         /// <summary>
        /// Converts this object to given nullable type T
        /// </summary>
        /// <typeparam name="T">Target Nullable type</typeparam>
        /// <param name="obj">This object</param>
        /// <returns>Returns default value of type T when object is null, DBNull or empty string type</returns>
        public static Nullable<T> ToNullableType<T>(this object obj) where T : struct
        {
            Nullable<T> result = new Nullable<T>();
            try
            {
                string s = obj.ToString();
                if (!string.IsNullOrEmpty(s) && s.Trim().Length > 0)
                    result = (T)obj;
            }
            catch { }
            return result;
        }

        /// <summary>
        /// Rounds the given value to <seealso cref="Umrbrwn.Objtention.Constants">specified precision</seealso>
        /// </summary>
        /// <param name="value">Input value</param>
        /// <returns>Precise value</returns>
        public static decimal ToPrecised(this decimal value)
        {
            return value == 0 ? value : Math.Round(value, Constants.DECIMAL_PRECISSION);
        }

        /// <summary>
        /// Rounds the given value to provided precision
        /// </summary>
        /// <param name="value">Input value</param>
        /// <returns>Precise value</returns>
        public static decimal ToPrecised(this decimal value, int precission)
        {
            return value == 0 ? value : Math.Round(value, precission);
        }

        /// <summary>
        /// Rounds the given value to <seealso cref="Umrbrwn.Objtention.Constants">specified precision</seealso>
        /// </summary>
        /// <param name="value">Input value</param>
        /// <returns>Returns 0 if value is NaN or Infinity otherwise Precise value</returns>
        public static double ToPrecised(this double value)
        {
            return value == 0 ||
                double.IsNaN(value) ||
                double.IsInfinity(value) ||
                double.IsNegativeInfinity(value) ||
                double.IsPositiveInfinity(value) ?
                0 : Math.Round(value, Constants.DOUBLE_PRECISSION);
        }
    }
}
