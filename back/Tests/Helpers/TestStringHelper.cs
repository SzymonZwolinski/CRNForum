using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Helpers
{
    public static class TestStringHelper
    {
        /// <summary>
        /// Generate string with specified length.
        /// Optional character can be used to fill with specific char.
        /// </summary>
        /// <param name="len">Length of generated string.</param>
        /// <param name="character">Char that will be repeated.</param>
        /// <returns></returns>
        public static string GenerateStrWithLen(int len, char character = '*') => new string(character, len);
    }
}
