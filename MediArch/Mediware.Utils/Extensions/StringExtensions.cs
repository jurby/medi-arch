using System.Text.RegularExpressions;

namespace Mediware.Utils.Extensions
{
    public static class StringExtensions
    {
        public static bool IsValidPhoneNumber(this string phoneNumber)
        {
            var reg = new Regex(@"[^\d]");
            return phoneNumber != null && reg.Replace(phoneNumber, string.Empty).Length >= 9;
        }

        public static bool IsEmail(this string emailString)
        {
            if (string.IsNullOrEmpty(emailString))
                return false;

            return Regex.IsMatch(emailString,
                    @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                    @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$",
                    RegexOptions.IgnoreCase);
        }
    }
}
