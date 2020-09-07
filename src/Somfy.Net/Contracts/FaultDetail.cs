using System.Text.Json.Serialization;

namespace Somfy.Net.Contracts
{
  public class FaultDetail
  {
    [JsonPropertyName("errorcode")]
    public string ErrorCode { get; set; }
  }
}