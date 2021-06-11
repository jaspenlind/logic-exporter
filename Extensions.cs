using System.Collections.Generic;
using System.IO;
using System.Linq;
using Claunia.PropertyList;

namespace logic_exporter
{
  public static class Extensions
  {
    public static int GetInt(this NSObject item)
    {
      return ((NSNumber)item).ToInt();
    }

    public static bool GetBool(this NSObject item)
    {
      return ((NSNumber)item).ToBool();
    }

    public static IEnumerable<string> GetStrings(this NSObject item)
    {
      return ((NSArray)item).Select(x => x?.ToString() ?? "");
    }

    public static NSDictionary ParseAsPropertyList(this string filePath)
    {
      return (NSDictionary)PropertyListParser.Parse(new FileInfo(filePath));
    }

    public static string GetValueOrDefault(this string? str, string @default = "") => str ?? @default;
  }
}