using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Somfy.Net.Contracts;

namespace Somfy.Net
{
  public class SomfyClient
  {
    private static readonly Uri BaseUrl = new Uri("https://api.somfy.com/api/v1/");
    private readonly HttpClient _httpClient;
    private readonly SomfyAuthorizationContext _somfyAuthorizationContext;

    public SomfySiteClient Site => new SomfySiteClient(this);
    public SomfyDeviceClient Device => new SomfyDeviceClient(this);

    public SomfyClient(SomfyAuthorizationContext somfyAuthorizationContext, HttpClient httpClient)
    {
      _somfyAuthorizationContext = somfyAuthorizationContext;
      _httpClient = httpClient;
      _httpClient.BaseAddress = BaseUrl;
    }

    private async Task<HttpRequestMessage> CreateHttpRequestMessageAsync(HttpMethod httpMethod, Uri requestUri)
    {
      var accessToken = await _somfyAuthorizationContext.GetAccessTokenAsync();
      var httpRequestMessage = new HttpRequestMessage(httpMethod, requestUri);
      httpRequestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
      return httpRequestMessage;
    }

    public async Task<Response<T>> GetAsync<T>(string relativePath)
    {
      var requestUri = new Uri(BaseUrl, relativePath);
      var httpRequestMessage = await CreateHttpRequestMessageAsync(HttpMethod.Get, requestUri).ConfigureAwait(false);
      var httpResponseMessage = await _httpClient.SendAsync(httpRequestMessage).ConfigureAwait(false);
      return await httpResponseMessage.AsAsync<T>().ConfigureAwait(false);
    }

    public async Task<Response<T>> PostAsync<T>(string relativePath, object data)
    {
      var requestUri = new Uri(BaseUrl, relativePath);
      var httpRequestMessage = await CreateHttpRequestMessageAsync(HttpMethod.Post, requestUri).ConfigureAwait(false);
      var httpResponseMessage = await _httpClient.SendAsync(httpRequestMessage.WithContent(data)).ConfigureAwait(false);
      return await httpResponseMessage.AsAsync<T>().ConfigureAwait(false);
    }
  }
}
