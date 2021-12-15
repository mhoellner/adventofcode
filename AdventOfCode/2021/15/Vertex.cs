namespace AdventOfCode._2021._15
{
    public class Vertex
    {
        public int X { get; }
        public int Y { get; }
        public int Value { get; }
        public int Distance { get; set; }

        public Vertex(int x, int y, int value)
        {
            X = x;
            Y = y;
            Value = value;
            Distance = int.MaxValue;
        }
    }
}