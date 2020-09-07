using System;
using System.Threading.Tasks;

namespace Somfy.Net
{
  public class SomfyAuthorizationContext
  {
    readonly Func<Task<string>> _getAccessTokenAsync;

    public SomfyAuthorizationContext(Func<Task<string>> getAccessTokenAsync) => _getAccessTokenAsync = getAccessTokenAsync;

    public async Task<string> GetAccessTokenAsync() => await _getAccessTokenAsync();
  }
}
