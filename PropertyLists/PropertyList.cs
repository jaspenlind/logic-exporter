using System.IO;
using System.Text.Json;
using Claunia.PropertyList;

namespace logic_exporter.PropertyLists
{
  public class PropertyList
  {
    private readonly NSDictionary dictionary;
    public PropertyList(string filePath)
    {
      dictionary = (NSDictionary)PropertyListParser.Parse(new FileInfo(filePath));
    }

    public dynamic AsDynamic() => PropertyListWalker.Walk(dictionary);
    public T As<T>()
    {
      dynamic data = AsDynamic();

      var json = JsonSerializer.Serialize(data);

      return JsonSerializer.Deserialize<T>(json);
    }
  }
}