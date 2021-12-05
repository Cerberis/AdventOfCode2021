using AdventOfCode2021.Days;
using AdventOfCode2021.Enumerations;
using System.Reflection;

namespace AdventOfCode2021
{
    public static class RunModeHandler
    {
        public static string Execute(RunMode runMode)
        {
            switch (runMode)
            {
                case RunMode.Day1Part1:
                    {
                        int iterationLength = 1;
                        return Day1Handler(iterationLength);
                    }
                case RunMode.Day1Part2:
                    {
                        int iterationLength = 3;
                        return Day1Handler(iterationLength);
                    }
                case RunMode.Day2Part1:
                    return Day2Part1Handler();
                case RunMode.Day2Part2:
                    return Day2Part2Handler();
                case RunMode.Day3Part1:
                    return Day3Part1Handler();
                case RunMode.Day3Part2:
                    return Day3Part2Handler();
                case RunMode.Day4Part1:
                    return Day4Part1Handler();
                case RunMode.Day4Part2:
                    return Day4Part2Handler();
                case RunMode.Day5Part1:
                    return Day5Part1Handler();
                case RunMode.Day5Part2:
                    return Day5Part2Handler();
                case RunMode.Day6Part1:
                    return Day6Part1Handler();
                case RunMode.Day6Part2:
                    return Day6Part2Handler();
                case RunMode.Day7Part1:
                    return Day7Part1Handler();
                case RunMode.Day7Part2:
                    return Day7Part2Handler();
                case RunMode.Day8Part1:
                    return Day8Part1Handler();
                case RunMode.Day8Part2:
                    return Day8Part2Handler();
                case RunMode.Day9Part1:
                    return Day9Part1Handler();
                case RunMode.Day9Part2:
                    return Day9Part2Handler();
                case RunMode.Day10Part1:
                    return Day10Part1Handler();
                case RunMode.Day10Part2:
                    return Day10Part2Handler();
                case RunMode.Day11Part1:
                    return Day11Part1Handler();
                case RunMode.Day11Part2:
                    return Day11Part2Handler();
                case RunMode.Day12Part1:
                    return Day12Part1Handler();
                case RunMode.Day12Part2:
                    return Day12Part2Handler();
                case RunMode.Day13Part1:
                    return Day13Part1Handler();
                case RunMode.Day13Part2:
                    return Day13Part2Handler();
                case RunMode.Day14Part1:
                    return Day14Part1Handler();
                case RunMode.Day14Part2:
                    return Day14Part2Handler();
                case RunMode.Day15Part1:
                    return Day15Part1Handler();
                case RunMode.Day15Part2:
                    return Day15Part2Handler();
                case RunMode.Day16Part1:
                    return Day16Part1Handler();
                case RunMode.Day16Part2:
                    return Day16Part2Handler();
                case RunMode.Day17Part1:
                    return Day17Part1Handler();
                case RunMode.Day17Part2:
                    return Day17Part2Handler();
                case RunMode.Day18Part1:
                    return Day18Part1Handler();
                case RunMode.Day18Part2:
                    return Day18Part2Handler();
                case RunMode.Day19Part1:
                    return Day19Part1Handler();
                case RunMode.Day19Part2:
                    return Day19Part2Handler();
                case RunMode.Day20Part1:
                    return Day20Part1Handler();
                case RunMode.Day20Part2:
                    return Day20Part2Handler();

            }
            return "Nothing happened";
        }

        private static string Day1Handler(int iterationLength)
        {
            string path = GetPath(@"Days\Day1\Data.txt");
            var handler = new Day1(path, iterationLength);
            return handler.Execute();
        }

        private static string Day2Part1Handler()
        {
            string path = GetPath(@"Days\Day2\Data.txt");
            var handler = new Day2Part1(path);
            return handler.Execute();
        }

        private static string Day2Part2Handler()
        {
            string path = GetPath(@"Days\Day2\Data.txt");
            var handler = new Day2Part2(path);
            return handler.Execute();
        }

        private static string Day3Part1Handler()
        {
            string path = GetPath(@"Days\Day3\Data.txt");
            var handler = new Day3Part1(path);
            return handler.Execute();
        }

        private static string Day3Part2Handler()
        {
            string path = GetPath(@"Days\Day3\Data.txt");
            var handler = new Day3Part2(path);
            return handler.Execute();
        }

        private static string Day4Part1Handler()
        {
            string path = GetPath(@"Days\Day4\Data.txt");
            var handler = new Day4Part1(path);
            return handler.Execute();
        }

        private static string Day4Part2Handler()
        {
            string path = GetPath(@"Days\Day4\Data.txt");
            var handler = new Day4Part2(path);
            return handler.Execute();
        }

        private static string Day5Part1Handler()
        {
            string path = GetPath(@"Days\Day5\Data.txt");
            var handler = new Day5Part1(path);
            return handler.Execute();
        }

        private static string Day5Part2Handler()
        {
            string path = GetPath(@"Days\Day5\Data.txt");
            var handler = new Day5Part2(path);
            return handler.Execute();
        }

        private static string Day6Part1Handler()
        {
            throw new NotImplementedException();
        }

        private static string Day6Part2Handler()
        {
            throw new NotImplementedException();
        }

        private static string Day7Part1Handler()
        {
            throw new NotImplementedException();
        }

        private static string Day7Part2Handler()
        {
            throw new NotImplementedException();
        }

        private static string Day8Part1Handler()
        {
            throw new NotImplementedException();
        }

        private static string Day8Part2Handler()
        {
            throw new NotImplementedException();
        }

        private static string Day9Part1Handler()
        {
            throw new NotImplementedException();
        }

        private static string Day9Part2Handler()
        {
            throw new NotImplementedException();
        }

        private static string Day10Part1Handler()
        {
            throw new NotImplementedException();
        }

        private static string Day10Part2Handler()
        {
            throw new NotImplementedException();
        }

        private static string Day11Part1Handler()
        {
            throw new NotImplementedException();
        }

        private static string Day11Part2Handler()
        {
            throw new NotImplementedException();
        }

        private static string Day12Part1Handler()
        {
            throw new NotImplementedException();
        }

        private static string Day12Part2Handler()
        {
            throw new NotImplementedException();
        }

        private static string Day13Part1Handler()
        {
            throw new NotImplementedException();
        }

        private static string Day13Part2Handler()
        {
            throw new NotImplementedException();
        }

        private static string Day14Part1Handler()
        {
            throw new NotImplementedException();
        }

        private static string Day14Part2Handler()
        {
            throw new NotImplementedException();
        }

        private static string Day15Part1Handler()
        {
            throw new NotImplementedException();
        }

        private static string Day15Part2Handler()
        {
            throw new NotImplementedException();
        }

        private static string Day16Part1Handler()
        {
            throw new NotImplementedException();
        }

        private static string Day16Part2Handler()
        {
            throw new NotImplementedException();
        }

        private static string Day17Part1Handler()
        {
            throw new NotImplementedException();
        }

        private static string Day17Part2Handler()
        {
            throw new NotImplementedException();
        }

        private static string Day18Part1Handler()
        {
            throw new NotImplementedException();
        }

        private static string Day18Part2Handler()
        {
            throw new NotImplementedException();
        }

        private static string Day19Part1Handler()
        {
            throw new NotImplementedException();
        }

        private static string Day19Part2Handler()
        {
            throw new NotImplementedException();
        }

        private static string Day20Part1Handler()
        {
            throw new NotImplementedException();
        }

        private static string Day20Part2Handler()
        {
            throw new NotImplementedException();
        }

        private static string GetPath(string fileLocationInBin)
        {
            return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), fileLocationInBin);
        }
    }
}