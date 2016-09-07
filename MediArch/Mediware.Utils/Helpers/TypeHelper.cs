using Mediware.Utils.Extensions;

namespace Mediware.Utils.Helpers
{
    public class TypeHelper
    {
        public static string GetNameByType<T>() where T : class
        {
            return typeof(T).GetNameByType();
        }
    }
}
