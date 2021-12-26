namespace AdventOfCode2021.Days
{
    internal class Day11Part1 : Day11
    {
        internal Day11Part1(string filePath) : base(filePath)
        {
        }

        const int StepsToRun = 100;

        protected override int Calculate()
        {
            for (int step = 0; step < StepsToRun; step++)
            {
                bool firstRun = true;
                PrintMatrix(step);
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
            }
            PrintMatrix(StepsToRun);
            return TimesFlashed;
        }
    }
}