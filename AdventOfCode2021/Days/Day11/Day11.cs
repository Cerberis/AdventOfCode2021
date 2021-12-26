using AdventOfCode2021.Models;
using CommonCode;

namespace AdventOfCode2021.Days
{
    internal abstract class Day11
    {
        protected List<List<int>> ParsedData { get; set; }
        protected readonly List<OctopusLight> OctopusFlashes = new();
        protected const int MaximumEnergyCapacity = 10;
        protected int TimesFlashed = 0;
        internal Day11(string filePath)
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
            ParsedData = FileReaders.ReadDataFileAsIntMatrix(filePath);
        }

        protected void PrintMatrix(int step)
        {
            Console.WriteLine($"After step: {step}");

            foreach (var light in ParsedData)
            {
                Console.WriteLine(string.Join("", light));
            }
            Console.WriteLine();
        }


        protected void ResetFlashedOctopusEnergy()
        {
            for (int rowIndex = 0; rowIndex < ParsedData.Count; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < ParsedData[rowIndex].Count; columnIndex++)
                {
                    if (ParsedData[rowIndex][columnIndex] >= MaximumEnergyCapacity)
                        ParsedData[rowIndex][columnIndex] = 0;
                }
            }
        }

        protected void TriggerLights(int rowIndex, int columnIndex)
        {
            //top left corner
            if (rowIndex == 0 && columnIndex == 0)
            {
                AddLightTrigger(rowIndex, columnIndex + 1); //right
                AddLightTrigger(rowIndex + 1, columnIndex + 1); //bottom right
                AddLightTrigger(rowIndex + 1, columnIndex);//bottom

            }
            //top right corner
            else if (rowIndex == 0 && columnIndex == ParsedData[rowIndex].Count - 1)
            {
                AddLightTrigger(rowIndex + 1, columnIndex);//bottom
                AddLightTrigger(rowIndex + 1, columnIndex - 1); //bottom left
                AddLightTrigger(rowIndex, columnIndex - 1); //left
            }
            //bottom left corner
            else if (rowIndex == ParsedData.Count - 1 && columnIndex == 0)
            {
                AddLightTrigger(rowIndex - 1, columnIndex);//top
                AddLightTrigger(rowIndex - 1, columnIndex + 1); //top right
                AddLightTrigger(rowIndex, columnIndex + 1); //right
            }
            //bottom right corner
            else if (rowIndex == ParsedData.Count - 1 && columnIndex == ParsedData[rowIndex].Count - 1)
            {
                AddLightTrigger(rowIndex, columnIndex - 1); //left
                AddLightTrigger(rowIndex - 1, columnIndex - 1); //top left
                AddLightTrigger(rowIndex - 1, columnIndex);//top
            }
            //top row
            else if (rowIndex == 0)
            {
                AddLightTrigger(rowIndex, columnIndex + 1); //right
                AddLightTrigger(rowIndex + 1, columnIndex + 1); //bottom right
                AddLightTrigger(rowIndex + 1, columnIndex);//bottom
                AddLightTrigger(rowIndex + 1, columnIndex - 1); //bottom left
                AddLightTrigger(rowIndex, columnIndex - 1); //left
            }
            //right column
            else if (columnIndex == ParsedData[rowIndex].Count - 1)
            {
                AddLightTrigger(rowIndex + 1, columnIndex);//bottom
                AddLightTrigger(rowIndex + 1, columnIndex - 1); //bottom left
                AddLightTrigger(rowIndex, columnIndex - 1); //left
                AddLightTrigger(rowIndex - 1, columnIndex - 1); //top left
                AddLightTrigger(rowIndex - 1, columnIndex);//top
            }
            //bottom row
            else if (rowIndex == ParsedData.Count - 1)
            {
                AddLightTrigger(rowIndex, columnIndex - 1); //left
                AddLightTrigger(rowIndex - 1, columnIndex - 1); //top left
                AddLightTrigger(rowIndex - 1, columnIndex);//top
                AddLightTrigger(rowIndex - 1, columnIndex + 1); //top right
                AddLightTrigger(rowIndex, columnIndex + 1); //right
            }
            //left column
            else if (columnIndex == 0)
            {
                AddLightTrigger(rowIndex - 1, columnIndex);//top
                AddLightTrigger(rowIndex - 1, columnIndex + 1); //top right
                AddLightTrigger(rowIndex, columnIndex + 1); //right
                AddLightTrigger(rowIndex + 1, columnIndex + 1); //bottom right
                AddLightTrigger(rowIndex + 1, columnIndex);//bottom
            }
            //all others
            else
            {
                AddLightTrigger(rowIndex - 1, columnIndex);//top
                AddLightTrigger(rowIndex - 1, columnIndex + 1); //top right
                AddLightTrigger(rowIndex, columnIndex + 1); //right
                AddLightTrigger(rowIndex + 1, columnIndex + 1); //bottom right
                AddLightTrigger(rowIndex + 1, columnIndex);//bottom
                AddLightTrigger(rowIndex + 1, columnIndex - 1); //bottom left
                AddLightTrigger(rowIndex, columnIndex - 1); //left
                AddLightTrigger(rowIndex - 1, columnIndex - 1); //top left
            }

            AddLightTrigger(rowIndex, columnIndex); //current octopus
        }

        void AddLightTrigger(int rowIndex, int columnIndex)
        {
            if (OctopusFlashes.Where(m => m.RowIndex == rowIndex && m.ColumnIndex == columnIndex).Any())
            {
                OctopusFlashes.First(m => m.RowIndex == rowIndex && m.ColumnIndex == columnIndex).TimesAdjacentoctopusFLashed++;
            }
            else
            {
                OctopusFlashes.Add(new OctopusLight
                {
                    ColumnIndex = columnIndex,
                    RowIndex = rowIndex,
                    TimesAdjacentoctopusFLashed = 1
                });
            }
        }

        protected void CheckOctopusFlashes()
        {
            if (!OctopusFlashes.Any()) return;
            var oldOctopusFlashes = OctopusFlashes.ToList();
            OctopusFlashes.Clear();
            foreach (var octopusFlash in oldOctopusFlashes)
            {
                if (ParsedData[octopusFlash.RowIndex][octopusFlash.ColumnIndex] < MaximumEnergyCapacity && ParsedData[octopusFlash.RowIndex][octopusFlash.ColumnIndex] + octopusFlash.TimesAdjacentoctopusFLashed >= MaximumEnergyCapacity)
                {
                    TriggerLights(octopusFlash.RowIndex, octopusFlash.ColumnIndex);
                    TimesFlashed++;
                }
                ParsedData[octopusFlash.RowIndex][octopusFlash.ColumnIndex] = ParsedData[octopusFlash.RowIndex][octopusFlash.ColumnIndex] + octopusFlash.TimesAdjacentoctopusFLashed;
            }
            CheckOctopusFlashes();
        }
    }
}