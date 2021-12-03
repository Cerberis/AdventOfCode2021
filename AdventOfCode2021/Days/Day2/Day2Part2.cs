using CommonCode.Extensions;

namespace AdventOfCode2021.Days
{
    internal class Day2Part2
    {
        private List<KeyValuePair<string, int>> ParsedData { get; }
        internal Day2Part2(string filePath)
        {
            ParsedData = ReadDataIntoModel(filePath);
        }

        internal string Execute()
        {
            var result = Calculate();
            Console.WriteLine($"Horizontal position: {result.horizontalPosition}, Depth: {result.depth}");
            Console.WriteLine($"Result: {result.horizontalPosition * result.depth}");
            return (result.horizontalPosition * result.depth).ToString();
        }

        internal (int horizontalPosition, int depth) Calculate()
        {
            int horizontalPosition = 0;
            int depth = 0;
            int aim = 0;
            foreach (var data in ParsedData)
            {
                switch (data.Key)
                {
                    case "forward":
                        horizontalPosition += data.Value;
                        depth += aim * data.Value;
                        break;
                    case "up":
                        aim -= data.Value;
                        break;
                    case "down":
                        aim += data.Value;
                        break;
                }
            }
            return (horizontalPosition, depth);
        }


        internal List<KeyValuePair<string, int>> ReadDataIntoModel(string filePath)
        {
            var result = new List<KeyValuePair<string, int>>();
            var stringRows = File.ReadAllLines(filePath).ToList();
            foreach (var stringRow in stringRows)
            {
                var words = stringRow.Split(' ');
                result.Add(new KeyValuePair<string, int>(words[0], words[1].ToInt()));
            }
            return result;
        }
    }
}