using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2021.Days
{
    internal abstract class Day3
    {
        internal List<string> ParsedData { get; }

        internal Day3(string filePath)
        {
            ParsedData = ReadFile(filePath);
        }

        internal void Execute()
        {
            var result = Calculate();

            Console.WriteLine($"Result: {result}");
        }

        internal abstract int Calculate();

        internal List<string> ReadFile(string filePath)
        {
            return File.ReadAllLines(filePath).ToList();
        }
    }
}
