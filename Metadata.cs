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
    int NumberOfTracks,
    IEnumerable<string> PlaybackFiles,
    bool HasARAPlugins,
    int SampleRate,
    IEnumerable<string> UnusedAudioFiles,
    string SongGenderKey,
    IEnumerable<string> ImpulsResponsesFiles,
    int FrameRateIndex,
    int SongSignatureNumerator,
    int BeatsPerMinute,
    int SignatureKey,
    int Version,
    int SongSignatureDenominator,
    int SurroundFormatIndex,
    IEnumerable<string> UltrabeatFiles
  );
}