using System.Text;
using System.Text.Json;

namespace Application.Common
{
    public static class FilterEncoder
    {
        public static T? Decode<T>(string? base64) where T : class
        {
            if (string.IsNullOrWhiteSpace(base64)) return null;

            var json = Encoding.UTF8.GetString(Convert.FromBase64String(base64));
            return JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }

        public static string Encode<T>(T filter)
        {
            var json = JsonSerializer.Serialize(filter);
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(json));
        }
    }
}