using System.Threading.Tasks;
using Somfy.Net.Contracts;
using Somfy.Net.Contracts.Devices;

namespace Somfy.Net
{
  public class SomfyDeviceClient
  {
    private readonly SomfyClient _somfyClient;

    public SomfyDeviceClient(SomfyClient somfyClient) => _somfyClient = somfyClient;

    public Task<Response<Device>> GetAsync(string deviceId) => _somfyClient.GetAsync<Device>($"/api/v1/device/{deviceId}");

    public Task<Response<DeviceExecResponse>> ExecAsync(string deviceId, string name, params DeviceExecParameter[] parameters) => _somfyClient.PostAsync<DeviceExecResponse>($"/api/v1/device/{deviceId}/exec", new
    {
      name,
      parameters
    });
  }
}