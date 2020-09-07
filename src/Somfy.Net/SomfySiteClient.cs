using System.Threading.Tasks;
using Somfy.Net.Contracts;
using Somfy.Net.Contracts.Devices;

namespace Somfy.Net
{
  public class SomfySiteClient
  {
    private readonly SomfyClient _somfyClient;

    public SomfySiteClient(SomfyClient somfyClient) => _somfyClient = somfyClient;

    public Task<Response<Site[]>> GetAsync() => _somfyClient.GetAsync<Site[]>($"/api/v1/site");

    public Task<Response<Site>> GetAsync(string siteId) => _somfyClient.GetAsync<Site>($"/api/v1/site/{siteId}");

    public Task<Response<Device[]>> GetDevicesAsync(string siteId) => _somfyClient.GetAsync<Device[]>($"/api/v1/site/{siteId}/device");
  }
}