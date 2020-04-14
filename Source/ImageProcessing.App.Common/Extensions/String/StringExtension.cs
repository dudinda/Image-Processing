using System.ComponentModel;

namespace ImageProcessing.App.Common.Extensions.StringExtensions
{
    /// <summary>
    /// Extension methods for a <see cref="string"> class.
    /// </summary>
    public static class StringExtension
    {
        public static bool TryParse<TValue>(this string input, out TValue value)
            where TValue : struct
        {
            var converter = TypeDescriptor.GetConverter(typeof(TValue));
            try
            {
                value = (TValue)converter.ConvertFromString(input);
                return true;
            }
            catch
            {
                value = default(TValue);
                return false;
            }
        }
    }
}
