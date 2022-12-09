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

        public string Part1(string input)
        {
            var head = new Vector2Int() { X = 0, Y = 0 };
            var tail = new Vector2Int() { X = 0, Y = 0 };

            List<Vector2Int> visited = new()
            {
                tail
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

                    // The tail is too far from the head
                    if (head.Distance(tail) > Math.Sqrt(2))
                    {
                        var relativeDir = GetRelativePosition(head, tail);

                        tail = new Vector2Int() { X = tail.X + relativeDir.X, Y = tail.Y + relativeDir.Y };
                        if (!visited.Any(v => v.X == tail.X && v.Y == tail.Y))
                        {
                            visited.Add(tail);
                        }
                    }
                }
            }

            return visited.Count.ToString();
        }

        public string Part2(string input)
        {
            return string.Empty;
        }
    }
}
