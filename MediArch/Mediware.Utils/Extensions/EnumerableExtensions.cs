using System;
using System.Collections.Generic;

namespace Mediware.Utils.Extensions
{
    public static class EnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> enumeration, Action<T> action)
        {
            foreach (var item in enumeration)
            {
                action(item);
            }
        }

        public static IEnumerable<T> ForEachAsEnumerable<T>(this IEnumerable<T> enumeration, Action<T> action)
        {
            foreach (var item in enumeration)
            {
                action(item);
                yield return item;
            }
        }
    }
}
