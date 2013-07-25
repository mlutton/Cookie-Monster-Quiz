
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

            return FindPathThroughForestLoop(nextAvailableMove, cookieForestPath, availableForestTiles);
        }

        private LinkedList<CookieForestTile> FindPathThroughForestLoop(CookieForestTile nextAvailableMove, LinkedList<CookieForestTile> cookieForestPath,
            List<CookieForestTile> availableForestTiles)
        {
            cookieForestPath.AddLast(nextAvailableMove);

            while (nextAvailableMove != null)
            {
                if (_cookieForestParser.HasCompletedMaze(availableForestTiles, cookieForestPath.Last()))
                {
                    return cookieForestPath;
                }

                var findNextPossiblePathResult = _cookieForestParser.FindNextPossiblePath(availableForestTiles,
                    cookieForestPath);

                availableForestTiles = findNextPossiblePathResult.AvailableTiles;
                cookieForestPath = findNextPossiblePathResult.CurrentPath;

                nextAvailableMove = cookieForestPath.Count == 0 ? null : cookieForestPath.Last();
            }

            return null;
        }
    }
}
