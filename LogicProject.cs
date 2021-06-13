using System;
using System.Collections.Generic;
using System.Linq;
using logic_exporter.PropertyLists;

namespace logic_exporter
{
  public partial class LogicProject
  {
    private readonly Dictionary<string, LogicProjectAlternative> alternatives;
    private Lazy<ProjectInfo> LazyProjectInfo =>
     new(() => new PropertyList($"{Path}/Resources/ProjectInformation.plist").As<ProjectInfo>());

    public string Path { get; init; }
    public LogicProject(string path, string selectedAlternative = "000")
    {
      Path = path;

      alternatives = new PathHelper(path)
        .GetAlternatives()
        .ToDictionary(x => x, x => new LogicProjectAlternative(this, x));

      Alternative = alternatives[selectedAlternative];
    }
    public ProjectInfo ProjectInfo => LazyProjectInfo.Value;

    public LogicProjectAlternative Alternative { get; private set; }

    public void SetAlternative(string name)
    {
      if (!alternatives.TryGetValue(name, out var alternative))
      {
        throw new ArgumentException("Not a valid alternative", nameof(name));
      }

      Alternative = alternative;
    }

    public IEnumerable<LogicProjectAlternative> Alternatives => alternatives.Values;
  }
}