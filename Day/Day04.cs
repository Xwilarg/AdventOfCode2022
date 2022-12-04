namespace AdventOfCode2022.Day
{
    public class Day04 : IDay
    {
        private static int[][] GetRanges(string data)
        {
            var arr = data.Split(",").ToArray();

            // Ranges values are separated by a -
            return arr.Select(y => y.Split('-').Select(z => int.Parse(z)).ToArray()).ToArray();
        }

        public int Part1(string input)
        {
            return input.Split('\n').Count(x =>
            {
                var rd = GetRanges(x);

                // Does they englobe each other?
                return (rd[0][0] >= rd[1][0] && rd[0][1] <= rd[1][1]) || (rd[1][0] >= rd[0][0] && rd[1][1] <= rd[0][1]);
            });
        }

        public int Part2(string input)
        {
            return input.Split('\n').Count(x =>
            {
                var rd = GetRanges(x);

                // The minimum value of one of the range is inside the other
                return (rd[0][0] >= rd[1][0] && rd[0][0] <= rd[1][1]) || (rd[1][0] >= rd[0][0] && rd[1][0] <= rd[0][1]);
            });
        }
    }
}
