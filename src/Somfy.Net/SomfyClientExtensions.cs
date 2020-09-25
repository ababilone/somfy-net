using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Somfy.Net
{
  public static class SomfyClientExtensions
  {
    public static IServiceCollection AddSomfyClient(this IServiceCollection serviceCollection, Func<IServiceProvider, Func<Task<string>>> getAccessTokenAsync)
    {
      serviceCollection.AddSingleton(serviceProvider => new SomfyAuthorizationContext(getAccessTokenAsync(serviceProvider)));
      serviceCollection.AddSingleton<SomfyClient>();
      serviceCollection.AddHttpClient<SomfyClient>();
      return serviceCollection;
    }
  }
}
