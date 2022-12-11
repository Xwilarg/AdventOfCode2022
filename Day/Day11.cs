using System.Text.RegularExpressions;

namespace AdventOfCode2022.Day
{
    public class Day11 : IDay
    {
        public string Part1(string input)
        {
            var matches = Regex.Matches(input, "Monkey [0-9]+:\n  Starting items: ([0-9, ]+)\n  Operation: new = old ([+*]) ([0-9]+|old)\n  Test: divisible by ([0-9]+)\n    If true: throw to monkey ([0-9]+)\n    If false: throw to monkey ([0-9]+)", RegexOptions.Compiled);
            List<List<int>> monkeys = Enumerable.Range(0, matches.Count).Select(_ => new List<int>()).ToList();

            var index = 0;
            foreach (var match in matches.Cast<Match>())
            {
                var groups = match.Groups;
                var sending = groups[1].Value.Split(',').Select(x =>
                {
                    var a = int.Parse(x);
                    var b = groups[3].Value == "old" ? a : int.Parse(groups[3].Value);
                    return groups[2].Value switch
                    {
                        "+" => a + b,
                        "*" => a * b,
                        _ => throw new()
                    };
                });
                foreach (var data in sending)
                {
                    monkeys[int.Parse((data % int.Parse(groups[4].Value) == 0 ? groups[5] : groups[6]).Value)].Add(data);
                }
                index++;
            }
            foreach (var m in monkeys)
            {
                Console.WriteLine($"Money content: {string.Join(", ", m)}");
            }
            return string.Empty;
        }

        public string Part2(string input)
        {
            return string.Empty;
        }
    }
}
