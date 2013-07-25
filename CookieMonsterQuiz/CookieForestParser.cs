
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
        public CookieMonsterTile FindInitialEntryTile(List<CookieMonsterTile> cookieMonsterTiles)
        {
            if (cookieMonsterTiles == null) throw new ArgumentNullException("cookieMonsterTiles",
                "You can not pass in null into FindInitialEntryTile. Please pass in a valid list of tiles.");

            var entryPointTile = cookieMonsterTiles.FirstOrDefault(cft => cft.X == 1 && cft.Y == 1);

            if (entryPointTile == null) throw new ArgumentOutOfRangeException("cookieMonsterTiles",
                "You passed in an invalid list of tiles into FindInitialEntryTile. " +
                "Please pass in a valid list of tiles with one at X,Y coordinate 1,1.");

            return null;
        }
    }
}
