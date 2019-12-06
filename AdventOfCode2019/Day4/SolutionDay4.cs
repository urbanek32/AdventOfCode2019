using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2019.Day4
{
    public class SolutionDay4
    {
        public void RunSolution1()
        {
            var input = "356261-846303".Split("-").Select(int.Parse).ToArray();
            var amount = 0;
            for(var i = input[0]; i <= input[1]; i++)
            {
                var stringValue = i.ToString("D");
                if (MeetCriteria_DoubleDigits(stringValue) && MeetCriteria_NeverDecrease(stringValue))
                {
                    amount++;
                }
            }
            
            Console.WriteLine($"Answer: {amount}");
        }

        private bool MeetCriteria_DoubleDigits(string value)
        {
            for (var i = 0; i < value.Length - 1; i++)
            {
                if (value[i] == value[i + 1])
                {
                    return true;
                }
            }

            return false;
        }

        private bool MeetCriteria_NeverDecrease(string value)
        {
            for (var i = 0; i < value.Length - 1; i++)
            {
                if (value[i] > value[i + 1])
                {
                    return false;
                }
            }

            return true;
        }

        private bool MeetCriteria_OnlyDoubleDigits(string value)
        {
            return value
                .GroupBy(c => c)
                .Any(g => g.Count() == 2);
        }

        public void RunSolution2()
        {
            var input = "356261-846303".Split("-").Select(int.Parse).ToArray();
            var amount = 0;
            for (var i = input[0]; i <= input[1]; i++)
            {
                var stringValue = i.ToString("D");
                if (MeetCriteria_OnlyDoubleDigits(stringValue) && MeetCriteria_NeverDecrease(stringValue))
                {
                    amount++;
                }
            }

            Console.WriteLine($"Answer: {amount}");
        }
    }
}
