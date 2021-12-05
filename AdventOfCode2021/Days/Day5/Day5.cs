using AdventOfCode2021.Models;
using CommonCode.Extensions;

namespace AdventOfCode2021.Days
{
    internal abstract class Day5
    {
        internal List<Coordinates> CoordinateList { get; }
        internal int RowLength { get; set; }
        internal int ColumnLength { get; set; }
        internal List<Coordinate> FloorDiagram { get; set; }

        internal Day5(string filePath)
        {
            CoordinateList = ReadCoordinates(filePath);
            GetMaxRowLength();
            GetMaxColumnLength();
            FloorDiagram = DrawEmptyDiagram();
        }

        private void GetMaxRowLength()
        {
            var startingMaxValue = CoordinateList.Max(m => m.EndingPosition.RowIndex);
            var endingMaxValue = CoordinateList.Max(m => m.StartingPosition.RowIndex);
            RowLength = startingMaxValue > endingMaxValue ? startingMaxValue : endingMaxValue;
        }

        private void GetMaxColumnLength()
        {
            var startingMaxValue = CoordinateList.Max(m => m.EndingPosition.ColumnIndex);
            var endingMaxValue = CoordinateList.Max(m => m.StartingPosition.ColumnIndex);
            ColumnLength = startingMaxValue > endingMaxValue ? startingMaxValue : endingMaxValue;
        }

        private List<Coordinate> DrawEmptyDiagram()
        {
            List<Coordinate> result = new List<Coordinate>();
            for (int rowIndex = 0; rowIndex <= RowLength; rowIndex++)
            {
                for (int colIndex = 0; colIndex <= ColumnLength; colIndex++)
                {
                    result.Add(new Coordinate
                    {
                        RowIndex = rowIndex,
                        ColumnIndex = colIndex,
                        Value = 0
                    });
                }
            }
            return result;
        }

        internal string Execute()
        {
            var result = Calculate();

            Console.WriteLine($"Times overlapped: {result}");
            return result.ToString();
        }

        internal abstract int Calculate();

        internal List<Coordinates> ReadCoordinates(string filePath)
        {
            var dataRows = File.ReadAllLines(filePath);
            var result = new List<Coordinates>();

            foreach (var dataRow in dataRows)
            {
                var coordinates = dataRow.Split("->");

                var startingPosition = coordinates[0].Split(',');
                var endingPosition = coordinates[1].Split(',');

                result.Add(
                    new Coordinates
                    {
                        StartingPosition = new Coordinate
                        {
                            ColumnIndex = startingPosition[0].ToInt(),
                            RowIndex = startingPosition[1].ToInt()
                        },
                        EndingPosition = new Coordinate
                        {
                            ColumnIndex = endingPosition[0].ToInt(),
                            RowIndex = endingPosition[1].ToInt()
                        }
                    });
            }
            return result;
        }

        internal abstract void MarkDiagram();

        protected static (int startingPoint, int difference) GetDifferenceInPoints(int startingPointIndex, int endingPointIndex)
        {
            if (endingPointIndex > startingPointIndex)
            {
                return (startingPointIndex, endingPointIndex - startingPointIndex + 1);
            }
            else
            {
                return (endingPointIndex, startingPointIndex - endingPointIndex + 1);
            }
        }

        protected static (int startingPoint, int difference, bool reversedOrder) GetDiagonalDifferenceInPoints(int startingPointIndex, int endingPointIndex)
        {
            if (endingPointIndex > startingPointIndex)
            {
                return (startingPointIndex, endingPointIndex - startingPointIndex + 1, false);
            }
            else
            {
                return (startingPointIndex, startingPointIndex - endingPointIndex + 1, true);
            }
        }


        protected void DrawDiagram()
        {
            for (int rowIndex = 0; rowIndex <= RowLength; rowIndex++)
            {
                Console.WriteLine(string.Join(",", FloorDiagram.Where(m => m.RowIndex == rowIndex).Select(m => m.Value)));
            }
        }

        protected void MarkVerticalDiagram()
        {
            foreach (var coordinate in CoordinateList.Where(m => m.StartingPosition.ColumnIndex == m.EndingPosition.ColumnIndex))
            {
                var startingPoint = GetDifferenceInPoints(coordinate.StartingPosition.RowIndex, coordinate.EndingPosition.RowIndex);
                FloorDiagram.Where(m => m.ColumnIndex == coordinate.StartingPosition.ColumnIndex && m.RowIndex >= startingPoint.startingPoint)
                    .Take(startingPoint.difference).ToList().ForEach(m => m.Value++);
            }
        }
        protected void MarkHorizontalDiagram()
        {
            foreach (var coordinate in CoordinateList.Where(m => m.StartingPosition.RowIndex == m.EndingPosition.RowIndex))
            {
                var startingPoint = GetDifferenceInPoints(coordinate.StartingPosition.ColumnIndex, coordinate.EndingPosition.ColumnIndex);
                FloorDiagram.Where(m => m.RowIndex == coordinate.StartingPosition.RowIndex && m.ColumnIndex >= startingPoint.startingPoint)
                    .Take(startingPoint.difference).ToList().ForEach(m => m.Value++);
            }
        }

        protected void MarkDiagonalDiagram()
        {
            List<Coordinate> coordinatesCalculated = new List<Coordinate>();
            foreach (var coordinate in CoordinateList.Where(m => m.StartingPosition.RowIndex != m.EndingPosition.RowIndex && m.StartingPosition.ColumnIndex != m.EndingPosition.ColumnIndex))
            {
                coordinatesCalculated.AddRange(CalculateDiagonalCoordinates(coordinate));
            }

             (from diagram in FloorDiagram
              join coordCalcs in coordinatesCalculated
              on new { diagram.ColumnIndex, diagram.RowIndex } equals new { coordCalcs.ColumnIndex, coordCalcs.RowIndex }
              select diagram).ToList().ForEach(m => m.Value++);
        }

        private List<Coordinate> CalculateDiagonalCoordinates(Coordinates coordinate)
        {
            List<Coordinate> pointsToMark = new List<Coordinate>();
            var columnCalculations = GetDiagonalDifferenceInPoints(coordinate.StartingPosition.ColumnIndex, coordinate.EndingPosition.ColumnIndex);
            var rowCalculations = GetDiagonalDifferenceInPoints(coordinate.StartingPosition.RowIndex, coordinate.EndingPosition.RowIndex);
            if (columnCalculations.difference != rowCalculations.difference)
            {
                Console.WriteLine($"Bad coordinates. Starting point ({coordinate.StartingPosition.ColumnIndex},{coordinate.StartingPosition.RowIndex}), endining point ({coordinate.EndingPosition.ColumnIndex},{coordinate.EndingPosition.RowIndex})");
            }
            for (int i = 0; i < columnCalculations.difference; i++)
            {
                if (rowCalculations.reversedOrder && columnCalculations.reversedOrder)
                {
                    pointsToMark.Add(new Coordinate { ColumnIndex = columnCalculations.startingPoint - i, RowIndex = rowCalculations.startingPoint - i });
                }
                else if (columnCalculations.reversedOrder)
                {
                    pointsToMark.Add(new Coordinate { ColumnIndex = columnCalculations.startingPoint - i, RowIndex = rowCalculations.startingPoint + i });
                }
                else if (rowCalculations.reversedOrder)
                {
                    pointsToMark.Add(new Coordinate { ColumnIndex = columnCalculations.startingPoint + i, RowIndex = rowCalculations.startingPoint - i });
                }
                else
                {
                    pointsToMark.Add(new Coordinate { ColumnIndex = columnCalculations.startingPoint + i, RowIndex = rowCalculations.startingPoint + i });
                }
            }
            return pointsToMark;
        }
    }
}