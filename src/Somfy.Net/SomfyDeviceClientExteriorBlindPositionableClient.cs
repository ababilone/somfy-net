using System.Threading.Tasks;
using Somfy.Net.Contracts;
using Somfy.Net.Contracts.Devices;
using Somfy.Net.Contracts.Devices.Exterior.Blind;

namespace Somfy.Net
{
  public static class SomfyDeviceClientExteriorBlindPositionableExtensions
  {
    public static Task<Response<DeviceExecResponse>> OpenAsync(this SomfyExteriorBlindPositionableStatefulGeneric device, SomfyClient somfyClient) => somfyClient.Device.ExecAsync(device.Id, "open");

    public static Task<Response<DeviceExecResponse>> CloseAsync(this SomfyExteriorBlindPositionableStatefulGeneric device, SomfyClient somfyClient) => somfyClient.Device.ExecAsync(device.Id, "close");

    public static Task<Response<DeviceExecResponse>> StopAsync(this SomfyExteriorBlindPositionableStatefulGeneric device, SomfyClient somfyClient) => somfyClient.Device.ExecAsync(device.Id, "stop");

    public static Task<Response<DeviceExecResponse>> IdentifyAsync(this SomfyExteriorBlindPositionableStatefulGeneric device, SomfyClient somfyClient) => somfyClient.Device.ExecAsync(device.Id, "identify");

    public static Task<Response<DeviceExecResponse>> PositionAsync(this SomfyExteriorBlindPositionableStatefulGeneric device, SomfyClient somfyClient, int position) => somfyClient.Device.ExecAsync(device.Id, "position", new DeviceExecParameter("position", position));
  }
}