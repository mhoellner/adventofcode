using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2021._16
{
    public static class BitsParser
    {
        public static Packet FindPackets(List<string> inputs)
        {
            var hex = inputs[0];
            var binary = string.Join(string.Empty,
                hex.Select(c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')));
            var index = 0;
            var max = binary.Length - 10;
            Operator parent = null;
            while (index < max)
            {
                var versionEnd = index + 3;
                var version = Convert.ToInt32(binary[index..versionEnd], 2);
                var typeEnd = index + 6;
                var type = Convert.ToInt32(binary[versionEnd..typeEnd], 2);
                if (type == 4)
                {
                    var valueStr = string.Empty;
                    index = typeEnd;
                    var isLast = false;
                    while (!isLast)
                    {
                        if (binary[index] == '0')
                            isLast = true;
                        valueStr += binary.Substring(index + 1, 4);
                        index += 5;
                    }

                    var value = Convert.ToInt64(valueStr, 2);
                    var literal = new Literal(version, type, value, valueStr.Length + valueStr.Length / 4);
                    if (parent != null)
                    {
                        while (parent != null && !parent.CanAdd())
                            parent = parent.Parent;
                        if (parent != null)
                            parent.Children.Add(literal);
                    }
                }
                else
                {
                    var lengthType = binary[typeEnd] == '1';
                    Operator packet;
                    if (lengthType)
                    {
                        var numberOfSubPackets = Convert.ToInt32(binary.Substring(typeEnd + 1, 11), 2);
                        packet = new Operator(version, type, lengthType, numberOfSubPackets);
                        index += 18;
                    }
                    else
                    {
                        var totalLength = Convert.ToInt32(binary.Substring(typeEnd + 1, 15), 2);
                        packet = new Operator(version, type, lengthType, totalLength);
                        index += 22;
                    }
                    if (parent != null)
                    {
                        while (parent != null && !parent.CanAdd())
                            parent = parent.Parent;
                        if (parent != null)
                        {
                            parent.Children.Add(packet);
                            packet.SetParent(parent);
                            parent = packet;
                        }
                    }
                    else
                    {
                        parent = packet;
                    }
                }
            }

            var result = parent;
            while (result?.Parent != null)
                result = result.Parent;
            
            return result;
        }
    }
}