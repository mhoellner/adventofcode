using System;
using System.Diagnostics;

namespace AdventOfCode._2021._12
{
    [DebuggerDisplay("Name: {Name}, IsSmall: {IsSmall}", Name = "Cave")]
    public struct Cave
    {
        public Cave(string name)
        {
            Name = name;
            IsSmall = name == name.ToLower();
        }
        
        public string Name { get; }
        public bool IsSmall { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Cave other && Equals(other);
        }

        public bool Equals(Cave other)
        {
            return Name == other.Name && IsSmall == other.IsSmall;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, IsSmall);
        }
    }
}