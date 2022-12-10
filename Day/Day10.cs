namespace AdventOfCode2022.Day
{
    public class Day10 : IDay
    {
        public string Part1(string input)
        {
            var cycle = 1;
            var value = 1;
            var score = 0;

            void increaseCycle()
            {
                cycle++;

                if ((cycle - 20) % 40 == 0)
                {
                    score += value * cycle;
                }
            }

            foreach (var line in input.Split('\n'))
            {
                var data = line.Split();

                if (data[0] != "noop")
                {
                    increaseCycle();
                    value += int.Parse(data[1]);
                }
                increaseCycle();
            }

            return score.ToString();
        }

        public string Part2(string input)
        {
            return string.Empty;
        }
    }
}
