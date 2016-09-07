using System;
using Newtonsoft.Json;

namespace Mediware.Utils
{
    public static class Serializer
    {
        public static string ToIndentedJson(object o)
        {
            return ToJson(o, Formatting.Indented);
        }

        public static string ToJson(object o)
        {
            return ToJson(o, Formatting.None);
        }

        private static string ToJson(object o, Formatting formatting)
        {
            return JsonConvert.SerializeObject(o, formatting);
        }

        public static object FromJson(string value, Type type)
        {
            return JsonConvert.DeserializeObject(value, type);
        }
    }
}
