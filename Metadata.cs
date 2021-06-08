using System.Collections.Generic;

namespace logic_exporter
{
  public record Metadata
  (
    bool HasGrid,
    IEnumerable<string> Files,
    IEnumerable<string> QuicksamplerFiles,
    bool IsTimeCodeBased,
    string SongKey,
    int NumberOfTracks
  );
}