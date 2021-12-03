using CommonCode;

namespace AdventOfCode2021.Days
{
    internal class Day1
    {
        internal int[] ParsedData { get; }
        public int IterationLength { get; }

        internal Day1(string filePath, int iterationLength)
        {
            ParsedData = ReadFile(filePath);
            IterationLength = iterationLength;
        }

        internal string Execute()
        {
            var timesDepthIncreased = Calculate(IterationLength);
            Console.WriteLine($"Times depth increased: {timesDepthIncreased}");
            return timesDepthIncreased.ToString();
        }

        internal int Calculate(int iterationLength)
        {
            int timesDepthIncreased = 0;
            for (int i = 0; i < ParsedData.Length; i++)
            {
                if (ParsedData.Skip(i).Take(iterationLength).Sum() < ParsedData.Skip(i + 1).Take(iterationLength).Sum())
                    timesDepthIncreased++;
            }
            return timesDepthIncreased;
        }

        int[] ReadFile(string filePath)
        {
            return FileReaders.ReadDataFileAsIntArray(filePath);
        }
    }
}
