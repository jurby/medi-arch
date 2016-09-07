using System;
using System.Globalization;
using System.Text.RegularExpressions;
using Mediware.Util.Validation.Utils.Enumerations;

namespace Mediware.Util.Validation.Helpers
{
    public static class BornNumberHelper
    {
        public const string BornNumberValidFormat = @"^(\d\d)(\d\d)(\d\d)/(\d\d\d)(\d?)$";
        public const string BornNumberSpecialValidFormat = "^(\\d\\d)(\\d\\d)(\\d\\d)/(0000)$";

        private const int Century18Th = 18;
        private const int Century19Th = 19;
        private const int Century20Th = 20;

        public static bool IsValidBornNumber(string bornNumber)
        {
            bornNumber = bornNumber.Trim();

            var m = Regex.Match(bornNumber, BornNumberValidFormat);
            if (!m.Success) return false;

            var year = int.Parse(m.Groups[1].ToString());
            var month = int.Parse(m.Groups[2].ToString());
            var day = int.Parse(m.Groups[3].ToString());

            if (!Regex.Match(bornNumber, BornNumberSpecialValidFormat).Success)
            {
                var forModulo = string.Empty + m.Groups[1] + m.Groups[2] + m.Groups[3] + m.Groups[4];
                int c;
                //000 (year < 1954)
                if (!int.TryParse(m.Groups[5].ToString(), out c))
                {
                    year += (year > 53 ? Century18Th : Century19Th) * 100;

                }
                //0000 (year >= 1954)
                else
                {
                    var mod = (int.Parse(forModulo)) % 11;
                    if (mod == 10) mod = 0;
                    if (mod != c) return false;

                    year += (year > 53 ? Century19Th : Century20Th) * 100;
                }
            }

            if (month > 70 && year > 2003) month -= 70;
            else if (month > 50) month -= 50;
            else if (month > 20 && year > 2003) month -= 20;

            return CalendarHelper.IsValidDate(
                year.ToString(CultureInfo.InvariantCulture),
                month.ToString(CultureInfo.InvariantCulture),
                day.ToString(CultureInfo.InvariantCulture));
        }

        public static bool IsWoman(string bornNumber)
        {
            int month;
            if (string.IsNullOrWhiteSpace(bornNumber) || bornNumber.Length < 6 || !int.TryParse(bornNumber.Substring(2, 2), out month))
                throw new ArgumentException("Invalid bornnumber format");

            return month > 50;
        }

        public static Gender GenderFromBornNumber(string bornNumber)
        {
            if (bornNumber == null || !IsValidBornNumber(bornNumber)) return Gender.Unknown;

            var month = int.Parse(bornNumber.Substring(2, 2));
            if ((month >= 1 && month <= 12) || (month >= 21 && month <= 32)) return Gender.Male;
            if ((month >= 51 && month <= 62) || (month >= 71 && month <= 82)) return Gender.Female;

            return Gender.Unknown;
        }

        public static DateTime GetDateFromBornNumber(string bornNumber)
        {
            if (bornNumber == null || !IsValidBornNumber(bornNumber)) return new DateTime(Century19Th * 100, 1, 1);

            var yearPart = bornNumber.Substring(0, 2);
            var monthPart = bornNumber.Substring(2, 2);
            var dayPart = bornNumber.Substring(4, 2);
            var suffixPart = bornNumber.Substring(7, bornNumber.Length == 11 ? 4 : 3);
            var year = int.Parse((suffixPart.Length < 4 || int.Parse(yearPart) >= 54 ? Century19Th : Century20Th) + yearPart);
            var month = int.Parse(monthPart) % 50;
            var day = int.Parse(dayPart);

            return new DateTime(year, month, day);
        }
    }
}
