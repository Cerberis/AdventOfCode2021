using AdventOfCode2021.Models;

namespace AdventOfCode2021.Days
{
    internal abstract class Day8
    {
        internal List<DigitalClockSource> ParsedData { get; set; }

        internal Day8(string filePath)
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
            ParsedData = new List<DigitalClockSource>();
            var data = File.ReadAllLines(filePath);
            foreach (var dataRow in data)
            {
                var dataSets = dataRow.Split('|');

                ParsedData.Add(new DigitalClockSource
                {
                    NumberSets = dataSets[0].Split(" ").Where(m => !string.IsNullOrWhiteSpace(m)).ToList(),
                    ExpectedResults = dataSets[1].Split(" ").Where(m => !string.IsNullOrWhiteSpace(m)).ToList()
                });
            }
        }
    }
}