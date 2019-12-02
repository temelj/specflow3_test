using System;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TechTalk.SpecFlow;

namespace Project.Testing.Helpers
{
    public static class ResourceHelper
    {

        public static async Task<T> GetJsonResourceAsync<T>(this Assembly assembly, string resourceName)
        {
            Stream jsonStream = GetManifestResourceStream(assembly, resourceName);

            using (var streamReader = new StreamReader(jsonStream))
            {
                return JsonConvert.DeserializeObject<T>(await streamReader.ReadToEndAsync());
            }
        }

        public static T GetJsonResource<T>(this Assembly assembly, string resourceName)
        {
            Stream jsonStream = GetManifestResourceStream(assembly, resourceName);

            using (var streamReader = new StreamReader(jsonStream))
            {
                return JsonConvert.DeserializeObject<T>(streamReader.ReadToEnd());
            }
        }

        private static Stream GetManifestResourceStream(Assembly assembly, string resourceName)
        {
            var ext = Path.GetExtension(resourceName);
            var fqResourceName = $"{assembly.GetName().Name}.{ (!ext.Equals(".json", StringComparison.OrdinalIgnoreCase) ? resourceName : Path.GetFileNameWithoutExtension(resourceName))}.json";

            var jsonStream = assembly.GetManifestResourceStream(fqResourceName);

            return jsonStream;
        }
    }
}
