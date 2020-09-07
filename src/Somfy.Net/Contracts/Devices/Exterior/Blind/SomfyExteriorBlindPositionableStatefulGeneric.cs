namespace Somfy.Net.Contracts.Devices.Exterior.Blind
{
  [DeviceType("exterior_blind_positionable_stateful_generic")]
  public class SomfyExteriorBlindPositionableStatefulGeneric : Device
  {
    public int Position => GetState<int>("position");
  }
}