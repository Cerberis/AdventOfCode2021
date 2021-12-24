using AdventOfCode2021.Enumerations;
using AdventOfCode2021.Models;
using CommonCode.Extensions;

namespace AdventOfCode2021.Days
{
    internal class Day8Part2 : Day8
    {
        internal Day8Part2(string filePath) : base(filePath)
        {

        }

        Dictionary<ClockWirePosition, List<char>> DefaultWires;
        Dictionary<int, List<char>> CalculatedNumbers;


        protected override int Calculate()
        {
            int result = 0;
            foreach (var parsedRow in ParsedData)
            {

                InitializeDigitalClock();
                GetDigit1(parsedRow);
                GetTopWireValue(parsedRow);
                GetDigit4(parsedRow);
                GetDigit3(parsedRow);
                GetBottomRightAndBottomWireValues(parsedRow);
                GetBottomLeftWireValue(parsedRow);

                CalculateFilteredNumbers();
                result += DecryptExpectedResults(parsedRow.ExpectedResults).ToInt();
            }


            //to low 594060
            return result;
        }

        private string DecryptExpectedResults(List<string> expectedResults)
        {
            var result = string.Empty;
            foreach (var expectedResult in expectedResults)
            {
                foreach(var calculatedNumber in CalculatedNumbers.Where(m=> m.Value.Count == expectedResult.Length))
                {
                    if(calculatedNumber.Value.Except(expectedResult.ToArray()).Count() == 0)
                    {
                        result += calculatedNumber.Key.ToString();
                        break;
                    }
                }
            }
            return result;
        }

        private void CalculateFilteredNumbers()
        {
            CalculatedNumbers = new Dictionary<int, List<char>>();
            for (int i = 0; i < 10; i++)
            {
                CalculatedNumbers.Add(i, GetDigitLetters(i));
            }
        }

        private List<char> GetDigitLetters(int digit)
        {
            var letterList = new List<char>();
            switch (digit)
            {
                case 0:
                    letterList.AddRange(DefaultWires[ClockWirePosition.Top]);
                    letterList.AddRange(DefaultWires[ClockWirePosition.TopRight]);
                    letterList.AddRange(DefaultWires[ClockWirePosition.BottomRight]);
                    letterList.AddRange(DefaultWires[ClockWirePosition.Bottom]);
                    letterList.AddRange(DefaultWires[ClockWirePosition.TopLeft]);
                    letterList.AddRange(DefaultWires[ClockWirePosition.BottomLeft]);
                    break;
                case 1:
                    letterList.AddRange(DefaultWires[ClockWirePosition.TopRight]);
                    letterList.AddRange(DefaultWires[ClockWirePosition.BottomRight]);
                    break;
                case 2:
                    letterList.AddRange(DefaultWires[ClockWirePosition.Top]);
                    letterList.AddRange(DefaultWires[ClockWirePosition.TopRight]);
                    letterList.AddRange(DefaultWires[ClockWirePosition.Middle]);
                    letterList.AddRange(DefaultWires[ClockWirePosition.Bottom]);
                        letterList.AddRange(DefaultWires[ClockWirePosition.BottomLeft]);
                    break;
                case 3:
                    letterList.AddRange(DefaultWires[ClockWirePosition.Top]);
                    letterList.AddRange(DefaultWires[ClockWirePosition.TopRight]);
                    letterList.AddRange(DefaultWires[ClockWirePosition.BottomRight]);
                    letterList.AddRange(DefaultWires[ClockWirePosition.Middle]);
                    letterList.AddRange(DefaultWires[ClockWirePosition.Bottom]);
                    break;
                case 4:
                    letterList.AddRange(DefaultWires[ClockWirePosition.TopRight]);
                    letterList.AddRange(DefaultWires[ClockWirePosition.BottomRight]);
                    letterList.AddRange(DefaultWires[ClockWirePosition.Middle]);
                    letterList.AddRange(DefaultWires[ClockWirePosition.TopLeft]);
                    break;
                case 5:
                    letterList.AddRange(DefaultWires[ClockWirePosition.Top]);
                    letterList.AddRange(DefaultWires[ClockWirePosition.BottomRight]);
                    letterList.AddRange(DefaultWires[ClockWirePosition.Middle]);
                    letterList.AddRange(DefaultWires[ClockWirePosition.Bottom]);
                    letterList.AddRange(DefaultWires[ClockWirePosition.TopLeft]);
                    break;
                case 6:
                    letterList.AddRange(DefaultWires[ClockWirePosition.Top]);
                    letterList.AddRange(DefaultWires[ClockWirePosition.BottomRight]);
                    letterList.AddRange(DefaultWires[ClockWirePosition.Middle]);
                    letterList.AddRange(DefaultWires[ClockWirePosition.Bottom]);
                    letterList.AddRange(DefaultWires[ClockWirePosition.TopLeft]);
                    letterList.AddRange(DefaultWires[ClockWirePosition.BottomLeft]);
                    break;
                case 7:
                    letterList.AddRange(DefaultWires[ClockWirePosition.Top]);
                    letterList.AddRange(DefaultWires[ClockWirePosition.TopRight]);
                    letterList.AddRange(DefaultWires[ClockWirePosition.BottomRight]);
                    break;
                case 8:
                    letterList.AddRange(DefaultWires[ClockWirePosition.Top]);
                    letterList.AddRange(DefaultWires[ClockWirePosition.TopRight]);
                    letterList.AddRange(DefaultWires[ClockWirePosition.BottomRight]);
                    letterList.AddRange(DefaultWires[ClockWirePosition.Middle]);
                    letterList.AddRange(DefaultWires[ClockWirePosition.Bottom]);
                    letterList.AddRange(DefaultWires[ClockWirePosition.TopLeft]);
                    letterList.AddRange(DefaultWires[ClockWirePosition.BottomLeft]);
                    break;
                case 9:
                    letterList.AddRange(DefaultWires[ClockWirePosition.Top]);
                    letterList.AddRange(DefaultWires[ClockWirePosition.TopRight]);
                    letterList.AddRange(DefaultWires[ClockWirePosition.BottomRight]);
                    letterList.AddRange(DefaultWires[ClockWirePosition.Middle]);
                    letterList.AddRange(DefaultWires[ClockWirePosition.Bottom]);
                    letterList.AddRange(DefaultWires[ClockWirePosition.TopLeft]);
                    break;
            }
            return letterList;
        }

        private void GetDigit1(DigitalClockSource parsedRow)
        {
            var foundNumber = parsedRow.NumberSets.First(m => m.Length == 2);
            LeaveOnlyGivenLetters(foundNumber.ToArray(), ClockWirePosition.TopRight, ClockWirePosition.BottomRight);
        }

        private void GetDigit4(DigitalClockSource parsedRow)
        {
            var foundNumber = parsedRow.NumberSets.First(m => m.Length == 4);
            var topRightWireLetters = DefaultWires[ClockWirePosition.TopRight];
            var foundValue = foundNumber.ToArray().Except(topRightWireLetters);
            LeaveOnlyGivenLetters(foundValue.ToArray(), ClockWirePosition.TopLeft, ClockWirePosition.Middle);
        }

        private void GetDigit3(DigitalClockSource parsedRow)
        {
            var numbersWith5Letters = parsedRow.NumberSets.Where(m => m.Length == 5);
            var topRightWireLetters = DefaultWires[ClockWirePosition.TopRight].ToList();
            topRightWireLetters.AddRange(DefaultWires[ClockWirePosition.Top]);
            foreach (var numbersWith5Letter in numbersWith5Letters)
            {
                var differentValues = numbersWith5Letter.ToArray().Except(topRightWireLetters);
                if (differentValues.Count() == 2)
                {
                    LeaveOnlyGivenLetters(differentValues.ToArray(), ClockWirePosition.Middle, ClockWirePosition.Bottom);
                    break;
                }
            }
        }

        private void GetBottomLeftWireValue(DigitalClockSource parsedRow)
        {
            var numbersWith6Letters = parsedRow.NumberSets.Where(m => m.Length == 6);
            var number9DigitLetters = DefaultWires[ClockWirePosition.Top].ToList();
            number9DigitLetters.AddRange(DefaultWires[ClockWirePosition.TopRight]);
            number9DigitLetters.AddRange(DefaultWires[ClockWirePosition.Middle]);
            number9DigitLetters.AddRange(DefaultWires[ClockWirePosition.BottomRight]);
            number9DigitLetters.AddRange(DefaultWires[ClockWirePosition.Bottom]);
            foreach (var numbersWith6Letter in numbersWith6Letters)
            {
                var differentValues = numbersWith6Letter.Except(number9DigitLetters.ToArray());
                if (differentValues.Count() == 1)
                {
                    LeaveOnlyGivenLetters(differentValues.ToArray(), ClockWirePosition.TopLeft);
                    number9DigitLetters.AddRange(differentValues.ToArray());
                    CalculateBottomLeftWireLetter(parsedRow, number9DigitLetters);
                    break;
                }
            }
        }

        private void GetBottomRightAndBottomWireValues(DigitalClockSource parsedRow)
        {
            var numbersWith6Letters = parsedRow.NumberSets.Where(m => m.Length == 6);
            var topRightWireLetters = DefaultWires[ClockWirePosition.TopRight];
            foreach (var numbersWith6Letter in numbersWith6Letters)
            {
                var differentValues = topRightWireLetters.Except(numbersWith6Letter.ToArray());
                if (differentValues.Count() == 1)
                {
                    LeaveOnlyGivenLetters(differentValues.ToArray(), ClockWirePosition.TopRight);
                    CalculateBottomRightWireLetter();
                    CalculateBottomWireLetter(parsedRow);
                    break;
                }
            }
        }


        private void GetTopWireValue(DigitalClockSource parsedRow)
        {
            var foundNumber = parsedRow.NumberSets.First(m => m.Length == 3);
            var topRightWireLetters = DefaultWires[ClockWirePosition.TopRight];
            var topWireLetter = foundNumber.ToArray().Except(topRightWireLetters);
            LeaveOnlyGivenLetters(topWireLetter.ToArray(), ClockWirePosition.Top);
        }

        private void CalculateBottomRightWireLetter()
        {
            var topRightWireLetters = DefaultWires[ClockWirePosition.TopRight];
            var bottomRightWireLetters = DefaultWires[ClockWirePosition.BottomRight];
            var differentValues = bottomRightWireLetters.Except(topRightWireLetters);
            LeaveOnlyGivenLetters(differentValues.ToArray(), ClockWirePosition.BottomRight);
        }

        private void CalculateBottomLeftWireLetter(DigitalClockSource parsedRow, List<char> number9DigitLetters)
        {
            var numberWith7Letters = parsedRow.NumberSets.Where(m => m.Length == 7).First();
            var differentValues = numberWith7Letters.Except(number9DigitLetters);
            LeaveOnlyGivenLetters(differentValues.ToArray(), ClockWirePosition.BottomLeft);
        }

        private void CalculateBottomWireLetter(DigitalClockSource parsedRow)
        {
            var numbersWith5Letters = parsedRow.NumberSets.Where(m => m.Length == 5);
            var number3DigitLetters = DefaultWires[ClockWirePosition.Top].ToList();
            number3DigitLetters.AddRange(DefaultWires[ClockWirePosition.TopRight]);
            number3DigitLetters.AddRange(DefaultWires[ClockWirePosition.BottomRight]);
            number3DigitLetters.AddRange(DefaultWires[ClockWirePosition.Middle]);
            foreach (var numbersWith5Letter in numbersWith5Letters)
            {
                var differentValues = numbersWith5Letter.ToArray().Except(number3DigitLetters);
                if (differentValues.Count() == 1)
                {
                    LeaveOnlyGivenLetters(differentValues.ToArray(), ClockWirePosition.Bottom);
                    break;
                }
            }
        }

                private void LeaveOnlyGivenLetters(char[] letters, params ClockWirePosition[] positions)
        {

            foreach (var position in positions)
            {
                var badLetters = DefaultWires[position].Where(m => !letters.Contains(m)).ToList();
                foreach (var badLetter in badLetters)
                {
                    DefaultWires[position].Remove(badLetter);
                }
            }
        }

        private void InitializeDigitalClock()
        {
            DefaultWires = new Dictionary<ClockWirePosition, List<char>>
            {
                { ClockWirePosition.Top, new() { 'a', 'b', 'c', 'd', 'e', 'f', 'g' } },
                { ClockWirePosition.Middle, new() { 'a', 'b', 'c', 'd', 'e', 'f', 'g' } },
                { ClockWirePosition.Bottom, new() { 'a', 'b', 'c', 'd', 'e', 'f', 'g' } },
                { ClockWirePosition.TopLeft, new() { 'a', 'b', 'c', 'd', 'e', 'f', 'g' } },
                { ClockWirePosition.BottomLeft, new() { 'a', 'b', 'c', 'd', 'e', 'f', 'g' } },
                { ClockWirePosition.TopRight, new() { 'a', 'b', 'c', 'd', 'e', 'f', 'g' } },
                { ClockWirePosition.BottomRight, new() { 'a', 'b', 'c', 'd', 'e', 'f', 'g' } }
            };
        }
    }
}