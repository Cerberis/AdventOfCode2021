using CommonCode.Extensions;

namespace AdventOfCode2021.Days
{
    internal abstract class Day6
    {
        internal Dictionary<int,long> GroupedFishes { get; set; }

        internal Day6(string filePath)
        {
            GetFishList(filePath);
        }

       

        internal string Execute()
        {
            var result = Calculate();

            Console.WriteLine($"Result: {result}");
            return result.ToString();
        }


        internal abstract long Calculate();



        internal void GetFishList(string filePath)
        {
            var fishes = File.ReadAllLines(filePath).First().Split(',').Where(m => !string.IsNullOrEmpty(m)).Select(m => m.ToInt()).ToList();
            GroupedFishes = new Dictionary<int, long>(){
                {-1, 0},
                {0, 0},
                {1, 0},
                {2, 0},
                {3, 0},
                {4, 0},
                {5, 0},
                {6, 0},
                {7, 0},
                {8, 0}
            };

            var groupedFishes = fishes.GroupBy(f => f)
                        .Select(f => new
                        {
                            FishLifeSpan = f.Key,
                            Count = f.Count()
                        });
            foreach (var fish in groupedFishes)
            {
                GroupedFishes[fish.FishLifeSpan] = fish.Count;
            }
        }

        internal protected void WriteFishToConsole()
        {
           foreach(var fish in GroupedFishes)
            {
                Console.WriteLine($"Fish days {fish.Key} fish count {fish.Value}");
            }
        }

        internal protected void ResfreshFishCycle()
        {
            GroupedFishes[6] = GroupedFishes[6] + GroupedFishes[-1];
            GroupedFishes[-1] = 0;
        }

        internal protected void RemoveDay()
        {
            foreach (var groupedFish in GroupedFishes.Where(m => m.Key != -1).OrderBy(m => m.Key))
            {
                GroupedFishes[groupedFish.Key - 1] = groupedFish.Value;
            }
        }

        internal protected void AddNewFishes()
        {
            GroupedFishes[8] = GroupedFishes[-1];
        }
    }
}