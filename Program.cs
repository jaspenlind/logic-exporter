using System;
using System.Linq;

namespace logic_exporter
{
  internal static class Program
  {
    public static void Main(string[] args)
    {
      if (!IsValid(args))
      {
        Usage();
        return;
      }

      var project = new LogicProject(args[1]);

      Output.Write(project.Alternative.Metadata);
      //Output.Write(project.Alternatives);
    }

    private static bool IsValid(string[] args) => args.Length > 1;

    private static void Usage()
    {
      Console.WriteLine(@"Usage: [options]

Options:
  -f            Path to Logic project file    
    ");
    }
  }
}
