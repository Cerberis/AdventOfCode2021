using AdventOfCode2021.Models;

namespace AdventOfCode2021.Days
{
    internal class Day3Part2 : Day3
    {
        internal Day3Part2(string filePath) : base(filePath)
        {

        }

        internal override int Calculate()
        {
            var oxygenGeneratorRating = ParsedData;
            var co2ScrubberRating = ParsedData;
            for (int i = 0; i < ParsedData.First().Length; i++)
            {
                var oxygenByteCommonity = GetHowCommonBytesAre(oxygenGeneratorRating, i);
                var co2ByteCommonity = GetHowCommonBytesAre(co2ScrubberRating, i);

                var oxygenFilteredByte = MostCommonLetterCalculator(oxygenByteCommonity, "oxygen");
                var co2FilteredByte = MostCommonLetterCalculator(co2ByteCommonity, "co2");

                if (oxygenGeneratorRating.Count > 1)
                {
                    oxygenGeneratorRating = FilterData(oxygenGeneratorRating, oxygenFilteredByte, i);

                }
                if (co2ScrubberRating.Count > 1)
                {
                    co2ScrubberRating = FilterData(co2ScrubberRating, co2FilteredByte, i);

                }
            }
            return CalculatedLifeSupportRating(oxygenGeneratorRating.FirstOrDefault(), co2ScrubberRating.FirstOrDefault());
        }

        static int CalculatedLifeSupportRating(string? oxygenRatingAsByte, string? co2RatingAsByte)
        {
            var oxygenRating = Convert.ToInt32(oxygenRatingAsByte, 2);
            var xo0Rating = Convert.ToInt32(co2RatingAsByte, 2);
            return oxygenRating * xo0Rating;
        }

        static List<string> FilterData(List<string> data, char oxygenByteCommonity, int index)
        {
            return data.Where(m => m[index] == oxygenByteCommonity).ToList();
        }

        static char MostCommonLetterCalculator(ByteCommonity byteCommonity, string type)
        {
            if (type == "oxygen")
            {
                if (byteCommonity.MostCommonBite.Value > byteCommonity.LeastCommonBite.Value)
                {
                    return byteCommonity.MostCommonBite.Key;
                }
                else if (byteCommonity.MostCommonBite.Value < byteCommonity.LeastCommonBite.Value)
                {
                    return byteCommonity.LeastCommonBite.Key;
                }
                else
                {
                    return '1';
                }
            }
            else if (type == "co2")
            {
                if (byteCommonity.MostCommonBite.Value > byteCommonity.LeastCommonBite.Value)
                {
                    return byteCommonity.LeastCommonBite.Key;
                }
                else if (byteCommonity.MostCommonBite.Value < byteCommonity.LeastCommonBite.Value)
                {
                    return byteCommonity.MostCommonBite.Key;
                }
                else
                {
                    return '0';
                }
            }
            return '-';
        }

        internal static ByteCommonity GetHowCommonBytesAre(List<string> reportData, int index)
        {
            var groupChars = from str in reportData
                             group str by str[index]
                             into grp
                             select new { Letter = grp.Key, Quantity = grp.Count() };
            var result = new ByteCommonity
            {
                Index = index,
                LeastCommonBite = groupChars.OrderBy(m => m.Quantity).Select(m => new KeyValuePair<char, int>(m.Letter, m.Quantity)).First(),
                MostCommonBite = groupChars.OrderByDescending(m => m.Quantity).Select(m => new KeyValuePair<char, int>(m.Letter, m.Quantity)).First()
            };

            return result;
        }

    }
}
