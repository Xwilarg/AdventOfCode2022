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
            public int InspectionCount { set; get; } = 0;
        }

        public int Execute(string input, int iterationCount, Func<int, int> onDataChange)
        {
            var matches = Regex.Matches(input, "Monkey [0-9]+:\n  Starting items: ([0-9, ]+)\n  Operation: new = old ([+*]) ([0-9]+|old)\n  Test: divisible by ([0-9]+)\n    If true: throw to monkey ([0-9]+)\n    If false: throw to monkey ([0-9]+)", RegexOptions.Compiled);
            List<Monkey> monkeys = new();

            // Regex data parsing of the input for each monkey
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
            foreach (var _ in Enumerable.Range(0, iterationCount))
            {
                foreach (var monkey in monkeys)
                {
                    foreach (var data in monkey.ItemList.Select(x =>
                    {
                        // Do the parsing for each data
                        var a = x;
                        var b = monkey.WorryValue == "old" ? a : int.Parse(monkey.WorryValue);
                        return onDataChange(monkey.WorryOperand switch
                        {
                            '+' => a + b,
                            '*' => a * b,
                            _ => throw new()
                        });
                    }))
                    {
                        // Send data to the right monkey
                        monkeys[data % monkey.WorryDivideCheck == 0 ? monkey.WorryTargetTrue : monkey.WorryTargetFalse].ItemList.Add(data);
                        monkey.InspectionCount++;
                    }
                    monkey.ItemList.Clear();
                }
            }
            var ordered = monkeys.Select(x => x.InspectionCount).OrderByDescending(x => x).ToArray();
            return ordered[0] * ordered[1];

        }

        public string Part1(string input)
        {
            return Execute(input, 20, x => x / 3).ToString();
        }

        public string Part2(string input)
        {
            return Execute(input, 10000, x => x).ToString();
        }
    }
}
