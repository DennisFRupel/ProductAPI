using System.Text.Json;

namespace ProductAPI.IntegrationTests.Utils;
public static class ResponseExtension
{
  private static readonly JsonSerializerOptions JsonSerializerOptions = new() { PropertyNameCaseInsensitive = true };

  public async static Task<T?> GetJson<T>(this HttpResponseMessage response)
  {
    return JsonSerializer.Deserialize<T>(
        await response.Content.ReadAsStringAsync(),
        JsonSerializerOptions);
  }
}
