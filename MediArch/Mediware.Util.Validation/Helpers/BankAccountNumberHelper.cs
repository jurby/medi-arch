using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Mediware.Util.Validation.Helpers
{
    public static class BankAccountNumberHelper
    {
        public const char BankAccountNumberPrefixDelimiter = '-';
        public const char BankAccountNumberDelimiter = '/';
        public const string BankAccountNumberFormat = @"(\d{0,6}-)?\d{2,10}/\d{4}";

        private const char Zero = '0';

        private static readonly int[] WeightsPrefix = { 10, 5, 8, 4, 2, 1 };
        private static readonly int[] WeightsMain = { 6, 3, 7, 9, 10, 5, 8, 4, 2, 1 };

        public static bool IsValidBankAccountNumber(string bankAccountNumber)
        {
            bankAccountNumber = bankAccountNumber.Trim();

            if (string.IsNullOrWhiteSpace(bankAccountNumber)) return false;
            if (!Regex.IsMatch(bankAccountNumber, BankAccountNumberFormat)) return false;

            var withoutSufix = bankAccountNumber.Split(BankAccountNumberDelimiter)[0];
            var parts = withoutSufix.Split(BankAccountNumberPrefixDelimiter);
            if (parts.Length == 1)
            {
                return CheckWeightedModulo(WeightsMain, parts[0]) == 0;
            }
            return CheckWeightedModulo(WeightsPrefix, parts[0]) + CheckWeightedModulo(WeightsMain, parts[1]) == 0;
        }

        #region Helpers

        private static int CheckWeightedModulo(IList<int> weights, string number)
        {
            number = number ?? string.Empty;
            number = number.PadLeft(weights.Count, Zero);
            var sum = 0;
            for (var i = 0; i < weights.Count; i++)
            {
                var single = int.Parse(number[i].ToString());
                sum += single * weights[i];
            }
            return sum % 11;
        }

        #endregion
    }
}
