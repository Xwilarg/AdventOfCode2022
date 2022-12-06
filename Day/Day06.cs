namespace AdventOfCode2022.Day
{
    public class Day06 : IDay
    {
        // Return if the next 4 characters at the index are differents
        private static bool IsPacketStart(string input, int index)
        {
            return input.Skip(index).Take(4).Distinct().Count() == 4;
        }

        public string Part1(string input)
        {
            var startMarker = Array.FindIndex(Enumerable.Range(0, input.Length).ToArray(), x => IsPacketStart(input, x));
            var endMarker = Array.FindIndex(Enumerable.Range(startMarker + 1, input.Length).ToArray(), x => IsPacketStart(input, x));

            return (startMarker + 4).ToString();
        }

        public string Part2(string input)
        {
            return string.Empty;
        }
    }
}
