using System;
using System.Collections.Generic;
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
      return ((NSArray)item).Select(x => x.ToString());
    }
  }
}