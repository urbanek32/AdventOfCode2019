using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2019.Day5
{
    public class SolutionDay5
    {
        public void RunSolution1()
        {
            var input = File.ReadAllText("Day5/input.txt")
                .Split(",")
                .Select(int.Parse);

            var computer = new PowerPC();
            Console.WriteLine($"Answer: {computer.Run(input, 1)}");
        }

        public void RunSolution2()
        {
            var input = File.ReadAllText("Day5/input.txt")
                .Split(",")
                .Select(int.Parse);

            var computer = new PowerPC();
            Console.WriteLine($"Answer: {computer.Run(input, 5)}");
        }
    }
}
