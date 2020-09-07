namespace Somfy.Net.Contracts
{
  public class Error
  {
    public string Uuid { get; set; }
    public string Message { get; set; }
    public object Data { get; set; }
  }
}
