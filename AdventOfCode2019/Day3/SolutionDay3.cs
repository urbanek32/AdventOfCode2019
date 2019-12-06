using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2019.Day3
{
    public class SolutionDay3
    {
        public class Point
        {
            public int X { get; set; }
            public int Y { get; set; }

            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }

            public IEnumerable<Point> CreateSegment(string seg)
            {
                Func<int, Point> newPoint;
                switch (seg[0])
                {
                    case 'R':
                        newPoint = i => new Point(X+ i, Y);
                        break;
                    case 'L':
                        newPoint = i => new Point(X - i, Y);
                        break;
                    case 'U':
                        newPoint = i => new Point(X, Y + i);
                        break;
                    case 'D':
                        newPoint = i => new Point(X, Y - i);
                        break;
                    default:
                        newPoint = i => this;
                        break;
                }

                var steps = int.Parse(seg.Substring(1));
                var segment = new List<Point>(steps);
                for (var i = 1; i <= steps; i++)
                {
                    segment.Add(newPoint.Invoke(i));
                }

                return segment;
            }

            public override bool Equals(object obj)
            {
                return obj is Point point &&
                       X == point.X &&
                       Y == point.Y;
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(X, Y);
            }
        }

        public void RunSolution1()
        {
            //var input = File.ReadAllLines("Day3/input.txt");
            var input = new[] { "R75,D30,R83,U83,L12,D49,R71,U7,L72", "U62,R66,U55,R34,D71,R55,D58,R83" };
            //var input = new[] { "R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51", "U98,R91,D20,R16,D67,R40,U7,R15,U6,R7" };
            var pointsOfWires = new List<Dictionary<Point, int>>
            {
                new Dictionary<Point, int>(), // wire 1
                new Dictionary<Point, int>() // wire 2
            };

            for (var i = 0; i < pointsOfWires.Count; i++)
            {
                var wirePoints = pointsOfWires[i];
                var startingPoint = new Point(0, 0);
                var steps = 0;
                foreach (var segments in input[i].Split(","))
                {
                    foreach (var l in startingPoint.CreateSegment(segments))
                    {
                        wirePoints.TryAdd(l, steps++);
                        startingPoint = l;
                    }
                }
            }

            var intersectingPoints = new HashSet<Point>(pointsOfWires[0].Keys);
            intersectingPoints.IntersectWith(pointsOfWires[1].Keys);

            var closesDistance = intersectingPoints
                .Select(p => Math.Abs(p.X) + Math.Abs(p.Y))
                .OrderBy(p => p)
                .First();

            Console.WriteLine($"closesDistance: {closesDistance}");

            var fewestSteps = intersectingPoints
                .Select(p => pointsOfWires[0][p] + pointsOfWires[1][p])
                .OrderBy(p => p)
                .First();

            Console.WriteLine($"fewestSteps: {fewestSteps}");
        }

        public void RunSolution2()
        {
            
        }
    }
}
