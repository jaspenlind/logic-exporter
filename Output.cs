using System;
using System.Text.Json;
namespace logic_exporter
{
  public static class Output
  {
    public static void Write(object data)
    {
      var json = JsonSerializer.Serialize(data, new JsonSerializerOptions
      {
        WriteIndented = true,
        ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve
      });

      Console.WriteLine(json);
    }
  }
}