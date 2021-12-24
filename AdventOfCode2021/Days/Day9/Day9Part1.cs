namespace AdventOfCode2021.Days
{
    internal class Day9Part1 : Day9
    {
        internal Day9Part1(string filePath) : base(filePath)
        {
        }

        protected override int Calculate()
        {
            var result = 0;
            for (int rowIndex = 0; rowIndex < ParsedData.Count; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < ParsedData[rowIndex].Count; columnIndex++)
                {
                    var currentValue = ParsedData[rowIndex][columnIndex];
                    //top left corner
                    if (rowIndex == 0 && columnIndex == 0)
                    {

                        if (ParsedData[rowIndex][columnIndex + 1] > currentValue        //CheckRight
                            && ParsedData[rowIndex + 1][columnIndex] > currentValue)    //CheckBottom
                            result += currentValue + 1;
                    }
                    //top right corner
                    else if (rowIndex == 0 && columnIndex == ParsedData[rowIndex].Count - 1)
                    {
                        if (ParsedData[rowIndex][columnIndex - 1] > currentValue        //CheckLeft
                           && ParsedData[rowIndex + 1][columnIndex] > currentValue)     //CheckBottom
                            result += currentValue + 1;
                    }
                    //bottom left corner
                    else if (rowIndex == ParsedData.Count - 1 && columnIndex == 0)
                    {
                        if (ParsedData[rowIndex][columnIndex + 1] > currentValue        //CheckRight
                          && ParsedData[rowIndex - 1][columnIndex] > currentValue)      //CheckTop
                            result += currentValue + 1;
                    }
                    //bottom right corner
                    else if (rowIndex == ParsedData.Count - 1 && columnIndex == ParsedData[rowIndex].Count - 1)
                    {
                        if (ParsedData[rowIndex][columnIndex - 1] > currentValue        //CheckLeft
                          && ParsedData[rowIndex - 1][columnIndex] > currentValue)      //CheckTop
                            result += currentValue + 1;
                    }
                    //top row
                    else if (rowIndex == 0)
                    {
                        if (ParsedData[rowIndex][columnIndex - 1] > currentValue        //CheckLeft
                         && ParsedData[rowIndex + 1][columnIndex] > currentValue        //CheckBottom
                         && ParsedData[rowIndex][columnIndex + 1] > currentValue)       //CheckRight
                            result += currentValue + 1;
                    }
                    //right column
                    else if (columnIndex == ParsedData[rowIndex].Count - 1)
                    {
                        if (ParsedData[rowIndex][columnIndex - 1] > currentValue        //CheckLeft
                         && ParsedData[rowIndex + 1][columnIndex] > currentValue        //CheckBottom
                         && ParsedData[rowIndex - 1][columnIndex] > currentValue)       //CheckTop
                            result += currentValue + 1;
                    }
                    //bottom row
                    else if (rowIndex == ParsedData.Count - 1)
                    {
                        if (ParsedData[rowIndex][columnIndex - 1] > currentValue        //CheckLeft
                      && ParsedData[rowIndex][columnIndex + 1] > currentValue           //CheckRight
                      && ParsedData[rowIndex - 1][columnIndex] > currentValue)          //CheckTop
                            result += currentValue + 1;
                    }
                    //left column
                    else if (columnIndex == 0)
                    {
                        if (ParsedData[rowIndex + 1][columnIndex] > currentValue        //CheckBottom
                        && ParsedData[rowIndex][columnIndex + 1] > currentValue         //CheckRight
                        && ParsedData[rowIndex - 1][columnIndex] > currentValue)        //CheckTop
                            result += currentValue + 1;
                    }
                    //all others
                    else
                    {
                        if (ParsedData[rowIndex][columnIndex - 1] > currentValue        //CheckLeft
                       && ParsedData[rowIndex][columnIndex + 1] > currentValue          //CheckRight
                       && ParsedData[rowIndex - 1][columnIndex] > currentValue          //CheckTop
                       && ParsedData[rowIndex + 1][columnIndex] > currentValue)         //CheckBottom
                            result += currentValue + 1;
                    }
                }
            }
            return result;
        }
    }
}
