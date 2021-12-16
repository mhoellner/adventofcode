namespace AdventOfCode._2021._16
{
    public abstract class Packet
    {
        protected Packet(int version, int type)
        {
            Version = version;
            Type = type;
        }

        public int Version { get; }
        public int Type { get; }
        public Operator Parent { get; protected set; }

        public abstract long Calculate();
        public abstract long GetPacketLength();
        public abstract long SumVersions();
    }
}