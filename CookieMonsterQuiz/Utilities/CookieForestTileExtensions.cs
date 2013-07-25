
namespace CookieMonsterQuiz.Utilities
{
    public static class CookieForestTileExtensions
    {
        public static int GetXCoordinateToRight(this CookieForestTile selectedTile)
        {
            return selectedTile.X + 1;
        }

        public static int GetYCoordinateToBottom(this CookieForestTile selectedTile)
        {
            return selectedTile.Y + 1;
        }
    }
}
