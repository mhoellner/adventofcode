namespace AdventOfCode._2021._09
{
    public readonly struct Point
    {
        public int X { get; }
        public int Y { get; }
        public int Value { get; }

        public Point(int x, int y, int value)
        {
            X = x;
            Y = y;
            Value = value;
        }
    }
}