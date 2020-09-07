using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Somfy.Net
{
  public static class SomfyClientExtensions
  {
    public static IServiceCollection AddSomfyClient(this IServiceCollection serviceCollection, Func<Task<string>> getAccessTokenAsync)
    {
      serviceCollection.AddSingleton(new SomfyAuthorizationContext(getAccessTokenAsync));
      serviceCollection.AddSingleton<SomfyClient>();
      serviceCollection.AddHttpClient<SomfyClient>();
      return serviceCollection;
    }
  }
}
