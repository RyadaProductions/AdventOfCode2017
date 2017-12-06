using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day6
{
    class Program
    {
        private const string _input = "4	10	4	1	8	4	9	14	5	1	14	15	0	15	3	5";
        private static readonly List<string> _previoussolutions = new List<string>();
        private static int _solution, _solution2 = 0;

        static void Main(string[] args)
        {
            var array = Array.ConvertAll(_input.Split('\t'), int.Parse);

            while (!_previoussolutions.Contains(string.Join(", ", array)))
            {
                var highest = array.First(x => x == array.Max());
                var index = Array.IndexOf(array, highest);

                _previoussolutions.Add(string.Join(", ", array));

                array[index] = 0;

                for (var i = 1; i <= highest; i++)
                {
                    index++;
                    if (index >= array.Length) index = 0;

                    array[index]++;
                }
                _solution++;
            }

            var firsthit = _previoussolutions.IndexOf(string.Join(", ", array));
            _solution2 = _solution - firsthit;

            Console.WriteLine($"Amount of cycles: {_solution}");
            Console.WriteLine($"Cycles before reappearing: {_solution2}");
        }
    }
}
