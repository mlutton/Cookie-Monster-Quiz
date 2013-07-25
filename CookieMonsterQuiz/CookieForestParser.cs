
using System;
using System.Collections.Generic;
using System.Linq;

namespace CookieMonsterQuiz
{
    public interface ICookieForestParser
    {
        CookieMonsterTile FindInitialEntryTile(List<CookieMonsterTile> cookieMonsterTiles);
    }

    public class CookieForestParser: ICookieForestParser
    {
        public const int InitialXPosition = 1;
        public const int InitialYPosition = 1;

        public CookieMonsterTile FindInitialEntryTile(List<CookieMonsterTile> cookieMonsterTiles)
        {
            if (cookieMonsterTiles == null) throw new ArgumentNullException("cookieMonsterTiles",
                "You can not pass in null into FindInitialEntryTile. Please pass in a valid list of tiles.");

            var entryPointTile =
                cookieMonsterTiles.FirstOrDefault(
                    cft => cft.X == InitialXPosition && cft.Y == InitialYPosition && cft.CookieCount != CookieMonsterTile.TileHasThorns);

            if (entryPointTile == null) throw new ArgumentOutOfRangeException("cookieMonsterTiles",
                "You passed in an invalid list of tiles into FindInitialEntryTile. " +
                "Please pass in a valid list of tiles with one at X,Y coordinate 1,1.");

            return entryPointTile;
        }
    }
}
