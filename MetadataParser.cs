using System;
using System.IO;
using Claunia.PropertyList;

namespace logic_exporter
{
  public static class MetadataParser
  {
    public static Metadata Parse(string logicFilePath)
    {
      var file = new FileInfo($"{logicFilePath}/Alternatives/000/Metadata.plist");
      var root = (NSDictionary)PropertyListParser.Parse(file);

      foreach (var (key, value) in root)
      {
        Console.WriteLine($"{key} = {value}");
      }

      return new Metadata
      (
        root["HasGrid"].GetBool(),
        root["SamplerInstrumentsFiles"].GetStrings(),
        root["QuicksamplerFiles"].GetStrings(),
        root["isTimeCodeBased"].GetBool(),
        root["SongKey"].ToString(),
        root["NumberOfTracks"].GetInt()
      );
    }
  }
}