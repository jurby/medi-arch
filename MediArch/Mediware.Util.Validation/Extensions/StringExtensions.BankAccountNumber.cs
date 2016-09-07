using Mediware.Util.Validation.Helpers;

namespace Mediware.Util.Validation.Extensions
{
    public static partial class StringExtensions
    {
        public static bool IsValidBankAccountNumber(this string value)
        {
            return BankAccountNumberHelper.IsValidBankAccountNumber(value);
        }
    }
}
