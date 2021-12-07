using CommonCode.Extensions;

namespace AdventOfCode2021.Days
{
    internal abstract class Day7
    {
        internal List<int> CrabPositions { get; set; }

        internal Day7(string filePath)
        {
            GetCrabPositions(filePath);
        }

        internal string Execute()
        {
            var result = Calculate();

            Console.WriteLine($"Result: {result}");
            return result.ToString();
        }

        protected abstract int CalculatePositionsFuelConsumption(int currentPosition);
        internal long Calculate()
        {
            var maxPosition = CrabPositions.Max();
            var minPosition = CrabPositions.Min();
            var fuelConsumption = new Dictionary<int, int>();
            for (var currentPosition = minPosition; currentPosition < maxPosition; currentPosition++)
            {
                fuelConsumption.Add(currentPosition, CalculatePositionsFuelConsumption(currentPosition));
            }
            return fuelConsumption.Values.Min();
        }

        void GetCrabPositions(string filePath)
        {
            CrabPositions = File.ReadAllLines(filePath).First().Split(',').Where(m => !string.IsNullOrEmpty(m)).Select(m => m.ToInt()).ToList();           
        }

        protected int GetPositionDifference(int currentPosition, int position)
        {
            return currentPosition > position ? currentPosition - position : position - currentPosition;
        }
    }
}