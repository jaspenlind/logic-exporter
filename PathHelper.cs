using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace logic_exporter
{
  public class PathHelper
  {
    public string Path { get; private set; }
    public string Alternative { get; private set; }

    public PathHelper(string projectFilePath, string alternative = "000")
    {
      Path = projectFilePath;
      Alternative = alternative;
    }

    public PathHelper SetPath(string projectFilePath)
    {
      Path = projectFilePath;
      return this;
    }

    public PathHelper SetAlternative(string alternative)
    {
      Alternative = alternative;
      return this;
    }

    public string Metadata =>
      $"{Path}/Alternatives/{Alternative}/Metadata.plist";

    public IEnumerable<string> GetAlternatives() => Directory
      .GetDirectories($"{Path}/Alternatives")
      .Select(x => new DirectoryInfo(x).Name);
  }
}