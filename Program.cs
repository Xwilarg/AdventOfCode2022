using AdventOfCode2022;

if (!Directory.Exists("Data"))
{
    throw new FileNotFoundException("Missing Data/ folder");
}

var data = new[]
{
    new Day01()
};

using HttpClient http = new();

for (var i = 0; i < data.Length; i++)
{
    Console.WriteLine($"--- Day {i + 1} ---");
    var input = File.ReadAllText($"Data/day{i + 1}.txt");
    Console.WriteLine($"Part 1: {data[i].Part1(input)}");
    Console.WriteLine($"Part 2: {data[i].Part2(input)}");
}