namespace AdventOfCode2021.Days
{
    internal class Day7Part1 : Day7
    {
        internal Day7Part1(string filePath) : base(filePath)
        {
        }

        protected override int CalculatePositionsFuelConsumption(int currentPosition)
        {
            var fuelConsumed = 0;
            foreach (var position in CrabPositions)
            {
                fuelConsumed += currentPosition > position ? currentPosition - position : position - currentPosition;
            }
            return fuelConsumed;
        }
    }
}
