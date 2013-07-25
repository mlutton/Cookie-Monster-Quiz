
using System;
using System.Collections.Generic;

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
               throw new ArgumentNullException("cookieMonsterTiles", "You can not pass null into FindPathThroughForest. " +
                   " Please pass in a valid list of cookie monster tiles");

            var initialEntryCell = _cookieForestParser.FindInitialEntryTile(cookieMonsterTiles);

            var completedMaze = _cookieForestParser.HasCompletedMaze(cookieMonsterTiles, initialEntryCell);

            var cookieForestPath = new LinkedList<CookieForestTile>();
            cookieForestPath.AddLast(initialEntryCell);

            if (completedMaze)
            {
                return cookieForestPath;
            }

            var nextPossibleMove = _cookieForestParser.FindNextPossiblePath(cookieMonsterTiles, cookieForestPath);

            return null;
        }
    }
}
