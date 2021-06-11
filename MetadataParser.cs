namespace logic_exporter
{
  public static class MetadataParser
  {
    public static Metadata Parse(string path)
    {
      var root = path.ParseAsPropertyList();
      return new
      (
        root["HasGrid"].GetBool(),
        root["SamplerInstrumentsFiles"].GetStrings(),
        root["QuicksamplerFiles"].GetStrings(),
        root["isTimeCodeBased"].GetBool(),
        root["SongKey"]?.ToString() ?? "",
        root["NumberOfTracks"].GetInt(),
        root["PlaybackFiles"].GetStrings(),
        root["HasARAPlugins"].GetBool(),
        root["SampleRate"].GetInt(),
        root["UnusedAudioFiles"].GetStrings(),
        root["SongGenderKey"]?.ToString() ?? "",
        root["ImpulsResponsesFiles"].GetStrings(),
        root["FrameRateIndex"].GetInt(),
        root["SongSignatureNumerator"].GetInt(),
        root["BeatsPerMinute"].GetInt(),
        root["SignatureKey"].GetInt(),
        root["Version"].GetInt(),
        root["SongSignatureDenominator"].GetInt(),
        root["SurroundFormatIndex"].GetInt(),
        root["UltrabeatFiles"].GetStrings()
      );
    }
  }
}