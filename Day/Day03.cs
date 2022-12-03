namespace AdventOfCode2022.Day
{
    public class Day03 : IDay
    {
        public string Part1(string input)
        {
            return input.Split('\n').Select(x =>
            {
                // Get the 1st and 2nd part of the sentence
                var p1 = x[..(x.Length / 2)];
                var p2 = x[(x.Length / 2)..];

                var l = p1.First(x => p2.Contains(x)); // Find the letter in common

                // Calculate score
                if (l >= 'a')
                    return 'a' - l + 1;
                return 'A' - l + 27;
            }).Sum().ToString();
        }

        public string Part2(string input)
        {
            return string.Empty;
        }
    }
}
