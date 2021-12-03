namespace AdventOfCode2021.Days
{
    internal abstract class Day3
    {
        internal List<string> ParsedData { get; }

        internal Day3(string filePath)
        {
            ParsedData = ReadFile(filePath);
        }

        internal string Execute()
        {
            var result = Calculate();

            Console.WriteLine($"Result: {result}");
            return result.ToString();
        }

        internal abstract int Calculate();

        internal List<string> ReadFile(string filePath)
        {
            return File.ReadAllLines(filePath).ToList();
        }
    }
}
