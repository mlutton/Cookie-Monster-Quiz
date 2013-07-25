
using System.Collections.Generic;

namespace CookieMonsterQuiz
{
    public interface ICookieForestParser
    {
        CookieMonsterTile FindInitialEntryTile(List<CookieMonsterTile> cookieMonsterTiles);
    }

    public class CookieForestParser
    {
    }
}
