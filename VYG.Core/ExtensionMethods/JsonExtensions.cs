using Newtonsoft.Json;

namespace VYG.Core.ExtensionMethods
{
    public static class JsonExtensions
    {
        public static string ToJson(this object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
