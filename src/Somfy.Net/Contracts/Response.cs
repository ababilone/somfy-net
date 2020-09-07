using System.Text.Json.Serialization;

namespace Somfy.Net.Contracts
{
  public class Response
  {
    public bool Success => Fault == null;

    [JsonPropertyName("fault")]
    public Fault Fault { get; set; }

    public Error Error { get; set; }
  }

  public class Response<T> : Response
  {
    public Response()
    {

    }

    public Response(T result) => Result = result;

    public Response(Error error) => Error = error;


    [JsonIgnore]
    public T Result { get; set; }
  }
}
