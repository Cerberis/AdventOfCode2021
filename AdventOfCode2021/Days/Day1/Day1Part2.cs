using CommonCode;

namespace AdventOfCode2021.Days
{
    internal class Day1Part2 : Day1
    {
        internal override void Execute()
        {
            var depthArray = FileReaders.ReadDataFileAsIntArray(@"D:\Projektai\AdventOfCode2021\AdventOfCode2021\Days\Day1\Part2Data.txt");
            var timesDepthIncreased = Calculate(depthArray, 3);
            Console.WriteLine($"Times depth increased: {timesDepthIncreased}");
        }
    }
}
