using System;
using System.Collections.Generic;

namespace DevToolkit.Helpers
{
    public static class Argument
    {
        /// <summary>
        /// Check if a object is null or default value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="name"></param>
        /// <exception cref="ArgumentNullException">Throws when obj is null</exception>
        public static void IsNotNull<T>(this T obj, string name)
        {
            if (EqualityComparer<T>.Default.Equals(obj, default(T)))
                throw new ArgumentNullException(name);
        }

        /// <summary>
        /// Check if a guid is empty value
        /// </summary>
        /// <param name="value"></param>
        /// <param name="name"></param>
        /// <exception cref="ArgumentNullException">Throws when is obj is Guid.Empty</exception>
        public static void IsNotEmptyGuid(this Guid value, string name)
        {
            if(value == Guid.Empty)
                throw new ArgumentNullException(name);
        }

        /// <summary>
        /// Check if a string is empty or null
        /// </summary>
        /// <param name="value"></param>
        /// <param name="name"></param>
        /// <exception cref="ArgumentNullException">Throws when obj is empty or null</exception>
        public static void IsNotEmptyString(this string value, string name)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(name);
        }
    }
}
