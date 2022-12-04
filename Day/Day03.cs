namespace AdventOfCode2022.Day
{
    public class Day03 : IDay
    {
        private static int LetterToScore(char c)
        {
            if (c >= 'a')
                return c - 'a' + 1;
            return c - 'A' + 27;
        }

        public int Part1(string input)
        {
            return input.Split('\n').Select(x =>
            {
                // Get the 1st and 2nd part of the sentence
                var p1 = x[..(x.Length / 2)];
                var p2 = x[(x.Length / 2)..];

                // Find the letter in common
                var l = p1.First(x => p2.Contains(x));

                return LetterToScore(l);
            }).Sum();
        }

        public int Part2(string input)
        {
            var arr = input.Split("\n");
            // Take data by chunk of 3
            return Enumerable.Range(0, arr.Length / 3).Select(i =>
            {
                // Current chunk
                var data = arr.Skip(i * 3).Take(3).ToArray();

                // Letter in common in the 3 lines
                var l = data[0].First(x => data[1].Contains(x) && data[2].Contains(x));

                return LetterToScore(l);
            }).Sum();
        }
    }
}
