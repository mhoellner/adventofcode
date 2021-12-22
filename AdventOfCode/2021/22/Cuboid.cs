using System;

namespace AdventOfCode._2021._22
{
    public class Cuboid
    {
        public bool On { get; }
        private int MinX { get; }
        private int MaxX { get; }
        private int MinY { get; }
        private int MaxY { get; }
        private int MinZ { get; }
        private int MaxZ { get; }

        public Cuboid(int[] array, bool on)
        {
            On = on;
            MinX = array[0];
            MaxX = array[1];
            MinY = array[2];
            MaxY = array[3];
            MinZ = array[4];
            MaxZ = array[5];
        }

        public bool IsSmall()
        {
            return MinX >= -50 && MaxX <= 50 &&
                   MinY >= -50 && MaxY <= 50 &&
                   MinZ >= -50 && MaxZ <= 50;
        }

        public long CalculateVolume()
        {
            return (MaxX - MinX + 1L) * (MaxY - MinY + 1L) * (MaxZ - MinZ + 1L) * (On ? 1 : -1);
        }

        public static Cuboid Intersect(Cuboid c1, Cuboid c2)
        {
            if (c1.MinX > c2.MaxX || c1.MaxX < c2.MinX ||
                c1.MinY > c2.MaxY || c1.MaxY < c2.MinY ||
                c1.MinZ > c2.MaxZ || c1.MaxZ < c2.MinZ)
                return null;

            return new Cuboid(new[]
                {
                    Math.Max(c1.MinX, c2.MinX),
                    Math.Min(c1.MaxX, c2.MaxX),
                    Math.Max(c1.MinY, c2.MinY),
                    Math.Min(c1.MaxY, c2.MaxY),
                    Math.Max(c1.MinZ, c2.MinZ),
                    Math.Min(c1.MaxZ, c2.MaxZ)
                },
                !c1.On
            );

        }
    }
}