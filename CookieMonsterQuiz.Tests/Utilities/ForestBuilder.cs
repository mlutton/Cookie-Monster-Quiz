using System.Collections.Generic;

namespace CookieMonsterQuiz.Tests.Utilities
{
    public static class ForestBuilder
    {
        public static List<CookieForestTile> BuildForestOfSize(int numberOfRows, int numberOfColumns, int cookieCount = CookieForestTile.TileHasThorns)
        {
            var forestResult = new List<CookieForestTile>();

            for (int x = 1; x <= numberOfRows; x++)
            {
                for (int y = 1; y <= numberOfColumns; y++)
                {
                    forestResult.Add(new CookieForestTile() { CookieCount = 0, X = x, Y = y });
                }
            }

            return forestResult;
        }
    }
}
