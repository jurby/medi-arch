using Mediware.Util.Validation.Helpers;

namespace Mediware.Util.Validation.Extensions
{
    public static partial class StringExtensions
    {
        public static bool IsValidPhoneNumber(this string value)
        {
            return PhoneNumberHelper.IsValidPhoneNumber(value);
        }
    }
}
