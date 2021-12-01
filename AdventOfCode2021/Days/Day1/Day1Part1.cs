using CommonCode;

namespace AdventOfCode2021.Days
{
    internal class Day1Part1 : Day1
    {
        internal override void Execute()
        {
            var depthArray = FileReaders.ReadDataFileAsIntArray(@"D:\Projektai\AdventOfCode2021\AdventOfCode2021\Days\Day1\Part1Data.txt");
            var timesDepthIncreased = Calculate(depthArray, 1);
            Console.WriteLine($"Times depth increased: {timesDepthIncreased}");
        }
    }
}
