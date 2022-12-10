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
                // Increase score every 40 lines, starting line 20
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
            StringBuilder str = new();
            str.AppendLine();
            var oldValue = 1;
            Execute(input, (int cycle, int value) =>
            {
                cycle--;
                // Is the cycle in the 3 pixels of the position?
                // We do % width since it reset every line
                str.Append(cycle % width >= oldValue && cycle % width < oldValue + 3 ? "#" : ".");
                if (cycle % width == 0)
                {
                    str.AppendLine();
                }
                oldValue = value; // We need to do instructions at the start of the cycle
            });

            return str.ToString();
        }
    }
}
