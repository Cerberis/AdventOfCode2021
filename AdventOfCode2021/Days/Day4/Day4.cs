using AdventOfCode2021.Models;
using CommonCode;
using CommonCode.Extensions;

namespace AdventOfCode2021.Days
{
    internal abstract class Day4
    {
        internal List<BingoBoard> BingoBoards { get; }
        internal List<string> DrawnNumbers { get; }

        internal Day4(string filePath)
        {
            DrawnNumbers = ReadDrawnNumber(filePath);
            BingoBoards = ReadBingoBoards(filePath);
        }

        internal string Execute()
        {
            var result = Calculate();

            Console.WriteLine($"Result: {result}");
            return result.ToString();
        }

        internal abstract int Calculate();

        internal List<string> ReadDrawnNumber(string filePath)
        {
            return File.ReadAllLines(filePath).First().Split(',').Where(m => !string.IsNullOrEmpty(m)).ToList();
        }

        internal List<BingoBoard> ReadBingoBoards(string filePath)
        {
            var dataRows = File.ReadAllLines(filePath);
            var result = new List<BingoBoard>();
            int boardIndex = 0;
            var currentBoard = new BingoBoard
            {
                BoardIndex = boardIndex,
                Rows = new List<BingoRow>()
            };

            foreach (var dataRow in dataRows.Skip(2))
            {
                if (string.IsNullOrEmpty(dataRow))
                {
                    PrintBadBoard(currentBoard);

                    result.Add(currentBoard);

                    boardIndex++;
                    currentBoard = new BingoBoard
                    {
                        BoardIndex = boardIndex,
                        Rows = new List<BingoRow>()
                    };
                    continue;
                }

                var rowNumbers = dataRow.Split(' ').Where(m => !string.IsNullOrEmpty(m)).ToList();
                currentBoard.Rows.Add(new BingoRow { Values = rowNumbers });
            }

            if (currentBoard.Rows.Any())
            {
                result.Add(currentBoard);
            }
            return result;
        }

        protected int CalculateWinningBoardResult(int winningBoardIndex, string drawnNumber)
        {
            var unmarkedNumberSum = CalculateUnmarkedNumberSum(winningBoardIndex);
            return unmarkedNumberSum * drawnNumber.ToInt();
        }

        protected void CheckIfThereIsWinner()
        {
            CheckForWinningRow();
            CheckForWinningColumn();
            //CheckForWinningDiagonals();
        }

        protected void CheckForDrawnNumber(string drawnNumber)
        {
            foreach (var board in BingoBoards.Where(m=> m.Won == false))
            {
                foreach (var boardLane in board.Rows)
                {
                    var foundIndex = boardLane.Values.IndexOf(drawnNumber);
                    if (foundIndex >= 0)
                    {
                        boardLane.Values[foundIndex] = "-";
                    }
                }
            }
        }

        protected void PrintBoard(BingoBoard currentBoard)
        {
            Console.WriteLine("---------------------");
            Console.WriteLine($"Bingo board Id: {currentBoard.BoardIndex}");
            currentBoard.Rows.ForEach(m => Console.WriteLine(string.Join(" ", m.Values)));
        }

        private void PrintBadBoard(BingoBoard currentBoard)
        {
            if (currentBoard.Rows.Count == 5) return;
            Console.WriteLine($"Board {currentBoard.BoardIndex} is illegal");
            PrintBoard(currentBoard);
        }

        private int CalculateUnmarkedNumberSum(int winningBoardId)
        {
            var unmarkedNumberSum = 0;
            foreach (var boardRow in BingoBoards.First(m => m.BoardIndex == winningBoardId).Rows)
            {
                unmarkedNumberSum += boardRow.Values.Sum(m => m.ToInt());
            }
            return unmarkedNumberSum;
        }

        private void CheckForWinningRow()
        {
            foreach (var board in BingoBoards.Where(m=> m.Won == false))
            {
                if (board.Rows.Any(rows => rows.Values.Where(value => value == "-").Count() == 5))
                    board.Won = true;
            }
        }

        private void CheckForWinningColumn()
        {
            foreach (var board in BingoBoards.Where(m => m.Won == false))
            {
                for (int columnIndex = 0; columnIndex < 5; columnIndex++)
                {
                    if (board.Rows.Where(m => m.Values[columnIndex] == "-").Count() == 5)
                        board.Won = true;
                }
            }
        }

        private void CheckForWinningDiagonals()
        {
            foreach (var board in BingoBoards.Where(m => m.Won == false))
            {
                bool onlyWinningNumbers = true;
                for (int columnIndex = 0; columnIndex < 5; columnIndex++)
                {
                    if (board.Rows[columnIndex].Values[columnIndex] != "-")
                    {
                        onlyWinningNumbers = false;
                        break;
                    }
                }
                if (onlyWinningNumbers)
                    board.Won = true;

                onlyWinningNumbers = true;

                for (int columnIndex = 0; columnIndex < 5; columnIndex++)
                {
                    if (board.Rows[columnIndex].Values[4 - columnIndex] != "-")
                    {
                        onlyWinningNumbers = false;
                        break;
                    }
                }
                if (onlyWinningNumbers)
                    board.Won = true;
            }
        }
    }
}

       
       
       
       
       