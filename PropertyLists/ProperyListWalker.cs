using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using Claunia.PropertyList;

namespace logic_exporter.PropertyLists
{
  public static class PropertyListWalker
  {
    public static dynamic Walk(NSDictionary plist)
    {
      var graph = new ExpandoObject();

      foreach (var entry in plist)
      {
        graph.TryAdd(entry.Key, (object)GetValue(entry.Value));
      }

      return graph;
    }

    public static dynamic GetValue(NSObject obj)
    {
      return obj switch
      {

        NSString stringObj => stringObj.Content,
        NSNumber numberObj => numberObj.GetNSNumberType() switch
        {
          NSNumber.BOOLEAN => numberObj.ToBool(),
          NSNumber.REAL => numberObj.ToDouble(),
          _ => numberObj.ToInt()
        },
        NSArray arrayObj => arrayObj.Select(GetValue).ToArray(),
        NSDictionary dictObj => dictObj.Values.Select(GetValue).ToArray(),
        _ => throw new NotSupportedException(obj.GetType().Name + " is not supported")
      };
    }
  }
}