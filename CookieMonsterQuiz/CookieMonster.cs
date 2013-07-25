
using System;
using System.Collections.Generic;
using System.Linq;

namespace CookieMonsterQuiz
{
    public class CookieMonster
    {
        private readonly ICookieForestParser _cookieForestParser;

        public CookieMonster(ICookieForestParser cookieForestParser)
        {
            _cookieForestParser = cookieForestParser;
        }

        public LinkedList<CookieForestTile> FindPathThroughForest(List<CookieForestTile> cookieMonsterTiles)
        {
            if (cookieMonsterTiles == null)
                throw new ArgumentNullException("cookieMonsterTiles",
                    "You can not pass null into FindPathThroughForest. " +
                    " Please pass in a valid list of cookie monster tiles");

            var availableForestTiles = cookieMonsterTiles.ToList();

            var nextAvailableMove = _cookieForestParser.FindInitialEntryTile(cookieMonsterTiles);

            var cookieForestPath = new LinkedList<CookieForestTile>();

            while (nextAvailableMove != null)
            {
                cookieForestPath.AddLast(nextAvailableMove);

                if (_cookieForestParser.HasCompletedMaze(availableForestTiles, cookieForestPath.Last()))
                {
                    return cookieForestPath;
                }

                var findNextPossiblePathResult = _cookieForestParser.FindNextPossiblePath(cookieMonsterTiles,
                    cookieForestPath);

                availableForestTiles = findNextPossiblePathResult.AvailableTiles;

                nextAvailableMove = findNextPossiblePathResult.NextTile;
            }

            return null;
        }
    }
}
