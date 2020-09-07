using System.Linq;
using System.Text.Json.Serialization;

namespace Somfy.Net.Contracts.Devices
{
  public class Device
  {
    public string Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }

    [JsonPropertyName("parent_id")]
    public string ParentId { get; set; }

    [JsonPropertyName("site_id")]
    public string SiteId { get; set; }
    public string[] Categories { get; set; }
    public bool Available { get; set; }
    public DeviceState[] States { get; set; }
    public DeviceCapability[] Capabilities { get; set; }

    protected T GetState<T>(string name)
    {
      if (States.FirstOrDefault(state => state.Name == name)?.Value is T t)
        return t;
      return default;
    }
  }
}
