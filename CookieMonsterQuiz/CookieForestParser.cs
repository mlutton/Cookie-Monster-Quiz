
using System;
using System.Collections.Generic;
using System.Linq;

namespace CookieMonsterQuiz
{
    public interface ICookieForestParser
    {
        CookieForestTile FindInitialEntryTile(List<CookieForestTile> cookieMonsterTiles);
        bool HasCompletedMaze(List<CookieForestTile> cookieForestTiles, CookieForestTile currentTile);

        FindNextPossiblePathResult FindNextPossiblePath(List<CookieForestTile> list, LinkedList<CookieForestTile> currentPathThroughForestTiles);
    }

    public class FindNextPossiblePathResult
    {
        public CookieForestTile NextTile { get; set; }
    }

    public class CookieForestParser: ICookieForestParser
    {
        public const int InitialXPosition = 1;
        public const int InitialYPosition = 1;

        public CookieForestTile FindInitialEntryTile(List<CookieForestTile> cookieMonsterTiles)
        {
            if (cookieMonsterTiles == null) throw new ArgumentNullException("cookieMonsterTiles",
                "You can not pass in null into FindInitialEntryTile. Please pass in a valid list of tiles.");

            var entryPointTile =
                cookieMonsterTiles.FirstOrDefault(
                    cft => cft.X == InitialXPosition && cft.Y == InitialYPosition && cft.CookieCount != CookieForestTile.TileHasThorns);

            if (entryPointTile == null) throw new ArgumentOutOfRangeException("cookieMonsterTiles",
                "You passed in an invalid list of tiles into FindInitialEntryTile. " +
                "Please pass in a valid list of tiles with one at X,Y coordinate 1,1.");

            return entryPointTile;
        }

        public bool HasCompletedMaze(List<CookieForestTile> cookieForestTiles, CookieForestTile currentTile)
        {
            return cookieForestTiles.Max(c => c.X) == currentTile.X;
        }

        public FindNextPossiblePathResult FindNextPossiblePath(List<CookieForestTile> list, LinkedList<CookieForestTile> currentPathThroughForestTiles)
        {
            throw new NotImplementedException();
        }
    }
}
