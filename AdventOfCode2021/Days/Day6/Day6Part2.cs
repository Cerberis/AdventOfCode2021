namespace AdventOfCode2021.Days
{
    internal class Day6Part2 : Day6
    {
        internal Day6Part2(string filePath) : base(filePath)
        {

        }

        internal override long Calculate()
        {
            const int days = 256;
            for (int day = 0; day < days; day++)
            {
                RemoveDay();
                AddNewFishes();
                ResfreshFishCycle();
                // WriteFishToConsole();
            }
            return GroupedFishes.Sum(m => m.Value);
        }
    }
}
