namespace Platender.Front.Helpers
{
    public static class EnumHelper
    {
        public static TEnum? MapStringToEnumOrNull<TEnum>(this string input) where TEnum : struct, Enum
        {
            if (Enum.TryParse<TEnum>(input, out TEnum result))
            {
                return result;
            }

            return null;
        }
    }
}