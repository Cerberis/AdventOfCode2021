namespace AdventOfCode2021.Days
{
    internal class Day5Part1 : Day5
    {
        internal Day5Part1(string filePath) : base(filePath)
        {
        }

        internal override int Calculate()
        {
            MarkDiagram();
            //DrawDiagram();
            return FloorDiagram.Count(m => m.Value > 1);
        }

        internal override void MarkDiagram()
        {
            MarkHorizontalDiagram();
            MarkVerticalDiagram();
        }
    }
}
