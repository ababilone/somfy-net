using System.Net.Http;
using System.Threading.Tasks;
using Somfy.Net.Contracts;
using System.Text.Json;

namespace Somfy.Net
{
  public static class HttpResponseMessageUtils
  {
    private static readonly JsonSerializerOptions JsonSerializerOptions = new JsonSerializerOptions
    {
      PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
      Converters = { new DeviceJsonConverter() }
    };

    public static async Task<Response<T>> AsAsync<T>(this HttpResponseMessage httpResponseMessage)
    {
      var jsonStream = await httpResponseMessage.Content.ReadAsStreamAsync().ConfigureAwait(false);

      if (httpResponseMessage.IsSuccessStatusCode)
      {
        var result = await JsonSerializer.DeserializeAsync<T>(jsonStream, JsonSerializerOptions).ConfigureAwait(false);
        return new Response<T>(result);
      }

      var error = await JsonSerializer.DeserializeAsync<Error>(jsonStream, JsonSerializerOptions).ConfigureAwait(false);
      return new Response<T>(error);
    }


    public static HttpContent AsHttpContent<T>(this T t)
    {
      var json = JsonSerializer.Serialize(t, JsonSerializerOptions);
      return new StringContent(json, System.Text.Encoding.UTF8, "application/json");
    }

    public static HttpRequestMessage WithContent<T>(this HttpRequestMessage httpRequestMessage, T t)
    {
      httpRequestMessage.Content = t.AsHttpContent();
      return httpRequestMessage;
    }
  }
}
