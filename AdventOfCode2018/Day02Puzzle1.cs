using System;
using System.Linq;

namespace AdventOfCode2018
{
    class Day02Puzzle1
    {
        public static string Solve(params string[] inputs)
        {
            var input = inputs[0];
            var boxIds = input.Split(new string[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);

            var exactlyTwice = boxIds.Count(id => id.GroupBy(c => c).Any(g => g.Count() == 2));
            var exactlyThrice = boxIds.Count(id => id.GroupBy(c => c).Any(g => g.Count() == 3));

            return (exactlyTwice * exactlyThrice).ToString();
        }
    }
}
