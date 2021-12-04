namespace AdventOfCode2021.Models
{
    internal class BingoBoard
    {
        public int BoardIndex { get; set; }
        public List<BingoRow> Rows { get; set; }
        public bool Won { get; set; }
    }
}
