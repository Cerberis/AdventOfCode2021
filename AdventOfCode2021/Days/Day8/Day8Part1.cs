namespace AdventOfCode2021.Days
{
    internal class Day8Part1 : Day8
    {
        internal Day8Part1(string filePath) : base(filePath)
        {
        }

        protected override int Calculate()
        {
            var expectedNumbers = new int[] { 2, 4, 3, 7 };
            return ParsedData.Sum(m => m.ExpectedResults.Count(m => expectedNumbers.Contains(m.Length)));
        }
    }
}
