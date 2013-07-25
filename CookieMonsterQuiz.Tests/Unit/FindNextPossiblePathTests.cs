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
    }
}
