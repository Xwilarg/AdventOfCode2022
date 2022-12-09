namespace AdventOfCode2022.Day
{
    public class Day09 : IDay
    {
        private record Vector2Int
        {
            public required int X { init; get; }
            public required int Y { init; get; }

            public float Distance(Vector2Int o)
            {
                return (float)Math.Sqrt(Math.Pow(X - o.X, 2) + Math.Pow(Y - o.Y, 2));
            }
        }

        private static Vector2Int GetRelativePosition(Vector2Int v1, Vector2Int v2)
        {
            var x = 0;
            var y = 0;

            if (v1.X > v2.X) x = 1;
            else if (v1.X < v2.X) x = -1;

            if (v1.Y > v2.Y) y = 1;
            else if (v1.Y < v2.Y) y = -1;

            return new Vector2Int() { X = x, Y = y };
        }

        private static int Simulate(string input, int snakeLength)
        {

            var head = new Vector2Int() { X = 0, Y = 0 };

            List<Vector2Int> snake = new();
            for (var i = 0; i < snakeLength; i++)
            {
                snake.Add(new() { X = 0, Y = 0 });
            }
            List<Vector2Int> visited = new()
            {
                new() { X = 0, Y = 0 }
            };

            foreach (var line in input.Split('\n'))
            {
                // Direction the head is going
                var dir = line[0] switch
                {
                    'U' => new Vector2Int() { X = 0, Y = 1 },
                    'D' => new Vector2Int() { X = 0, Y = -1 },
                    'R' => new Vector2Int() { X = 1, Y = 0 },
                    'L' => new Vector2Int() { X = -1, Y = 0 },
                    _ => throw new()
                };
                // Number of steps we are going
                var len = int.Parse(string.Join("", line.Skip(2)));

                for (int i = 0; i < len; i++)
                {
                    head = new Vector2Int() { X = head.X + dir.X, Y = head.Y + dir.Y };

                    for (var ti = 0; ti < snake.Count; ti++)
                    {
                        var previous = ti == 0 ? head : snake[ti - 1];

                        // The tail is too far from the previous element
                        if (previous.Distance(snake[ti]) > Math.Sqrt(2))
                        {
                            var relativeDir = GetRelativePosition(previous, snake[ti]);

                            snake[ti] = new() { X = snake[ti].X + relativeDir.X, Y = snake[ti].Y + relativeDir.Y };
                        }
                    }
                    if (!visited.Any(v => v.X == snake[^1].X && v.Y == snake[^1].Y))
                    {
                        visited.Add(snake[^1]);
                    }
                }
            }

            return visited.Count;
        }

        public string Part1(string input)
        {
            return Simulate(input, 1).ToString();
        }

        public string Part2(string input)
        {
            return Simulate(input, 10).ToString();
        }
    }
}
