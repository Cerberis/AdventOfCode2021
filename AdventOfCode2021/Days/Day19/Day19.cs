using CommonCode;

namespace AdventOfCode2021.Days
{
    internal abstract class Day19
    {
        internal List<List<int>> ParsedData { get; set; }

        internal Day19(string filePath)
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
            ParsedData = FileReaders.ReadDataFileAsIntMatrix(filePath);
        }
    }
}