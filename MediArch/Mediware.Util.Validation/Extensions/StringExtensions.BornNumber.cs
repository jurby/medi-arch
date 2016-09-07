using Mediware.Util.Validation.Helpers;

namespace Mediware.Util.Validation.Extensions
{
    public static partial class StringExtensions
    {
        public static bool IsValidBornNumber(this string value)
        {
            return BornNumberHelper.IsValidBornNumber(value);
        }

        public static bool IsWomanByBornNumber(this string value)
        {
            return BornNumberHelper.IsWoman(value);
        }
    }
}
