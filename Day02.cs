namespace AdventOfCode2022
{
    public class Day02 : IDay
    {
        public string Part1(string input)
        {
            return input.Split('\n').Select(x =>
            {
                var a1 = 3 - ('C' - x[0]);
                var a2 = 3 - ('Z' - x[2]);
                var d = a2 - a1;

                return a2 +
                    (a1 == a2 ? 3
                    : d == 1 || d == -2 ? 6
                    : 0);
            }).Sum().ToString();
        }

        public string Part2(string input)
        {
            return string.Empty;
        }
    }
}
