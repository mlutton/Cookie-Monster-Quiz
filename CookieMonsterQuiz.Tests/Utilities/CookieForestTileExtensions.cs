
namespace CookieMonsterQuiz.Tests.Utilities
{
    public static class CookieForestTileExtensions
    {
        public static CookieForestTile SetTileXValueTo(this CookieForestTile selectedTile, int newXValue)
        {
            selectedTile.X = newXValue;

            return selectedTile;
        }

        public static CookieForestTile SetTileYValueTo(this CookieForestTile selectedTile, int newYValue)
        {
            selectedTile.Y = newYValue;

            return selectedTile;
        }

        public static CookieForestTile SetTileToHaveThorns(this CookieForestTile selectedTile)
        {
            selectedTile.CookieCount = CookieForestTile.TileHasThorns;

            return selectedTile;
        }
    }
}
