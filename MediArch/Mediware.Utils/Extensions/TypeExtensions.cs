using System;
using System.Linq;

namespace Mediware.Utils.Extensions
{
    public static class TypeExtensions
    {
        /// <summary>
        /// Get a name of type
        /// </summary>
        /// <returns>Lower case type name.</returns>
        public static string GetNameByType(this Type type)
        {
            return type.Name;
        }


        public static bool BasicInheritsOrImplements(this Type child, Type parent)
        {
            return child.GetInterfaces().Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == parent);
        }

        public static bool InheritsOrImplements(this Type child, Type parent)
        {
            parent = ResolveGenericTypeDefinition(parent);

            var currentChild = child.IsGenericType
                ? child.GetGenericTypeDefinition()
                : child;

            while (currentChild != typeof(object))
            {
                if (parent == currentChild || HasAnyInterfaces(parent, currentChild))
                    return true;

                currentChild = currentChild.BaseType != null
                               && currentChild.BaseType.IsGenericType
                    ? currentChild.BaseType.GetGenericTypeDefinition()
                    : currentChild.BaseType;

                if (currentChild == null)
                    return false;
            }
            return false;
        }

        #region Helpers

        private static bool HasAnyInterfaces(Type parent, Type child)
        {
            return child.GetInterfaces()
                .Any(childInterface =>
                {
                    var currentInterface = childInterface.IsGenericType
                        ? childInterface.GetGenericTypeDefinition()
                        : childInterface;

                    return currentInterface == parent;
                });
        }

        private static Type ResolveGenericTypeDefinition(Type parent)
        {
            bool shouldUseGenericType = !(parent.IsGenericType && parent.GetGenericTypeDefinition() != parent);

            if (parent.IsGenericType && shouldUseGenericType)
                parent = parent.GetGenericTypeDefinition();
            return parent;
        }

        #endregion

        public static bool IsNullableEnum(this Type t)
        {
            return t.IsGenericType &&
                   t.GetGenericTypeDefinition() == typeof(Nullable<>) &&
                   t.GetGenericArguments()[0].IsEnum;
        }

        public static bool IsEnum(this Type t)
        {
            var u = Nullable.GetUnderlyingType(t);
            return (u != null) && u.IsEnum;
        }
    }
}