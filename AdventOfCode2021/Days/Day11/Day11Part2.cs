namespace AdventOfCode2021.Days
{
    internal class Day11Part2 : Day11
    {
        internal Day11Part2(string filePath) : base(filePath)
        {
        }

        protected override int Calculate()
        {
            int step = 0;
            while(TimesFlashed != 100)
            {
                TimesFlashed = 0;
                bool firstRun = true;
                while (OctopusFlashes.Any() || firstRun)
                {
                    firstRun = false;
                    for (int rowIndex = 0; rowIndex < ParsedData.Count; rowIndex++)
                    {
                        for (int columnIndex = 0; columnIndex < ParsedData[rowIndex].Count; columnIndex++)
                        {
                            ParsedData[rowIndex][columnIndex] = ParsedData[rowIndex][columnIndex] + 1;
                            if (ParsedData[rowIndex][columnIndex] == MaximumEnergyCapacity)
                            {
                                TriggerLights(rowIndex, columnIndex);
                                TimesFlashed++;
                            }
                        }
                    }
                    CheckOctopusFlashes();
                }
                ResetFlashedOctopusEnergy();
                PrintMatrix(step);
                step++;
            }
            return step;
        }
    }
}
