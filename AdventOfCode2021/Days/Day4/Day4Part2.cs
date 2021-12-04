using AdventOfCode2021.Models;

namespace AdventOfCode2021.Days
{
    internal class Day4Part2 : Day4
    {
        internal Day4Part2(string filePath) : base(filePath)
        {

        }

        internal override int Calculate()
        {
            int lastWinningBoardIndex = 0;
            foreach (var drawnNumber in DrawnNumbers)
            {
                CheckForDrawnNumber(drawnNumber);
                CheckIfThereIsWinner();

                if (BingoBoards.Any(m => m.Won == false))
                {
                    lastWinningBoardIndex = BingoBoards.LastOrDefault(m => m.Won == false).BoardIndex;
                    continue;
                }
                return CalculateWinningBoardResult(lastWinningBoardIndex, drawnNumber);
            }
            return 0;
        }
    }
}
