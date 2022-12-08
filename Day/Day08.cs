namespace AdventOfCode2022.Day
{
    public class Day08 : IDay
    {
        private record Vector2Int
        {
            public required int X { init; get; }
            public required int Y { init; get; }
        }

        // All directions we can do
        private Vector2Int[] directions = new Vector2Int[]
        {
            new() { X = 1, Y = 0 },
            new() { X = -1, Y = 0 },
            new() { X = 0, Y = 1 },
            new() { X = 0, Y = -1 }
        };

        private static bool IsLineOkay(int x, int y, int value, Vector2Int dir, int[][] map, out int itCount)
        {
            itCount = 0;

            var dx = dir.X;
            var dy = dir.Y;
            do
            {
                itCount++;
                if (map[y + dy][x + dx] >= value)
                {
                    // Found a tree bigger, the line isn't good
                    return false;
                }

                dx += dir.X;
                dy += dir.Y;

                // While we are still in bounds
            } while (y + dy >= 0 && x + dx >= 0 && y + dy < map.Length && x + dx < map[y + dy].Length);
            return true;
        }

        // Convert the input to a int[][] that represent the map
        private static int[][] ParseInput(string input)
            => input.Split('\n').Select(y => y.ToCharArray().Select(x => x - '0').ToArray()).ToArray();

        public string Part1(string input)
        {
            var map = ParseInput(input);

            var visibleTreesCount = (map.Length * 2) + (map[0].Length * 2) - 4; // Trees on the border

            for (var y = 1; y < map.Length - 1; y++)
            {
                for (var x = 1; x < map[y].Length - 1; x++)
                {
                    foreach (var dir in directions)
                    {
                        // If a direction is valid we add the tree as a visible one and go to the next one
                        if (IsLineOkay(x, y, map[y][x], dir, map, out _))
                        {
                            visibleTreesCount++;
                            break;
                        }
                    }
                }
            }

            return visibleTreesCount.ToString();
        }

        public string Part2(string input)
        {
            var map = ParseInput(input);

            var bestScore = 0;

            for (var y = 1; y < map.Length - 1; y++)
            {
                for (var x = 1; x < map[y].Length - 1; x++)
                {
                    var score = 1;
                    foreach (var dir in directions)
                    {
                        IsLineOkay(x, y, map[y][x], dir, map, out int mult);
                        score *= mult;
                    }
                    if (score > bestScore)
                    {
                        bestScore = score;
                    }
                }
            }

            return bestScore.ToString();
        }
    }
}
