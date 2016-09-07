using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Mediware.Utils
{
    public static class ReflectionUtility<T> where T: class
    {
        public static string PropertyName<U>(Expression<Func<T, U>> expression)
        {
            return PropertyInfo(expression).Name;
        }

        public static Type PropertyType<U>(Expression<Func<T, U>> expression)
        {
            return PropertyInfo(expression).PropertyType;
        }

        public static PropertyInfo PropertyInfo<U>(Expression<Func<T, U>> expression)
        {
            var member = expression.Body as MemberExpression;
            if (member?.Member is PropertyInfo)
                return (PropertyInfo) member.Member;

            throw new ArgumentException("Expression is not a Property", nameof(expression));
        }
    }
}
