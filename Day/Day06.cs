namespace AdventOfCode2022.Day
{
    public class Day06 : IDay
    {
        private static int FindUniqueNCharacters(string input, int msgLength)
        {
            // For each index of our input...
            return Array.FindIndex(Enumerable.Range(0, input.Length).ToArray(), x =>
            {
                // We go at the index and check if the msgLength next number of characters are unique
                return input.Skip(x).Take(msgLength).Distinct().Count() == msgLength;
            }) + msgLength;
        }

        public string Part1(string input)
        {
            return FindUniqueNCharacters(input, 4).ToString();
        }

        public string Part2(string input)
        {
            return FindUniqueNCharacters(input, 14).ToString();
        }
    }
}
