using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AdventOfCode._2021._16
{
    public class Operator : Packet
    {
        public Operator(int version, int type, bool lengthType, int length) : base(version, type)
        {
            LengthType = lengthType;
            Length = length;
        }
        
        public bool LengthType { get; }
        public int Length { get; }
        public List<Packet> Children { get; } = new List<Packet>();

        public override long Calculate()
        {
            var result = Type switch
            {
                0 => Children.Aggregate(0L, (value, packet) => value + packet.Calculate()),
                1 => Children.Aggregate(1L, (value, packet) => value * packet.Calculate()),
                2 => Children.Min(p => p.Calculate()),
                3 => Children.Max(p => p.Calculate()),
                5 => Children[0].Calculate() > Children[1].Calculate() ? 1L : 0L,
                6 => Children[0].Calculate() < Children[1].Calculate() ? 1L : 0L,
                7 => Children[0].Calculate() == Children[1].Calculate() ? 1L : 0L,
                _ => throw new UnreachableException("This should not happen.")
            };

            return result;
        }

        public override long GetPacketLength()
        {
            var length = LengthType ? 11 : 15;
            if (LengthType)
                return Children.Sum(p => p.GetPacketLength()) + 7 + length;
            return Length + 7 + length;
        }

        public bool CanAdd()
        {
            if (LengthType && Children.Count < Length)
                return true;
            if (!LengthType && Children.Sum(p => p.GetPacketLength()) < Length)
                return true;
            return false;
        }

        public void SetParent(Operator parent)
        {
            Parent = parent;
        }

        public override string ToString()
        {
            var op = Type switch
            {
                0 => $"({string.Join(" + ", Children)})",
                1 => $"({string.Join(" * ", Children)})",
                2 => $"min({string.Join(", ", Children)})",
                3 => $"max({string.Join(", ", Children)})",
                5 => $"({Children[0]} > {Children[1]})",
                6 => $"({Children[0]} < {Children[1]})",
                7 => $"({Children[0]} == {Children[1]})",
                _ => throw new UnreachableException("This should not happen.")
            };
            return op;
        }

        public override long SumVersions()
        {
            return Version + Children.Sum(p => p.SumVersions());
        }
    }
}