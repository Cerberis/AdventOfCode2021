namespace AdventOfCode2021.Models
{
    internal class ByteCommonity
    {
        internal int Index { get; set; }
        internal KeyValuePair<char, int> MostCommonBite { get; set; }
        internal KeyValuePair<char, int> LeastCommonBite { get; set; }
    }
}
