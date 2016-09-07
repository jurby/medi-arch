using System;
using System.Globalization;
using System.Linq;
using Mediware.Util.Validation.Utils;
using Mediware.Util.Validation.Utils.Enumerations;

namespace Mediware.Util.Validation.Helpers
{
    public static class CalendarHelper
    {
        public static bool IsHoliday(DateTime dateTime, Country country = Country.Cz)
        {
            var isNationalDay = false;

            var nationalDays = Holidays.GetHolidayDaysByCountry(country, dateTime.Year);
            if (nationalDays != null)
            {
                isNationalDay = Holidays.GetHolidayDaysByCountry(country, dateTime.Year)
                                        .Any(h => h.Month == dateTime.Month && h.Day == dateTime.Day);
            }

            return isNationalDay;
        }

        public static bool IsValidDate(string year, string month, string day)
        {
            DateTime date;
            return DateTime.TryParseExact(
                year.PadLeft(4, '0') + month.PadLeft(2, '0') + day.PadLeft(2, '0'),
                "yyyyMMdd",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out date);
        }
    }


}
