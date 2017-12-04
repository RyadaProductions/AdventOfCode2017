using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3 {
    class Program {
        static void Main(string[] args)
        {
            //17  16  15  14  13
            //18   5   4   3  12
            //19   6   1   2  11
            //20   7   8   9  10
            //21  22  23---> ...
            // 23 sqrt = 4.7
            // 4.7 ceiling = 5
            // 5 / 2 ceiling = 3 columns/rows from center
            Console.Write("Enter n: " + Environment.NewLine);
            var maxNumber = Convert.ToInt32(Console.ReadLine());
            var input = Convert.ToInt32(Math.Ceiling(Math.Sqrt(maxNumber)));
            var matrix = new int[input + 1, input + 1];
            var row = Convert.ToInt32(Math.Ceiling((double)input / 2));
            var column = Convert.ToInt32(Math.Ceiling((double)input / 2));
            var originrow = Convert.ToInt32(Math.Ceiling((double)input / 2));
            var origincolumn = Convert.ToInt32(Math.Ceiling((double)input / 2));
            var currentNumber = 1;
            var amount = 1;

            while (currentNumber <= maxNumber)
            {
                // move right
                for (int i = 0; i < amount; i++)
                {
                    matrix[row, column] = currentNumber;
                    currentNumber++;
                    column++;
                }

                if (currentNumber > maxNumber) break;

                // move up
                for (int i = 0; i < amount; i++)
                {
                    matrix[row, column] = currentNumber;
                    currentNumber++;
                    row--;
                }
                amount++;

                if (currentNumber > maxNumber) break;

                // move left
                for (int i = 0; i < amount; i++)
                {
                    matrix[row, column] = currentNumber;
                    currentNumber++;
                    column--;
                }

                if (currentNumber > maxNumber) break;

                // move down
                for (int i = 0; i < amount; i++)
                {
                    matrix[row, column] = currentNumber;
                    currentNumber++;
                    row++;
                }
                amount++;
            };

            //Display Matrix

            for (int r = 0; r < input; r++)
            {
                for (int c = 0; c < input; c++)
                {
                    Console.Write("{0,4}", matrix[r, c]);
                }
                Console.WriteLine();
            }
            Console.ReadLine();

            int w = matrix.GetLength(0); // width
            int h = matrix.GetLength(1); // height

            var coordinate = Tuple.Create(-1, -1);

            for (int x = 0; x < w; ++x)
            {
                for (int y = 0; y < h; ++y)
                {
                    if (matrix[x, y].Equals(maxNumber))
                        Tuple.Create(x, y);
                }
            }

            var stepsToCenter = coordinate.Item1 - originrow;
            var stepsToCenter2 = coordinate.Item2 - origincolumn;

            var totalsteps = stepsToCenter + stepsToCenter2;

            Console.WriteLine("Distance: " + totalsteps);
            Console.ReadLine();
        }
    }
}
