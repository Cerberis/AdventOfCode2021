namespace AdventOfCode2021.Days
{
    internal class Day4Part1 : Day4
    {
        internal Day4Part1(string filePath) : base(filePath)
        {
        }

        internal override int Calculate()
        {
            foreach (var drawnNumber in DrawnNumbers)
            {
                CheckForDrawnNumber(drawnNumber);
                CheckIfThereIsWinner();

                int winningBoardIndex = BingoBoards.Where(m => m.Won == true).Select(m => m.BoardIndex).FirstOrDefault();
                if (winningBoardIndex > 0)
                {
                    return CalculateWinningBoardResult(winningBoardIndex, drawnNumber);
                }
            }
            return 0;
        }
    }
}
