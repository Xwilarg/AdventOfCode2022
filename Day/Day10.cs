using System.Text;

namespace AdventOfCode2022.Day
{
    public class Day10 : IDay
    {
        private static void Execute(string input, Action<int, int> onCycle)
        {
            var cycle = 1;
            var value = 1;

            void increaseCycle()
            {
                cycle++;

                onCycle(cycle, value);
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
        }

        public string Part1(string input)
        {
            var score = 0;
            Execute(input, (int cycle, int value) =>
            {
                if ((cycle - 20) % 40 == 0)
                {
                    score += value * cycle;
                }
            });
            return score.ToString();
        }

        public string Part2(string input)
        {
            var width = 40;
            var height = 1;
            StringBuilder str = new();
            str.AppendLine();
            var oldValue = 1;
            Execute(input, (int cycle, int value) =>
            {
                cycle--;
                str.Append(cycle >= oldValue && cycle < oldValue + 3 ? "#" : ".");
                if (cycle % 40 == 0)
                {
                    str.AppendLine();
                }
                oldValue = value; // We need to do instructions at the start of the cycle
            });

            return str.ToString();
        }
    }
}
