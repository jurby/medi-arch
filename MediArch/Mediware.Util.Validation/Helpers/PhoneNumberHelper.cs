using System.Text.RegularExpressions;

namespace Mediware.Util.Validation.Helpers
{
    public static class PhoneNumberHelper
    {
        public const string PhoneNumberValidFormat = @"^(\+420)?\s?[1-9][0-9]{2}\s?[0-9]{3}\s?[0-9]{3}$";

        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            phoneNumber = phoneNumber.Trim();
            return !string.IsNullOrWhiteSpace(phoneNumber) && Regex.IsMatch(phoneNumber, PhoneNumberValidFormat);
        }
    }
}
