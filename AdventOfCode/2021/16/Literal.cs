namespace AdventOfCode._2021._16
{
    public class Literal : Packet
    {
        public Literal(int version, int type, long value, long packetLength) : base(version, type)
        {
            Value = value;
            _packetLength = packetLength;
        }
        
        public long Value { get; }
        private readonly long _packetLength;

        public override long Calculate()
        {
            return Value;
        }

        public override long GetPacketLength()
        {
            return _packetLength + 6;
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public override long SumVersions()
        {
            return Version;
        }
    }
}