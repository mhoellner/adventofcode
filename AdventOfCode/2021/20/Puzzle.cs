using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2021._20
{
    public class Puzzle : IPuzzle
    {
        private readonly int _target;

        public Puzzle(int target = 2)
        {
            _target = target;
        }

        public long Resolve(List<string> inputs)
        {
            var filter = inputs[0];

            var image = new string[inputs.Count + 2][];
            for (var indexX = 0; indexX < inputs.Count + 2; indexX++)
            for (var indexY = 0; indexY < inputs[2].Length + 4; indexY++)
            {
                image[indexX] ??= new string[inputs[2].Length + 4];
                image[indexX][indexY] = "0";
            }
            
            for (var indexX = 2; indexX < inputs.Count; indexX++)
            for (var indexY = 0; indexY < inputs[2].Length; indexY++)
                if (inputs[indexX][indexY] == '#')
                    image[indexX][indexY + 2] = "1";

            for (var counter = 0; counter < _target; counter++)
            {
                image = EnhanceImage(image, filter, counter);
            }

            return image.Sum(row => row.Count(s => s == "1"));
        }

        private static string[][] EnhanceImage(string[][] image, string filter, int counter)
        {
            var useHash = filter.StartsWith("#") && counter % 2 == 0;
            var nextImage = new string[image.Length + 4][];
            for (var indexX = 0; indexX < image.Length + 4; indexX++)
            for (var indexY = 0; indexY < image[0].Length + 4; indexY++)
            {
                nextImage[indexX] ??= new string[image[0].Length + 4];
                nextImage[indexX][indexY] = useHash ? "1" : "0";
            }
            
            for (var indexX = 1; indexX < image.Length - 1; indexX++)
            for (var indexY = 1; indexY < image[0].Length - 1; indexY++)
            {
                var startY = indexY - 1;
                var endY = indexY + 2;
                var s = string.Join("", image[indexX - 1][startY..endY]) +
                        string.Join("", image[indexX][startY..endY]) +
                        string.Join("", image[indexX + 1][startY..endY]);
                var index = Convert.ToInt32(s, 2);
                nextImage[indexX + 2][indexY + 2] = filter[index] == '#' ? "1" : "0";
            }

            return nextImage;
        }
    }
}