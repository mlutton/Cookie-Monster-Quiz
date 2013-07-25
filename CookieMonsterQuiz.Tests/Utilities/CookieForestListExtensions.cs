using System.Collections.Generic;
using System.Linq;

namespace CookieMonsterQuiz.Tests.Utilities
{
    public static class CookieForestListExtensions
    {
        public static CookieForestTile ElementAtCoordinates(this List<CookieForestTile> forestTiles, int xCoordinate,
    int yCoordinate)
        {
            return forestTiles.First(ft => ft.X == xCoordinate && ft.Y == yCoordinate);
        }

        public static CookieForestTile Second(this List<CookieForestTile> forestTiles)
        {
            return forestTiles[1];
        }
    }
}
