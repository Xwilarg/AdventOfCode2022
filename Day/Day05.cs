using System.Text.RegularExpressions;

namespace AdventOfCode2022.Day
{
    public partial class Day05 : IDay
    {
        /// <param name="input">File content</param>
        /// <param name="onDataPush">
        /// Modification done when data are pushed on a stack
        /// By default data are picked "by a crane" so 1,2,3 become 3,2,1
        /// </param>
        public static string Parse(string input, Func<IEnumerable<char>, IEnumerable<char>> onDataPush)
        {
            var lines = input.Split('\n');

            // A line is made from " [X]" except for the first element where the first space isn't here
            // So by taking the length / 4 we get a decimal value, that after being ceiled is our element count
            List<char>[] stacks = Enumerable.Range(0, (int)Math.Ceiling(lines[0].Length / 4f)).Select(x => new List<char>()).ToArray();

            // Are we done parsing
            var reachEndOfStacks = false;
            // Current line we are parsing
            var line = 0;

            while (!reachEndOfStacks)
            {
                // Current offset in the current line
                var offset = 1;
                // Index used to defined what is the current stack
                var index = 0;
                do // We go through the whole line
                {
                    var value = lines[line][offset];

                    if (value == '1') // This is the legend of the stack, we are done parsing
                    {
                        reachEndOfStacks = true;
                        break;
                    }

                    if (value != ' ') // We ignore empty elements
                    {
                        stacks[index].Insert(0, value);
                    }

                    offset += 4;
                    index++;
                } while (offset < lines[line].Length);
                line++;
            }

            // Move data around
            foreach (var str in lines.Skip(line + 1))
            {
                var data = Regex.Match(str, "move (\\d+) from (\\d+) to (\\d+)", RegexOptions.Compiled);

                var count = int.Parse(data.Groups[1].Value);
                var from = int.Parse(data.Groups[2].Value);
                var to = int.Parse(data.Groups[3].Value);

                // Add data to destination list
                stacks[from - 1].Reverse();
                stacks[to - 1].AddRange(onDataPush(stacks[from - 1].Take(count)));
                stacks[from - 1].Reverse();

                // Remove data from original list
                // Make sure we don't try to take more than what there is
                var sPoint = stacks[from - 1].Count - count;
                if (sPoint < 0) sPoint = 0;
                stacks[from - 1].RemoveRange(sPoint, count);
            }

            return string.Join("", stacks.Select(x => x.Last()));
        }

        public string Part1(string input)
        {
            return Parse(input, d => d);
        }

        public string Part2(string input)
        {
            return Parse(input, (d) =>
            {
                return d.Reverse();
            });
        }
    }
}
