using CommonCode;

namespace AdventOfCode2021.Days
{
    internal abstract class Day10
    {
        internal List<string> ParsedData { get; set; }

        internal Day10(string filePath)
        {
            ParseData(filePath);
        }

        internal string Execute()
        {
            var result = Calculate();

            Console.WriteLine($"Result: {result}");
            return result.ToString();
        }

        protected abstract int Calculate();

        void ParseData(string filePath)
        {
            ParsedData = File.ReadAllLines(filePath).ToList();
        }
    }
}