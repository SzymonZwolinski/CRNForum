﻿namespace Platender.Core.Helpers
{
    public static class StringExtensions
    {
        /// <summary>
        /// Try to cast to enum, else return default
        /// </summary>
        public static T? TryToParseToEnum<T>(this string input) where T : struct
        {
            object res;
            if (Enum.TryParse(typeof(T), input, out res))
            {
                return (T)res;
            }
            return null;
        }
    }
}
