namespace Somfy.Net.Contracts.Devices
{
  public class DeviceExecParameter
  {
    public DeviceExecParameter(string name, object value)
    {
      Name = name;
      Value = value;
    }

    public string Name { get; set; }
    public object Value { get; set; }
  }
}
