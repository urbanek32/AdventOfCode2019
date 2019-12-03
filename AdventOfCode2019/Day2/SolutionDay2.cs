using System;
using System.IO;
using System.Linq;

namespace AdventOfCode2019.Day2
{
    public class SolutionDay2
    {
        private static int[] _input = File.ReadAllText("Day2/input.txt").Split(",").Select(int.Parse).ToArray();

        private int CalculateOpcode(int[] input, int noun, int verb)
        {
            input[1] = noun;
            input[2] = verb;

            for (var i = 0; i < input.Length; i += 4)
            {
                var opcode = input[i];
                switch (opcode)
                {
                    case 99: // halt
                        break;
                    case 1: // +
                        var a_plus = input[input[i + 1]];
                        var b_plus = input[input[i + 2]];
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
            
            return input[0];
        }

        public void RunSolution1()
        {
            var input = File.ReadAllText("Day2/input.txt").Split(",").Select(int.Parse).ToArray();
            
            var answer = CalculateOpcode(input, 12, 2);
            Console.WriteLine($"Result: {answer}");
        }

        public void RunSolution2()
        {
            for (var noun = 0; noun <= 99; noun++)
            {
                for (var verb = 0; verb <= 99; verb++)
                {
                    var input = _input.Clone() as int[];
                    var answer = CalculateOpcode(input, noun, verb);
                    if (answer == 19690720)
                    {
                        Console.WriteLine($"Result: {100 * noun + verb}");
                        break;
                    }
                }
            }

        }
    }
}
