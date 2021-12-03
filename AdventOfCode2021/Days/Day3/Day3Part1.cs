using System;
using System.Linq;

namespace AdventOfCode2021.Days
{
    internal class Day3Part1 : Day3
    {
        internal Day3Part1(string filePath) : base(filePath)
        {
        }

        internal override int Calculate()
        {
            string mostCommonBite = "";
            string leastCommonBite = "";

            for (int i = 0; i < ParsedData.First().Length; i++)
            {
                var groupChars = from str in ParsedData
                                 group str by str[i]
                                 into grp
                                 select new { Letter = grp.Key, Quantity = grp.Count() };
                mostCommonBite += groupChars.OrderByDescending(m => m.Quantity).First().Letter;
                leastCommonBite += groupChars.OrderBy(m => m.Quantity).First().Letter;
            }

            var gammaRate = Convert.ToInt32(mostCommonBite, 2);
            var epsilonRate = Convert.ToInt32(leastCommonBite, 2);
            return gammaRate * epsilonRate;
        }
    }
}
