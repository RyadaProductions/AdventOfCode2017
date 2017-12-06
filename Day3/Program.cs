using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3
{
    class Program
    {
        private const int _input = 289326;
        private static int _solution, _solution2;
        private static int _row, _column;
        private static int[,] _matrix;

        static void Main(string[] args)
        {
            var side = (int)Math.Ceiling(Math.Sqrt(_input));
            if (side % 1 != 0) side--;

            var maxNumber = side * side;
            var maxNumberSmallerCircle = (side - 1) * (side - 1);
            var array = Enumerable.Range(maxNumberSmallerCircle, maxNumber).ToArray();

            var index = Array.FindIndex(array, x => x == _input);
            while (index > side) index = index - side;
            if (index > side / 2) index = index - side / 2;

            _solution = (index + side / 2);
            Console.WriteLine($"Manhattan Distance: {_solution}");

            // Part 2

            _matrix = new int[side, side];
            _row = side / 2;
            _column = side / 2;
            var amount = 1;
            var movement = Directions.Right;

            while (_solution2 <= _input)
            {
                // move Right
                for (var i = 0; i < amount && _solution2 < _input; i++)
                {
                    var value = _solution2 = GetValueOfNeighbourSum();

                    _matrix[_row, _column] = value;

                    switch (movement)
                    {
                        case Directions.Right:
                            _column++;
                            break;
                        case Directions.Up:
                            _row--;
                            break;
                        case Directions.Left:
                            _column--;
                            break;
                        case Directions.Down:
                            _row++;
                            break;
                    }
                }

                if (movement == Directions.Down) movement = Directions.Right;
                else movement++;

                if (movement == Directions.Left || movement == Directions.Right) amount++;
            };
            Console.WriteLine($"First higher value: {_solution2}");
        }

        private static int GetValueOfNeighbourSum()
        {
            var sum = _matrix[_row - 1, _column - 1] + _matrix[_row - 1, _column] + _matrix[_row - 1, _column + 1] + _matrix[_row, _column - 1] + _matrix[_row, _column + 1] + _matrix[_row + 1, _column - 1] + _matrix[_row + 1, _column] + _matrix[_row + 1, _column + 1];
            return sum != 0 ? sum : 1;
        }

        private enum Directions
        {
            Right,
            Up,
            Left,
            Down
        }
    }
}
