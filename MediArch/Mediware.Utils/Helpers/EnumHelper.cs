using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Mediware.Utils.Helpers
{
    public static class EnumHelper
    {
        public static IEnumerable<T> LowerThan<T>(T value) where T : struct
        {
            var underlyingType = Enum.GetUnderlyingType(typeof(T));
            var compareToMethod = underlyingType.GetMethod("CompareTo", new[] { underlyingType });
            var values = AllValues<T>().ToArray();
            for (var index = 0; index < values.Length; index++)
            {
                var comparison = (int)compareToMethod.Invoke(Convert.ChangeType(value, underlyingType, CultureInfo.InvariantCulture), new[] { values.GetValue(index) });
                if (comparison > 0)
                {
                    yield return (T)values.GetValue(index);
                }
            }
        }

        public static IEnumerable<T> GreaterThan<T>(T value) where T : struct
        {
            var underlyingType = Enum.GetUnderlyingType(typeof(T));
            var compareToMethod = underlyingType.GetMethod("CompareTo", new[] { underlyingType });
            var values = AllValues<T>().ToArray();
            for (var index = 0; index < values.Length; index++)
            {
                var comparison = (int)compareToMethod.Invoke(Convert.ChangeType(value, underlyingType, CultureInfo.InvariantCulture), new [] { values.GetValue(index) });
                if (comparison < 0)
                {
                    yield return (T)values.GetValue(index);
                }
            }
        }

        public static IEnumerable<T> Filter<T>(Func<T, bool> filter) where T : struct
        {
            return AllValues<T>().Where(filter);
        }

        public static IEnumerable<T> AllValues<T>() where T : struct
        {
            var type = typeof(T);
            return type.IsEnum ? Enum.GetValues(type).Cast<T>() : Enumerable.Empty<T>();
        }
    }
}
