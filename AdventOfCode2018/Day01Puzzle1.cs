using System;
using System.Linq;

namespace AdventOfCode2018
{
    public class Day01Puzzle1
    {
        public static string Solve(params string[] inputs)
        {
            var input = inputs[0];
            var frequencyChanges = input.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList().Select(int.Parse);

            var frequency = 0;

            foreach (var frequencyChange in frequencyChanges)
            {
                frequency += frequencyChange;
            }

            return frequency.ToString();
        }
    }
}
