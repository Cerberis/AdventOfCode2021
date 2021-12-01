using CommonCode;

namespace AdventOfCode2021.Days
{
    internal abstract class Day1
    {
        internal abstract void Execute();

        internal int Calculate(int[] intArray, int iterationLength)
        {
            int timesDepthIncreased = 0;
            for (int i = 0; i < intArray.Length; i++)
            {
                if (intArray.Skip(i).Take(iterationLength).Sum() < intArray.Skip(i + 1).Take(iterationLength).Sum())
                    timesDepthIncreased++;
            }
            return timesDepthIncreased;
        }
    }
}
