
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

        public LinkedList<CookieMonsterTile> FindPathThroughForest(List<CookieMonsterTile> cookieMonsterTiles)
        {
           if (cookieMonsterTiles == null)
               throw new ArgumentNullException("cookieMonsterTiles", "You can not pass null into FindPathThroughForest. " +
                   " Please pass in a valid list of cookie monster tiles");

            var initialEntryCell = _cookieForestParser.FindInitialEntryTile(new List<CookieMonsterTile>());
            return null;
        }
    }
}
