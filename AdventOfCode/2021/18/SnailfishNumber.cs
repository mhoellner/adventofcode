using System;
using Xunit.Abstractions;

namespace AdventOfCode._2021._18
{
    public class SnailfishNumber
    {
        private SnailfishNumber Parent { get; set; }
        private SnailfishNumber Left { get; set; }
        private SnailfishNumber Right { get; set; }
        private int? LeftValue { get; set; }
        private int? RightValue { get; set; }

        private SnailfishNumber() { }

        private SnailfishNumber(int value)
        {
            LeftValue = Convert.ToInt32(Math.Floor(value / 2.0));
            RightValue = Convert.ToInt32(Math.Ceiling(value / 2.0));
        }

        public SnailfishNumber(SnailfishNumber left, SnailfishNumber right)
        {
            Left = left;
            Right = right;
        }

        public SnailfishNumber SetParent(SnailfishNumber parent)
        {
            Parent = parent;

            return this;
        }

        private void Reduce(ITestOutputHelper outputHelper)
        {
            var hasSplit = true;
            while (hasSplit)
            {
                var hasExploded = true;
                while (hasExploded)
                {
                    hasExploded = TryExplode(0);
                    if (hasExploded) outputHelper?.WriteLine($"Explode: {this}");
                }

                hasSplit = TrySplit();
                if (hasSplit) outputHelper?.WriteLine($"Split:{this}");
            }
            
            outputHelper?.WriteLine($"Result: {this}");
        }

        private bool TryExplode(int depth)
        {
            if (depth == 4)
            {
                TryAddLeftValue(LeftValue!.Value);
                TryAddRightValue(RightValue!.Value);
                if (Parent.Left == this)
                {
                    Parent.LeftValue = 0;
                    Parent.Left = null;
                }

                if (Parent.Right == this)
                {
                    Parent.RightValue = 0;
                    Parent.Right = null;
                }
                
                return true;
            }

            return Left?.TryExplode(depth + 1) == true || Right?.TryExplode(depth + 1) == true;
        }

        private void TryAddLeftValue(int value)
        {
            var previous = this;
            var current = Parent;

            while (current.Left == previous)
            {
                if (current.Parent == null)
                    return;
                previous = current;
                current = current.Parent;
            }

            if (current.Left == null)
            {
                current.LeftValue += value;
                return;
            }

            current = current.Left;
            while (current.Right != null)
            {
                current = current.Right;
            }

            current.RightValue += value;
        }

        private void TryAddRightValue(int value)
        {
            var previous = this;
            var current = Parent;

            while (current.Right == previous)
            {
                if (current.Parent == null)
                    return;
                previous = current;
                current = current.Parent;
            }

            if (current.Right == null)
            {
                current.RightValue += value;
                return;
            }

            current = current.Right;
            while (current.Left != null)
            {
                current = current.Left;
            }

            current.LeftValue += value;
        }

        private bool TrySplit()
        {
            if (LeftValue > 9)
            {
                Left = new SnailfishNumber(LeftValue.Value).SetParent(this);
                LeftValue = null;
                
                return true;
            }

            if (Left?.TrySplit() == true) return true;

            if (RightValue > 9)
            {
                Right = new SnailfishNumber(RightValue.Value).SetParent(this);
                RightValue = null;
                
                return true;
            }

            return Right?.TrySplit() == true;
        }

        public int CalculateMagnitude()
        {
            var left = LeftValue ?? Left.CalculateMagnitude();
            var right = RightValue ?? Right.CalculateMagnitude();

            return 3 * left + 2 * right;
        }

        public static SnailfishNumber Add(SnailfishNumber left, SnailfishNumber right, ITestOutputHelper outputHelper = null)
        {
            var snailfishNumber = left == null ? right : new SnailfishNumber(left, right);
            if (left != null)
            {
                left.SetParent(snailfishNumber);
                right.SetParent(snailfishNumber);
            }

            snailfishNumber.Reduce(outputHelper);

            return snailfishNumber;
        }

        public static SnailfishNumber Parse(string s)
        {
            SnailfishNumber result = null;
            for (var index = 0; index < s.Length; index++)
            {
                if (s[index] == '[')
                {
                    if (result == null)
                        result = new SnailfishNumber();
                    else
                    {
                        result = new SnailfishNumber().SetParent(result);
                        if (result.Parent.Left == null && result.Parent.LeftValue.HasValue == false)
                            result.Parent.Left = result;
                        else
                            result.Parent.Right = result;
                    }
                }
                else if (s[index] == ']')
                {
                    if (result?.Parent != null)
                        result = result.Parent;
                }
                else if ("0123456789".Contains(s[index]))
                {
                    var value = int.Parse(s[index].ToString());
                    if (result!.Left == null && result.LeftValue.HasValue == false)
                        result!.LeftValue = value;
                    else
                        result!.RightValue = value;
                }
            }
            
            return result;
        }

        public override string ToString()
        {
            var left = Left != null ? Left.ToString() : LeftValue.ToString();
            var right = Right != null ? Right.ToString() : RightValue.ToString();

            return $"[{left},{right}]";
        }
    }
}