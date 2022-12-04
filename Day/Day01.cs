namespace AdventOfCode2022.Day
{
    public class Day01 : IDay
    {
        // For each calories that an elf is carrying, we do the sum of it and order them from starting from the highest
        private static IEnumerable<int> GetAllSum(string input)
            => input.Split("\n\n").Select(x => x.Split('\n').Sum(y => int.Parse(y))).OrderByDescending(x => x);

        public int Part1(string input)
        {
            return GetAllSum(input).First();
        }

        public int Part2(string input)
        {
            return GetAllSum(input).Take(3).Sum();
        }
    }
}
