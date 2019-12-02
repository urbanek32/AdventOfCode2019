using System;
using System.IO;
using System.Linq;

namespace AdventOfCode2019.Day2
{
    public class SolutionDay2
    {
        public void RunSolution1()
        {
            var input = File.ReadAllText("Day2/input.txt").Split(",").Select(int.Parse).ToArray();
            //var input = "1,1,1,4,99,5,6,0,99".Split(",").Select(int.Parse).ToArray();
            for (var i = 0; i < input.Length; i+=4)
            {
                var opcode = input[i];
                switch (opcode)
                {
                    case 99: // halt
                        Console.WriteLine("Opcode: 99");
                        break;
                    case 1: // +
                        var a_plus = input[input[i+1]];
                        var b_plus = input[input[i+2]];
                        input[input[i + 3]] = a_plus + b_plus;
                        break;
                    case 2: // *
                        var a_mul = input[input[i + 1]];
                        var b_mul = input[input[i + 2]];
                        input[input[i + 3]] = a_mul * b_mul;
                        break;
                    default:
                        continue;
                }
            }

            Console.WriteLine($"Result: {input[0]}");
            Console.WriteLine(string.Join(",", input));
        }

        public void RunSolution2()
        {
            var input = File.ReadAllLines("Day1/input.txt").Select(int.Parse);
            //var input = new[] { 100756 };
            var total = 0;
            foreach (var mass in input)
            {
                var currentMass = mass;
                do
                {
                    var fuel = currentMass / 3 - 2;
                    if (fuel <= 0)
                    {
                        break;
                    }
                    total += fuel;
                    currentMass = fuel;
                }
                while (true);
            }

            Console.WriteLine(total);
        }
    }
}
