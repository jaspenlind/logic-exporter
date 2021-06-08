using System;

namespace logic_exporter
{
  public static class MetadataWriter
  {
    public static void Write(Metadata metadata)
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