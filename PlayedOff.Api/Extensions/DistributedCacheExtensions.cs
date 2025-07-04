using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;

namespace PlayedOff.Api.Extensions
{
    public static class DistributedCacheExtensions
    {
        private static readonly JsonSerializerOptions Options = JsonSerializerOptions.Default;

        public static async Task SetAsync<T>(this IDistributedCache cache, string key, T obj) where T : class
        {
            var json = JsonSerializer.Serialize(obj, Options);
            var utf8 = Encoding.UTF8.GetBytes(json);
            await Microsoft.Extensions.Caching.Distributed.DistributedCacheExtensions.SetAsync(cache, key, utf8);
        }

        public static async Task<T?> GetAsync<T>(this IDistributedCache cache, string key) where T : class
        {
            var utf8 = await cache.GetAsync(key);
            if (utf8 == null)
                return null;

            return JsonSerializer.Deserialize<T>(utf8, Options);
        }
    }
}
