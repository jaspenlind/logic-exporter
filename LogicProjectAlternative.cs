using System;

namespace logic_exporter
{
  public record LogicProjectAlternative
  (
    LogicProject Project,
    string Name
  )
  {
    private Lazy<Metadata> LazyMeta => new(() => MetadataParser.Parse(GetPath("Metadata.plist")));
    private string GetPath(string relativePath) =>
       $"{Project.Path}/Alternatives/{Name}/{relativePath}";

    public Metadata Metadata => LazyMeta.Value;
  }
}