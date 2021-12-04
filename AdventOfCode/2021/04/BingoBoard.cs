using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode._2021._04
{
    public class BingoBoard
    {
        private readonly Field[][] _fields;
        private int _lastFound = -1;

        public BingoBoard(List<List<int>> rows)
        {
            _fields = rows.Select(r => r.Select(f => new Field(f)).ToArray()).ToArray();
        }

        public bool PlayNext(int next)
        {
            var isChecked = MarkChecked(next);
            return isChecked && HasBingo();
        }

        private bool MarkChecked(int next)
        {
            foreach (var row in _fields)
            foreach (var field in row)
                if (field.Value == next)
                {
                    field.IsChecked = true;
                    _lastFound = next;
                    return true;
                }

            return false;
        }

        private bool HasBingo()
        {
            return HasHorizontalBingo() || HasVerticalBingo();
        }

        private bool HasHorizontalBingo()
        {
            foreach (var row in _fields)
            {
                var count = 0;
                foreach (var field in row)
                    if (field.IsChecked)
                        count++;
                    else break;

                if (count == 5)
                    return true;
            }

            return false;
        }

        private bool HasVerticalBingo()
        {
            for (var i = 0; i < _fields[0].Length; i++)
            {
                var count = 0;
                foreach (var row in _fields)
                {
                    var field = row[i];
                    if (field.IsChecked)
                        count++;
                    else break;
                }

                if (count == 5)
                    return true;
            }

            return false;
        }

        public long GetResult()
        {
            long sum = 0;
            foreach (var row in _fields)
            foreach (var field in row)
                if (!field.IsChecked)
                    sum += field.Value;

            return sum * _lastFound;
        }

        private class Field
        {
            public Field(int value)
            {
                Value = value;
            }

            public int Value { get; }
            public bool IsChecked { get; set; }
        }
    }
}