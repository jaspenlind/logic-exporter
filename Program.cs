using System;
using System.IO;
using Claunia.PropertyList;

namespace logic_exporter
{
  class Program
  {
    static void Main(string[] args)
    {
      if (args.Length < 2)
      {
        Console.WriteLine(@"Usage: [options]

Options:
  -f            Path to Logic project file    
    ");
        return;
      }
      var path = args[1];
      var file = new FileInfo($"{path}/Alternatives/000/Metadata.plist");
      var root = (NSDictionary)PropertyListParser.Parse(file);

      foreach (var (key, value) in root)
      {

        Console.WriteLine($"{key} = {value}");
      }

      var metadata = new Metadata
      (
        root["HasGrid"].GetBool(),
        root["SamplerInstrumentsFiles"].GetStrings(),
        root["QuicksamplerFiles"].GetStrings(),
        root["isTimeCodeBased"].GetBool(),
        root["SongKey"].ToString(),
        root["NumberOfTracks"].GetInt()
      );
      Write(metadata);
    }

    private static void Write(Metadata metadata)
    {
      var (hasGrid, files, quicksamplerFiles, isTimeCodeBased, songKey, _) = metadata;

      var msg = $@"
    {nameof(hasGrid)}={hasGrid}
    {nameof(files)}={string.Join("\n\t", files)}
    {nameof(quicksamplerFiles)}={string.Join("\n\t", quicksamplerFiles)}
    {nameof(isTimeCodeBased)}={isTimeCodeBased}
    {nameof(songKey)}={songKey}
    ";

      Console.WriteLine(msg);
    }
  }
}
