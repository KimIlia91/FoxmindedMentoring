using System.Globalization;

namespace MaximumSumOfElements
{
    public class Program
    {
        private static string _seachPath;

        static void Main(string[] args)
        {
            var key = new ConsoleKeyInfo();
            while (key.Key != ConsoleKey.Escape)
            {
                FilePath(args);
                var rowSeach = new RowSeach(_seachPath);
                Console.WriteLine(rowSeach.MaxSum.HasValue ? $"\nMaximum sum of elements: {rowSeach.MaxSum.Value:F2}" : rowSeach.MaxSum);
                foreach (var maxRow in rowSeach.MaxRow)
                    Console.WriteLine($"\nLine with maximum sum of elements: {maxRow}");
                foreach (var brokenRow in rowSeach.BrokenRows)
                    Console.WriteLine($"\nLine contains non-numeric elements: {brokenRow}");
                Console.WriteLine("\nPress \"Enter\" to continue or press \"Escape\" to exit.");
                key = Console.ReadKey();
                Console.Clear();
            }
        }

        private static void FilePath(string[] args)
        {
            _seachPath = string.Empty;
            if (args != null)
            {
                if (args.Length > 0)
                {
                    _seachPath = args[0];
                    Console.WriteLine("Path from command line argument: \"{0}\"", _seachPath);
                }
                else
                    Console.WriteLine("Path missing from command line argument!\n");
            }
            if (string.IsNullOrEmpty(_seachPath))
            {
                Console.Write("Input path: ");
                _seachPath = Console.ReadLine();
            }
        }
    }
}