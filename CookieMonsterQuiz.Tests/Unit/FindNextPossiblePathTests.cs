using System.Collections.Generic;
using CookieMonsterQuiz.Tests.Utilities;
using NUnit.Framework;

namespace CookieMonsterQuiz.Tests.Unit
{
    [TestFixture]
    class FindNextPossiblePathTests
    {
        [Test]
        public void TestThatFindNextPossiblePathReturnsTileToRightOn2By1ForestWhenStartingAtEntry()
        {
            var cookieForestParser = new CookieForestParser();
            var twoByOneForest = ForestBuilder.BuildForestOfSize(2, 1);

            var initialPath = new LinkedList<CookieForestTile>();
            initialPath.AddLast(twoByOneForest.ElementAtCoordinates(1,1));

            var result = cookieForestParser.FindNextPossiblePath(twoByOneForest, initialPath);

            Assert.That(result.NextTile.X, Is.EqualTo(2));
            Assert.That(result.NextTile.Y, Is.EqualTo(1));
        }

        [Test]
        public void TestThatFindNextPossiblePathReturnsTileToBottomOn1By2ForestWhenStartingAtEntry()
        {
            var cookieForestParser = new CookieForestParser();
            var oneByTwoForest = ForestBuilder.BuildForestOfSize(1, 2);

            var initialPath = new LinkedList<CookieForestTile>();
            initialPath.AddLast(oneByTwoForest.ElementAtCoordinates(1, 1));

            var result = cookieForestParser.FindNextPossiblePath(oneByTwoForest, initialPath);

            Assert.That(result.NextTile.X, Is.EqualTo(1));
            Assert.That(result.NextTile.Y, Is.EqualTo(2));
        }

        [Test]
        public void TestThatFindNextPossiblePathReturnsTileToRightOn2By2ForestWhenStartingAtEntryAndBottomEntryHasThorns()
        {
            var cookieForestParser = new CookieForestParser();
            var twoByTwoForest = ForestBuilder.BuildForestOfSize(2, 2);
            twoByTwoForest.ElementAtCoordinates(1, 2).CookieCount = CookieForestTile.TileHasThorns;

            var initialPath = new LinkedList<CookieForestTile>();
            initialPath.AddLast(twoByTwoForest.ElementAtCoordinates(1, 1));


            var result = cookieForestParser.FindNextPossiblePath(twoByTwoForest, initialPath);

            Assert.That(result.NextTile.X, Is.EqualTo(2));
            Assert.That(result.NextTile.Y, Is.EqualTo(1));
        }

        [Test]
        public void TestThatFindNextPossiblePathReturnsTileToBottomOn2By2ForestWhenStartingAtEntryAndRightEntryHasThorns()
        {
            var cookieForestParser = new CookieForestParser();
            var twoByTwoForest = ForestBuilder.BuildForestOfSize(2, 2);
            twoByTwoForest.ElementAtCoordinates(2, 1).CookieCount = CookieForestTile.TileHasThorns;

            var initialPath = new LinkedList<CookieForestTile>();
            initialPath.AddLast(twoByTwoForest.ElementAtCoordinates(1, 1));

            var result = cookieForestParser.FindNextPossiblePath(twoByTwoForest, initialPath);

            Assert.That(result.NextTile.X, Is.EqualTo(1));
            Assert.That(result.NextTile.Y, Is.EqualTo(2));
        }

        [Test]
        public void TestThatFindNextPossiblePathReturnsTileToWithHighestCookieCountWhenNeitherHasThorns()
        {
            var cookieForestParser = new CookieForestParser();
            var twoByTwoForest = ForestBuilder.BuildForestOfSize(2, 2);
            twoByTwoForest.ElementAtCoordinates(2, 1).CookieCount = 99;

            var initialPath = new LinkedList<CookieForestTile>();
            initialPath.AddLast(twoByTwoForest.ElementAtCoordinates(1, 1));

            var result = cookieForestParser.FindNextPossiblePath(twoByTwoForest, initialPath);

            Assert.That(result.NextTile.X, Is.EqualTo(2));
            Assert.That(result.NextTile.Y, Is.EqualTo(1));
        }

        [Test]
        public void TestThatFindNextPossiblePathReturnsTileToWithHighestCookieCountWhenNeitherHasThorns2()
        {
            var cookieForestParser = new CookieForestParser();
            var twoByTwoForest = ForestBuilder.BuildForestOfSize(2, 2);
            twoByTwoForest.ElementAtCoordinates(1, 2).CookieCount = 99;

            var initialPath = new LinkedList<CookieForestTile>();
            initialPath.AddLast(twoByTwoForest.ElementAtCoordinates(1, 1));

            var result = cookieForestParser.FindNextPossiblePath(twoByTwoForest, initialPath);

            Assert.That(result.NextTile.X, Is.EqualTo(1));
            Assert.That(result.NextTile.Y, Is.EqualTo(2));
        }

        [Test]
        public void TestThatFindNextPossiblePathReturnsPreviousTileIfAtDeadEnd()
        {
            var cookieForestParser = new CookieForestParser();
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

            var initialPath = new LinkedList<CookieForestTile>();
            initialPath.AddLast(fourByThreeForest.ElementAtCoordinates(1, 1));
            initialPath.AddLast(fourByThreeForest.ElementAtCoordinates(2, 1));
            initialPath.AddLast(fourByThreeForest.ElementAtCoordinates(3, 1));

            var result = cookieForestParser.FindNextPossiblePath(fourByThreeForest, initialPath);

            Assert.That(result.NextTile.X, Is.EqualTo(fourByThreeForest.ElementAtCoordinates(2, 1).X));
            Assert.That(result.NextTile.Y, Is.EqualTo(fourByThreeForest.ElementAtCoordinates(2, 1).Y));

        }

        [Test]
        public void TestThatFindNextPossiblePathUpdatesAvailableListOfTilesSoThatParserDoesntRetryADeadEnd()
        {
            var cookieForestParser = new CookieForestParser();
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

            var initialPath = new LinkedList<CookieForestTile>();
            initialPath.AddLast(fourByThreeForest.ElementAtCoordinates(1, 1));
            initialPath.AddLast(fourByThreeForest.ElementAtCoordinates(2, 1));
            initialPath.AddLast(fourByThreeForest.ElementAtCoordinates(3, 1));

            var result = cookieForestParser.FindNextPossiblePath(fourByThreeForest, initialPath);

            Assert.That(result.AvailableTiles.Count, Is.EqualTo(fourByThreeForest.Count-1));
        }
    }
}
