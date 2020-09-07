using System.Text.Json.Serialization;

namespace Somfy.Net.Contracts
{
  public class Fault
  {
    [JsonPropertyName("faultstring")]
    public string FaultString { get; set; }

    [JsonPropertyName("detail")]
    public FaultDetail Detail { get; set; }
  }
}