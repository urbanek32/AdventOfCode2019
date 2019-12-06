using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2019.Day6
{
    public class SolutionDay6
    {
        private static Dictionary<string, string> _orbits;
        public void RunSolution1()
        {
            _orbits = File.ReadAllLines("Day6/input.txt")
                .Select(l => l.Split(")"))
                .ToDictionary(s => s[1], s => s[0]);

            var sum = _orbits
                .Select(o => o.Value)
                .Sum(GetDepth);

            Console.WriteLine($"Answer: {sum}");
        }

        private static int GetDepth(string parent)
        {
            if (_orbits.TryGetValue(parent, out var orbiter))
            {
                return GetDepth(orbiter) + 1;
            }

            return 1;
        }

        public void RunSolution2()
        {
            _orbits = File.ReadAllLines("Day6/input.txt")
                .Select(l => l.Split(")"))
                .ToDictionary(s => s[1], s => s[0]);

            var youObject = "YOU";
            var santaObject = "SAN";
            var youChain = new List<string>();
            var santaChain = new List<string>();

            while (youObject != "COM")
            {
                youChain.Add(_orbits[youObject]);
                youObject = _orbits[youObject];
            }

            while (santaObject != "COM")
            {
                santaChain.Add(_orbits[santaObject]);
                santaObject = _orbits[santaObject];
            }

            var commonObjects = youChain
                .Except(santaChain)
                .Union(santaChain.Except(youChain));

            Console.WriteLine($"Answer: {commonObjects.Count()}");
        }
    }
}
