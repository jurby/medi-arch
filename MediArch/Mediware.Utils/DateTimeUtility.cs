using System;
using System.Globalization;

namespace Mediware.Utils
{
    public static class DateTimeUtility
    {
        internal const string TickFormatD19 = "d19";

        public static readonly DateTime UnixEpochUtc = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

        /// <summary>
        /// Get ID by DateTime.Ticks by Universal time
        /// </summary>
        /// <returns></returns>
        public static string TickId()
        {
            var invertedTicks = (DateTime.MaxValue - DateTime.Now.ToUniversalTime()).Ticks;
            return invertedTicks.ToString(TickFormatD19, CultureInfo.InvariantCulture);
        }

        public static string GetTicksByDateTime(DateTime dateTime)
        {
            var invertedTicks = (DateTime.MaxValue - dateTime.ToUniversalTime()).Ticks;
            return invertedTicks.ToString(TickFormatD19, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Return date time value by inverted ticks
        /// </summary>
        /// <param name="invertedTicks"></param>
        /// <returns></returns>
        public static DateTime GetDateTimeByInvertedTicks(string invertedTicks)
        {
            var dt = new DateTime(DateTime.MaxValue.Ticks - long.Parse(invertedTicks));
            return dt;
        }

        /// <summary>
        /// Calculate exponential backoff with +/- 20% tolerance
        /// </summary>
        /// <param name="actualValue">Actual value</param>
        /// <param name="maximumValue">Maximum value</param>
        /// <param name="minimum"></param>
        /// <param name="maximum"></param>
        /// <param name="delta"></param>
        /// <returns></returns>
        public static TimeSpan ExponentialTimeout(int actualValue, int maximumValue, TimeSpan minimum, TimeSpan maximum, TimeSpan delta)
        {
            if (actualValue >= maximumValue) return maximum;

            var r = new Random();
            var increment = (int)((Math.Pow(2, actualValue) - 1) * r.Next((int)(delta.TotalMilliseconds * 0.8), (int)(delta.TotalMilliseconds * 1.2)));
            var timeToSleepMsec = (int)Math.Min(minimum.TotalMilliseconds + increment, maximum.TotalMilliseconds);
            return TimeSpan.FromMilliseconds(timeToSleepMsec);
        }
    }
}
