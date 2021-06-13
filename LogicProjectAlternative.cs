using System;
using System.Text;
using Claunia.PropertyList;
using logic_exporter.PropertyLists;

namespace logic_exporter
{
  public record LogicProjectAlternative
  (
    LogicProject Project,
    string Name
  )
  {
    private Lazy<Metadata> LazyMeta => new(() => new PropertyList(GetPath("Metadata.plist")).As<Metadata>());
    private string GetPath(string relativePath) =>
       $"{Project.Path}/Alternatives/{Name}/{relativePath}";

    public Metadata Metadata => LazyMeta.Value;

    private bool TryGetNextPropertyList(string content, out (NSDictionary PropertyList, string Remainder) result)
    {
      var start = content.IndexOf("<plist");
      var end = content.IndexOf("</plist>");

      if (start >= 0 && end > 0)
      {
        end += 8;
        var xml = content[start..end];
        var plist = (NSDictionary)PropertyListParser.Parse(Encoding.UTF8.GetBytes(xml));
        var remainder = content[(end + 1)..];

        result = (plist, remainder);
        return true;
      }

      result = default;
      return false;
    }
  }
}