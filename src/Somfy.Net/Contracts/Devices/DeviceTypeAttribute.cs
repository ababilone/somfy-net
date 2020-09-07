using System;

namespace Somfy.Net.Contracts.Devices
{
  public class DeviceTypeAttribute : Attribute
  {
    public DeviceTypeAttribute(string type)
    {
      Type = type;
    }

    public string Type { get; }
  }
}
