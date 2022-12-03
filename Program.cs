using AdventOfCode2022;
using System.Reflection;

if (!Directory.Exists("data"))
{
    throw new FileNotFoundException("Missing data/ folder");
}

// Get the current day we are at
int currDay = (int)DateTime.Now.Subtract(new DateTime(2022, 12, 1)).TotalDays + 1;
if (currDay > 24)
{
    currDay = 24;
}

// Get info about all days
List<DayInfo> allData = new();
for (var i = 1; i <= currDay; i++)
{
    allData.Add(GetDayInfo(i, $"data/day{i}.txt"));
}

// If we have sample data, send them to the last day we know of
if (File.Exists("data/sample.txt"))
{
    var data = GetDayInfo(currDay, "data/sample.txt");
    allData.Add(data with { Name = "Sample Data" });
}

// Display the results for each day
foreach (var info in allData)
{
    Console.WriteLine($"--- {info.Name} ---");
    Console.WriteLine($"Part 1: {info.Day.Part1(info.Input)}");
    Console.WriteLine($"Part 2: {info.Day.Part2(info.Input)}");
}

// Return information about a day given its number and path to input field
DayInfo GetDayInfo(int dayNumber, string inputPath)
{
    var type = Assembly.GetExecutingAssembly().GetType($"AdventOfCode2022.Day{(dayNumber > 9 ? "" : "0")}{dayNumber}", true)!;
    var day = (IDay)Activator.CreateInstance(type)!;
    var input = File.ReadAllText(inputPath).Trim();

    return new() { Name = $"Day {dayNumber}", Day = day, Input = input };
}

record DayInfo
{
    public required string Name;
    public required IDay Day;
    public required string Input;
}