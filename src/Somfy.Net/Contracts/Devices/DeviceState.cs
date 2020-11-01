using System.Text.Json;

namespace Somfy.Net.Contracts.Devices
{
  public class DeviceState
  {
    public string Name { get; set; }
    public JsonElement Value { get; set; }
    public string Type { get; set; }
  }
}
