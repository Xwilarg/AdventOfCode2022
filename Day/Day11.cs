using System;
using System.Text.RegularExpressions;

namespace AdventOfCode2022.Day
{
    public class Day11 : IDay
    {
        private class Monkey
        {
            public required List<int> ItemList { init; get; }
            public required char WorryOperand { init; get; }
            public required string WorryValue { init; get; }
            public required int WorryDivideCheck { init; get; }
            public required int WorryTargetTrue { init; get; }
            public required int WorryTargetFalse { init; get; }
        }

        public string Part1(string input)
        {
            var matches = Regex.Matches(input, "Monkey [0-9]+:\n  Starting items: ([0-9, ]+)\n  Operation: new = old ([+*]) ([0-9]+|old)\n  Test: divisible by ([0-9]+)\n    If true: throw to monkey ([0-9]+)\n    If false: throw to monkey ([0-9]+)", RegexOptions.Compiled);
            List<Monkey> monkeys = new();

            foreach (var match in matches.Cast<Match>())
            {
                var groups = match.Groups;
                monkeys.Add(new()
                {
                    ItemList = groups[1].Value.Split(',').Select(int.Parse).ToList(),
                    WorryOperand = groups[2].Value[0],
                    WorryValue = groups[3].Value,
                    WorryDivideCheck = int.Parse(groups[4].Value),
                    WorryTargetTrue = int.Parse(groups[5].Value),
                    WorryTargetFalse = int.Parse(groups[6].Value)
                });
            }
            foreach (var monkey in monkeys)
            {
                foreach (var data in monkey.ItemList.Select(x =>
                {
                    var a = x;
                    var b = monkey.WorryValue == "old" ? a : int.Parse(monkey.WorryValue);
                    return (int)Math.Round(monkey.WorryOperand switch
                    {
                        '+' => a + b,
                        '*' => a * b,
                        _ => throw new()
                    } / 3f);
                }))
                {
                    monkeys[data % monkey.WorryDivideCheck == 0 ? monkey.WorryTargetTrue : monkey.WorryTargetFalse].ItemList.Add(data);
                }
                monkey.ItemList.Clear();
            }
            foreach (var m in monkeys)
            {
                Console.WriteLine($"Monkey content: {string.Join(", ", m.ItemList)}");
            }
            return string.Empty;
        }

        public string Part2(string input)
        {
            return string.Empty;
        }
    }
}
