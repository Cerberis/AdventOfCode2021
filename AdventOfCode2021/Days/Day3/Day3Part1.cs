using AdventOfCode2021.Models;

namespace AdventOfCode2021.Days
{
    internal class Day3Part1 : Day3
    {
        internal Day3Part1(string filePath) : base(filePath)
        {
        }

        internal override int Calculate()
        {
            var result = GetHowCommonBytesAre(ParsedData);
            string mostCommonBite = string.Join("", result.Select(m => m.MostCommonBite.Key));
            string leastCommonBite = string.Join("", result.Select(m => m.LeastCommonBite.Key));
            var gammaRate = Convert.ToInt32(mostCommonBite, 2);
            var epsilonRate = Convert.ToInt32(leastCommonBite, 2);
            return gammaRate * epsilonRate;
        }

        private List<ByteCommonity> GetHowCommonBytesAre(List<string> reportData)
        {
            var result = new List<ByteCommonity>();

            for (int i = 0; i < reportData.First().Length; i++)
            {
                var groupChars = from str in reportData
                                 group str by str[i]
                                 into grp
                                 select new { Letter = grp.Key, Quantity = grp.Count() };
                result.Add(new ByteCommonity
                {
                    Index = i,
                    LeastCommonBite = groupChars.OrderBy(m => m.Quantity).Select(m => new KeyValuePair<char, int>(m.Letter, m.Quantity)).First(),
                    MostCommonBite = groupChars.OrderByDescending(m => m.Quantity).Select(m => new KeyValuePair<char, int>(m.Letter, m.Quantity)).First()
                });
            }

            return result;
        }
    }
}
