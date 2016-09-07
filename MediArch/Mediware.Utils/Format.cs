using Humanizer;

namespace Mediware.Utils
{
    public static class Format
    {
        public static string ByteSizeHumanize(long size)
        {
            return (size == 0) ? "0 b" : size.Bytes().ToString("#.#");
        }
    }
}
