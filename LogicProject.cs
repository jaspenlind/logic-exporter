using System;
using System.Collections.Generic;
using System.Linq;

namespace logic_exporter
{
  public class LogicProject
  {
    private readonly PathHelper path;
    private readonly Dictionary<string, LogicProjectAlternative> alternatives;

    public LogicProject(string path, string selectedAlternative = "000")
    {
      this.path = new PathHelper(path);

      alternatives = this.path
        .GetAlternatives()
        .ToDictionary(x => x, x => CreateAlterative(x));

      Alternative = alternatives[selectedAlternative];
    }

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
    private LogicProjectAlternative CreateAlterative(string name)
    {
      path.SetAlternative(name);

      return new LogicProjectAlternative(this, name, MetadataParser.Parse(path.Metadata));
    }
  }

  public record LogicProjectAlternative
  (
    LogicProject Project,
    string Name,
    Metadata Metadata
  );
}