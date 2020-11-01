using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using Somfy.Net.Contracts.Devices;

namespace Somfy.Net
{
  public class DeviceJsonConverter : JsonConverter<Device>
  {
    private static readonly Type DeviceType = typeof(Device);
    private static readonly Dictionary<string, Type> TypeMapping = CreateMapping();

    private static Dictionary<string, Type> CreateMapping()
    {
      var mapping = new Dictionary<string, Type>();
      foreach (var type in DeviceType.Assembly.GetTypes())
      {
        if (!DeviceType.IsAssignableFrom(type))
          continue;

        var deviceTypeAttribute = type.GetCustomAttribute<DeviceTypeAttribute>();
        if (deviceTypeAttribute != null)
          mapping.Add(deviceTypeAttribute.Type, type);
      }
      return mapping;
    }

    public override bool CanConvert(Type typeToConvert) => typeof(Device) == typeToConvert;

    public override Device Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
      if (reader.TokenType == JsonTokenType.Null)
        return null;

      var readerAtStart = reader;

      using var jsonDocument = JsonDocument.ParseValue(ref reader);
      var jsonObject = jsonDocument.RootElement;
      
      if (jsonObject.TryGetProperty("type", out var typeElement))
      {
        var typeName = typeElement.GetString();
        if (TypeMapping.TryGetValue(typeName, out var type))
          return JsonSerializer.Deserialize(ref readerAtStart, type, options) as Device;
      }

      return null;
    }

    public override void Write(Utf8JsonWriter writer, Device value, JsonSerializerOptions options) => JsonSerializer.Serialize(writer, value, value.GetType(), options);
  }
}
