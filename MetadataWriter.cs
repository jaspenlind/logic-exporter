using System;
using System.Text.Json;
namespace logic_exporter
{
  public static class MetadataWriter
  {
    public static void Write(Metadata metadata)
    {
      var json = JsonSerializer.Serialize(metadata, new JsonSerializerOptions
      {
        WriteIndented = true
      });

      Console.WriteLine(json);
    }
  }
}