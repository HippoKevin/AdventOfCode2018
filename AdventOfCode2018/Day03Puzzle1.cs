using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2018
{
    class Day03Puzzle1
    {
        public static string Solve(params string[] inputs)
        {
            var regex = new Regex(@"#(?<claimId>\d+) @ (?<leftOffset>\d+),(?<topOffset>\d+): (?<width>\d+)x(?<height>\d+)");

            var input = inputs[0];
            var claims = input
                .Split(new[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .Select(line => regex.Match(line))
                .Select(match => new FabricClaim
                {
                    ClaimId = int.Parse(match.Groups["claimId"].ToString()),
                    LeftOffset = int.Parse(match.Groups["leftOffset"].ToString()),
                    TopOffset = int.Parse(match.Groups["topOffset"].ToString()),
                    Width = int.Parse(match.Groups["width"].ToString()),
                    Height = int.Parse(match.Groups["height"].ToString()),
                })
                .ToList();

            var fabricWidth = claims.Max(fc => fc.LeftOffset + fc.Width);
            var fabricHeight = claims.Max(fc => fc.TopOffset + fc.Height);

            var fabric = new Fabric(fabricWidth, fabricHeight);

            claims.ForEach(claim => fabric.Claim(claim));

            return fabric.ConflictCount().ToString();
        }
    }

    struct FabricClaim
    {
        public int ClaimId;
        public int LeftOffset;
        public int TopOffset;
        public int Width;
        public int Height;
    }

    class Fabric
    {
        private readonly int?[,] _fabricValues;

        public Fabric(int width, int height)
        {
            _fabricValues = new int?[width, height];
        }

        public void Claim(FabricClaim fabricClaim)
        {
            for (var i = fabricClaim.LeftOffset; i < fabricClaim.LeftOffset + fabricClaim.Width; i++)
            for (var j = fabricClaim.TopOffset; j < fabricClaim.TopOffset + fabricClaim.Height; j++)
            {
                _fabricValues[i, j] = _fabricValues[i, j].HasValue ? 0 : fabricClaim.ClaimId;
            }
        }

        public int ConflictCount()
        {
            int count = 0;
            for (var i = 0; i < _fabricValues.GetLength(0); i++)
            for (var j = 0; j < _fabricValues.GetLength(1); j++)
                if (_fabricValues[i,j] == 0) count++;

            return count;
        }
    }
}
