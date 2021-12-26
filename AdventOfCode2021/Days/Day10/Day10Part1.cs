using AdventOfCode2021.Enumerations;

namespace AdventOfCode2021.Days
{
    internal class Day10Part1 : Day10
    {
        internal Day10Part1(string filePath) : base(filePath)
        {
        }

        private readonly List<string> GoodSymbolPairs = new() { "<>", "()", "[]", "{}" };
        private readonly char[] ClosingCharacters = { '>', ')', ']', '}' };
        protected override int Calculate()
        {
            var result = 0;
            foreach (var parsedLine in ParsedData)
            {
                bool finishedLine = false;
                var currentString = parsedLine;
                while (!finishedLine)
                {
                    int startedStringLength = currentString.Length;
                    foreach (var goodPair in GoodSymbolPairs)
                    {
                        currentString = currentString.Replace(goodPair, "");
                    }
                    if (startedStringLength == currentString.Length)
                    {
                        finishedLine = true;
                    }
                }
                result += CalculateCorruptedLine(currentString);
            }
            return result;
        }

        int CalculateCorruptedLine(string currentString)
        {
            var firstClosingSymbolIndex = currentString.IndexOfAny(ClosingCharacters);
            if (firstClosingSymbolIndex == -1) return 0;
            var closingCharacter = currentString[firstClosingSymbolIndex];

            if (closingCharacter == '>')
            {
                return (int)ClosingCharacterPair.MoreThan;
            }
            else if (closingCharacter == ')')
            {
                return (int)ClosingCharacterPair.Brackets;
            }
            else if (closingCharacter == ']')
            {
                return (int)ClosingCharacterPair.SquareBrackets;
            }
            else if (closingCharacter == '}')
            {
                return (int)ClosingCharacterPair.CurlyBrackets;
            }
            return 0;
        }
    }
}
