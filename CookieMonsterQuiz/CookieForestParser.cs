
using System;
using System.Collections.Generic;
using System.Linq;
using CookieMonsterQuiz.Utilities;

namespace CookieMonsterQuiz
{
    public interface ICookieForestParser
    {
        CookieForestTile FindInitialEntryTile(List<CookieForestTile> cookieMonsterTiles);
        bool HasCompletedMaze(List<CookieForestTile> cookieForestTiles, CookieForestTile currentTile);

        FindNextPossiblePathResult FindNextPossiblePath(List<CookieForestTile> cookieForestTiles, LinkedList<CookieForestTile> currentPathThroughForestTiles);
    }

    public class FindNextPossiblePathResult
    {
        public CookieForestTile NextTile { get; set; }
        public List<CookieForestTile> AvailableTiles { get; set; }
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

        public FindNextPossiblePathResult FindNextPossiblePath(List<CookieForestTile> cookieForestTiles, LinkedList<CookieForestTile> currentPathThroughForestTiles)
        {
            var result = new FindNextPossiblePathResult() {AvailableTiles = cookieForestTiles};
            var currentTile = currentPathThroughForestTiles.Last();

            var tileToRight =
                cookieForestTiles.FirstOrDefault(
                    c =>
                        c.X == currentTile.GetXCoordinateToRight() && c.Y == currentTile.Y &&
                        c.CookieCount != CookieForestTile.TileHasThorns);

            var tileToBottom =
                cookieForestTiles.FirstOrDefault(
                    c =>
                        c.Y == currentTile.GetYCoordinateToBottom() &&
                        c.X == currentTile.X & c.CookieCount != CookieForestTile.TileHasThorns);

            if (tileToBottom == null && tileToRight == null)
            {
                var availableTimes = cookieForestTiles.ToList();
                availableTimes.RemoveAll(c => c.X == currentTile.X && c.Y == currentTile.Y);
                result.AvailableTiles = availableTimes;

                currentPathThroughForestTiles.RemoveLast();
                result.NextTile = currentPathThroughForestTiles.Last();

            }
            else if (tileToRight != null && tileToBottom == null)
            {
                result.NextTile = tileToRight;
            }
            else if (tileToBottom != null && tileToRight == null)
            {
                result.NextTile = tileToBottom;
            }
            else if (tileToRight.CookieCount > tileToBottom.CookieCount)
            {
                result.NextTile = tileToRight;
            }
            else if (tileToBottom.CookieCount >= tileToRight.CookieCount)
            {
                result.NextTile = tileToBottom;
            }

            return result;
        }
    }
}
