using AdventOfCode2022;
using System.Reflection;

if (!Directory.Exists("Data"))
{
    throw new FileNotFoundException("Missing Data/ folder");
}

int currDay = (int)DateTime.Now.Subtract(new DateTime(2022, 12, 1)).TotalDays + 1;
if (currDay > 24)
{
    currDay = 24;
}

for (var i = 0; i < currDay; i++)
{
    var type = Assembly.GetExecutingAssembly().GetType($"AdventOfCode2022.Day{(i > 8 ? "" : "0")}{i + 1}", true)!;
    var day = (IDay)Activator.CreateInstance(type)!;

    Console.WriteLine($"--- Day {i + 1} ---");
    var input = File.ReadAllText($"Data/day{i + 1}.txt").Trim();
    Console.WriteLine($"Part 1: {day.Part1(input)}");
    Console.WriteLine($"Part 2: {day.Part2(input)}");
}