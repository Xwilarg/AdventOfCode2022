namespace AdventOfCode2022.Day
{
    public class Day02 : IDay
    {
        public int Part1(string input)
        {
            return input.Split('\n').Select(x =>
            {
                // Convert input to number
                var a1 = 3 - ('C' - x[0]);
                var a2 = 3 - ('Z' - x[2]);
                var d = a2 - a1;

                return a2 +
                    (a1 == a2 ? 3 // Values are equal, draw
                    : d == 1 || d == -2 ? 6 // Win
                    : 0); // Loose
            }).Sum();
        }

        public int Part2(string input)
        {
            return input.Split('\n').Select(x =>
            {
                var a1 = 3 - ('C' - x[0]);
                var a2 = 3 - ('Z' - x[2]);

                return (a2 - 1) * 3 + // Score of the round result
                    (a2 == 2 ? a1 // Need to draw, return a1
                    : a2 == 1 ? a1 == 1 ? 3 : a1 - 1 // Loose
                    : a1 == 3 ? 1 : a1 + 1); // Win
            }).Sum();
        }
    }
}
