namespace AdventOfCode2022.Day
{
    public class Day08 : IDay
    {
        private record Vector2Int
        {
            public required int X { init; get; }
            public required int Y { init; get; }
        }

        private static bool IsLineOkay(int x, int y, int value, Vector2Int dir, int[][] map)
        {
            var dx = dir.X;
            var dy = dir.Y;
            do
            {
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

        public string Part1(string input)
        {
            // Convert the input to a int[][] that represent the map
            var map = input.Split('\n').Select(y => y.ToCharArray().Select(x => x - '0').ToArray()).ToArray();

            // All directions we can do
            var directions = new[]
            {
                new Vector2Int() { X = 1, Y = 0 },
                new Vector2Int() { X = -1, Y = 0 },
                new Vector2Int() { X = 0, Y = 1 },
                new Vector2Int() { X = 0, Y = -1 }
            };

            var visibleTreesCount = (map.Length * 2) + (map[0].Length * 2) - 4; // Trees on the border

            for (var y = 1; y < map.Length - 1; y++)
            {
                for (var x = 1; x < map[y].Length - 1; x++)
                {
                    foreach (var dir in directions)
                    {
                        // If a direction is valid we add the tree as a visible one and go to the next one
                        if (IsLineOkay(x, y, map[y][x], dir, map))
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
            return string.Empty;
        }
    }
}
