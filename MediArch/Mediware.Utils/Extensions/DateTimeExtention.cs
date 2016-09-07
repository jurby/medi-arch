using System;
using System.Globalization;

namespace Mediware.Utils.Extensions
{
    public static class DateTimeExtention
    {
        // TODO: Need to provide culturaly neutral versions.

        public static DateTime GetStartOfWeek(this DateTime dt, CultureInfo culture)
        {
            var result = dt.AddDays(-((dt.DayOfWeek - culture.DateTimeFormat.FirstDayOfWeek + 7) % 7)).Date;
            return result;
        }

        public static DateTime GetEndOfWeek(this DateTime dt, CultureInfo culture)
        {
            var start = GetStartOfWeek(dt, culture);
            var end = start.AddDays(7).AddTicks(-1);
            return end;
        }

        public static DateTime GetStartOfWeek(this DateTime dt)
        {
            var result = dt.Subtract(TimeSpan.FromDays((int)dt.DayOfWeek)).Date;
            return result;
        }

        public static DateTime GetEndOfWeek(this DateTime dt)
        {
            var result = dt.GetStartOfWeek().Date.AddDays(6).AddTicks(-1);
            return result;
        }

        public static DateTime GetStartOfWeek(this DateTime dt, int year, int week)
        {
            var dayInWeek = new DateTime(year, 1, 1).AddDays((week - 1) * 7);
            return dayInWeek.GetStartOfWeek();
        }

        public static DateTime GetEndOfWeek(this DateTime dt, int year, int week)
        {
            var dayInWeek = new DateTime(year, 1, 1).AddDays((week - 1) * 7);
            return dayInWeek.GetEndOfWeek();
        }
    }
}
