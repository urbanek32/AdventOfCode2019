using System;
using System.IO;
using System.Linq;

namespace AdventOfCode2019.Day1
{
    public class SolutionDay1
    {
        public void RunSolution1()
        {
            var input = File.ReadAllLines("Day1/input.txt").Select(int.Parse);
            var total = input.Sum(mass => mass / 3 - 2);
            Console.WriteLine(total);
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
