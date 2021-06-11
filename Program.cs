using System;

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

      var metadata = MetadataParser.Parse(args[1]);

      MetadataWriter.Write(metadata);
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
