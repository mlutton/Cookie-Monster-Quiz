using CookieMonsterQuiz.Tests.Utilities;
using NUnit.Framework;

namespace CookieMonsterQuiz.Tests.Integration
{
    [TestFixture]
    class TwelveTileForestTests
    {
        [Test]
        public void TestThatForestWithMazeCompletesSuccessfully()
        {
            var cookieForestParser = new CookieForestParser();
            var cookieMonster = new CookieMonster(cookieForestParser);

            var fourByThreeForest = ForestBuilder.BuildForestOfSize(4, 3);

            // Set maze to:
            // X = Thorns
            //
            //  0 1 0 X  
            //  0 X X X
            //  0 0 0 0

            fourByThreeForest.ElementAtCoordinates(2, 1).CookieCount = 1;
            fourByThreeForest.ElementAtCoordinates(4, 1).CookieCount = CookieForestTile.TileHasThorns;
            fourByThreeForest.ElementAtCoordinates(2, 2).CookieCount = CookieForestTile.TileHasThorns;
            fourByThreeForest.ElementAtCoordinates(3, 2).CookieCount = CookieForestTile.TileHasThorns;
            fourByThreeForest.ElementAtCoordinates(4, 2).CookieCount = CookieForestTile.TileHasThorns;

            var result = cookieMonster.FindPathThroughForest(fourByThreeForest);

            Assert.That(result, Has.Count.EqualTo(6));
        }
    }
}
