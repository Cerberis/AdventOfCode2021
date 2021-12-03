using CommonCode.Extensions;

namespace AdventOfCode2021.Days
{
    internal class Day2Part1
    {
        private Dictionary<string, List<int>> ParsedData { get; }
        internal Day2Part1(string filePath)
        {
            ParsedData = ReadDataIntoModel(filePath);
        }

        internal string Execute()
        {
            var horizontalPosition = ParsedData["forward"].Sum();
            var depth = ParsedData["down"].Sum() - ParsedData["up"].Sum();

            Console.WriteLine($"Horizontal position: {horizontalPosition}, Depth: {depth}");
            Console.WriteLine($"Result: {horizontalPosition * depth}");
            return (horizontalPosition * depth).ToString();
        }

        internal int Calculate(int[] intArray, int iterationLength)
        {
            int timesDepthIncreased = 0;
            for (int i = 0; i < intArray.Length; i++)
            {
                if (intArray.Skip(i).Take(iterationLength).Sum() < intArray.Skip(i + 1).Take(iterationLength).Sum())
                    timesDepthIncreased++;
            }
            return timesDepthIncreased;
        }


        internal Dictionary<string, List<int>> ReadDataIntoModel(string filePath)
        {
            var result = new Dictionary<string, List<int>>();
            var stringRows = File.ReadAllLines(filePath).ToList();
            foreach (var stringRow in stringRows)
            {
                var words = stringRow.Split(' ');
                if (result.ContainsKey(words[0]))
                {
                    result[words[0]].Add(words[1].ToInt());
                }
                else
                {
                    result.Add(words[0], new List<int> { words[1].ToInt() });
                }
            }
            return result;
        }
    }
}
