using StackExchange.Redis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RPGClash.Infrastucture.Persistance
{
    public class GameStorageService : IGameStorageService
    {
        private readonly IDatabase _db;

        public GameStorageService(IConnectionMultiplexer redis)
        {
            _db = redis.GetDatabase();
        }

        public async Task SetValue<T>(string key, T value)
        {
            if (value == null)
            {
                throw new Exception("Model Empty");
            }
            var stringVal = JsonSerializer.Serialize<T>(value, GetJsonSerializerOptions());
            await _db.StringSetAsync(key, stringVal);
        }

        public async Task<T> GetValue<T>(string key)
        {
            var val = await _db.StringGetAsync(key);
            if (val == default)
            {
                throw new Exception("Model Empty");
            }
            return JsonSerializer.Deserialize<T>(val, GetJsonSerializerOptions());
        }

        private static JsonSerializerOptions GetJsonSerializerOptions()
        {
            return new JsonSerializerOptions()
            {
                PropertyNamingPolicy = null,
                WriteIndented = true,
                AllowTrailingCommas = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            };
        }
    }
}
