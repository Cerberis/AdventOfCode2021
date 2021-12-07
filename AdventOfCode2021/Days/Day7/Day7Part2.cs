namespace AdventOfCode2021.Days
{
    internal class Day7Part2 : Day7
    {
        internal Day7Part2(string filePath) : base(filePath)
        {

        }

        protected override int CalculatePositionsFuelConsumption(int currentPosition)
        {
            var fuelConsumed = 0;
            foreach (var position in CrabPositions)
            {
               var positionDifference = GetPositionDifference(currentPosition, position);
                for (int stepsMoved = 0; stepsMoved < positionDifference; stepsMoved++)
                {
                    fuelConsumed += stepsMoved +1;
                }
            }
            return fuelConsumed;
        }
    }
}
