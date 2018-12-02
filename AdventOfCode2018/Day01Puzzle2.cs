using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2018
{
    class Day01Puzzle2
    {
        public static string Solve(params string[] inputs)
        {
            var input = inputs[0];
            var frequencyChanges = input.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList().Select(int.Parse);

            var frequencyHistory = new List<int> {0};

            while (true)
            {
                foreach (var frequencyChange in frequencyChanges)
                {
                    var newFrequency = frequencyHistory.Last() + frequencyChange;
                    if (frequencyHistory.Contains(newFrequency))
                        return newFrequency.ToString();
                    frequencyHistory.Add(newFrequency);
                }
            }
        }
    }
}
