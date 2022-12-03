namespace AdventOfCode2022.Day
{
    public class Day01 : IDay
    {
        // For each calories that an elf is carrying, we do the sum of it and order them from starting from the highest
        private IEnumerable<int> GetAllSum(string input)
            => input.Split("\n\n").Select(x => x.Split('\n').Sum(y => int.Parse(y))).OrderByDescending(x => x);

        public string Part1(string input)
        {
            return GetAllSum(input).First().ToString();
        }

        public string Part2(string input)
        {
            return GetAllSum(input).Take(3).Sum().ToString();
        }
    }
}
