using System;
using System.Diagnostics;

namespace AdventOfCode._2021._13
{
    [DebuggerDisplay("X={X} Y={Y}")]
    public class Position
    {
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }
        
        public int X { get; private set; }
        public int Y { get; private set; }

        public void FoldX(int x)
        {
            if (X > x) X = X - (2 * (X - x));
        }

        public void FoldY(int y)
        {
            if (Y > y) Y = Y - (2 * (Y - y));
        }

        public override bool Equals(object obj)
        {
            return obj is Position other && Equals(other);
        }

        public bool Equals(Position other)
        {
            return X == other.X && Y == other.Y;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }
    }
}