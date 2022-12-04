namespace AdventOfCode2022.Day
{
    public class Day04 : IDay
    {
        public int Part1(string input)
        {
            return input.Split('\n').Count(x =>
            {
                var data = x.Split(",").ToArray();

                // Ranges
                var rd = data.Select(y => y.Split('-').Select(z => int.Parse(z)).ToArray()).ToArray();

                // Does they contain each other?
                return (rd[0][0] >= rd[1][0] && rd[0][1] <= rd[1][1]) || (rd[1][0] >= rd[0][0] && rd[1][1] <= rd[0][1]);
            });
        }

        public int Part2(string input)
        {
            return 0;
        }
    }
}
