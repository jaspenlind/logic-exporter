using System.Collections.Generic;

namespace logic_exporter
{
  public record ProjectInfo
  (
    bool HasProjectFolder,
    IEnumerable<string> VariantNames,
    IEnumerable<string> VariantNamesV2,
    string LastSavedFrom,
    int BundleVersion,
    int ProjectAssetFlags,
    int ActiveVariant
  );
}