using System;
using System.Linq;

namespace AdventOfCode2018
{
    class Day02Puzzle2
    {
        public static string Solve(params string[] inputs)
        {
            var input = inputs[0];
            var boxIds = input.Split(new string[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);

            for (var i = 0; i < boxIds.Count(); i++)
            for (var j = 0; j < i; j++)
                if (TryMatch(boxIds[i], boxIds[j], out var common))
                    return common;

            return null;
        }

        private static bool TryMatch(string first, string second, out string common)
        {
            var diffIndex = -1;
            common = null;

            for (var i = 0; i < first.Length; i++)
            {
                if (first[i] != second[i])
                {
                    if (diffIndex >= 0) return false;
                    diffIndex = i;
                }
            }

            if (diffIndex < 0) return false;

            common = first.Substring(0, diffIndex) + first.Substring(diffIndex + 1);
            return true;
        }
    }
}
