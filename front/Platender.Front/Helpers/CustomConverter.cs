namespace Platender.Front.Helpers
{
    public static class CustomConverter
    {
        public static string ConvertToBase64String(byte[] bytes, bool withImageType = true)
        {
            var base64 = Convert.ToBase64String(bytes);
            Console.WriteLine(base64);
            return withImageType ? $"data:image/jpeg;base64,{base64}" : base64;
        }

    }
}
