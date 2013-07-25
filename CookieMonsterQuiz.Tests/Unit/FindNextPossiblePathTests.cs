using System.Collections.Generic;
using CookieMonsterQuiz.Tests.Utilities;
using NUnit.Framework;

namespace CookieMonsterQuiz.Tests.Unit
{
    [TestFixture]
    class FindNextPossiblePathTests
    {
        private CookieForestParser _cookieForestParser;
        private LinkedList<CookieForestTile> _initialPath;

        [SetUp]
        public void Setup()
        {
            _cookieForestParser = new CookieForestParser();
            _initialPath = new LinkedList<CookieForestTile>();
        }

        [Test]
        public void TestThatFindNextPossiblePathReturnsTileToRightOn2By1ForestWhenStartingAtEntry()
        {
            var twoByOneForest = ForestBuilder.BuildForestOfSize(2, 1);

            _initialPath.AddLast(twoByOneForest.ElementAtCoordinates(1,1));

            var result = _cookieForestParser.FindNextPossiblePath(twoByOneForest, _initialPath);

            Assert.That(result.CurrentPath, Has.Count.EqualTo(2));
            Assert.That(result.CurrentPath.Last.Value.X, Is.EqualTo(2));
            Assert.That(result.CurrentPath.Last.Value.Y, Is.EqualTo(1));
        }

        [Test]
        public void TestThatFindNextPossiblePathReturnsTileToBottomOn1By2ForestWhenStartingAtEntry()
        {
            var oneByTwoForest = ForestBuilder.BuildForestOfSize(1, 2);

            _initialPath.AddLast(oneByTwoForest.ElementAtCoordinates(1, 1));

            var result = _cookieForestParser.FindNextPossiblePath(oneByTwoForest, _initialPath);

            Assert.That(result.CurrentPath, Has.Count.EqualTo(2));
            Assert.That(result.CurrentPath.Last.Value.X, Is.EqualTo(1));
            Assert.That(result.CurrentPath.Last.Value.Y, Is.EqualTo(2));
        }

        [Test]
        public void TestThatFindNextPossiblePathReturnsTileToRightOn2By2ForestWhenStartingAtEntryAndBottomEntryHasThorns()
        {
            var twoByTwoForest = ForestBuilder.BuildForestOfSize(2, 2);
            twoByTwoForest.ElementAtCoordinates(1, 2).CookieCount = CookieForestTile.TileHasThorns;

            _initialPath.AddLast(twoByTwoForest.ElementAtCoordinates(1, 1));

            var result = _cookieForestParser.FindNextPossiblePath(twoByTwoForest, _initialPath);

            Assert.That(result.CurrentPath, Has.Count.EqualTo(2));
            Assert.That(result.CurrentPath.Last.Value.X, Is.EqualTo(2));
            Assert.That(result.CurrentPath.Last.Value.Y, Is.EqualTo(1));
        }

        [Test]
        public void TestThatFindNextPossiblePathReturnsTileToBottomOn2By2ForestWhenStartingAtEntryAndRightEntryHasThorns()
        {
            var twoByTwoForest = ForestBuilder.BuildForestOfSize(2, 2);
            twoByTwoForest.ElementAtCoordinates(2, 1).CookieCount = CookieForestTile.TileHasThorns;

            _initialPath.AddLast(twoByTwoForest.ElementAtCoordinates(1, 1));

            var result = _cookieForestParser.FindNextPossiblePath(twoByTwoForest, _initialPath);

            Assert.That(result.CurrentPath, Has.Count.EqualTo(2));
            Assert.That(result.CurrentPath.Last.Value.X, Is.EqualTo(1));
            Assert.That(result.CurrentPath.Last.Value.Y, Is.EqualTo(2));
        }

        [Test]
        public void TestThatFindNextPossiblePathReturnsTileToWithHighestCookieCountWhenNeitherHasThorns()
        {
            var twoByTwoForest = ForestBuilder.BuildForestOfSize(2, 2);
            twoByTwoForest.ElementAtCoordinates(2, 1).CookieCount = 99;

            _initialPath.AddLast(twoByTwoForest.ElementAtCoordinates(1, 1));

            var result = _cookieForestParser.FindNextPossiblePath(twoByTwoForest, _initialPath);

            Assert.That(result.CurrentPath, Has.Count.EqualTo(2));
            Assert.That(result.CurrentPath.Last.Value.X, Is.EqualTo(2));
            Assert.That(result.CurrentPath.Last.Value.Y, Is.EqualTo(1));
        }

        [Test]
        public void TestThatFindNextPossiblePathReturnsTileToWithHighestCookieCountWhenNeitherHasThorns2()
        {
            var twoByTwoForest = ForestBuilder.BuildForestOfSize(2, 2);
            twoByTwoForest.ElementAtCoordinates(1, 2).CookieCount = 99;

            _initialPath.AddLast(twoByTwoForest.ElementAtCoordinates(1, 1));

            var result = _cookieForestParser.FindNextPossiblePath(twoByTwoForest, _initialPath);

            Assert.That(result.CurrentPath, Has.Count.EqualTo(2));
            Assert.That(result.CurrentPath.Last.Value.X, Is.EqualTo(1));
            Assert.That(result.CurrentPath.Last.Value.Y, Is.EqualTo(2));
        }

        [Test]
        public void TestThatFindNextPossiblePathReturnsPreviousTileAsLastIfAtDeadEnd()
        {
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

            _initialPath.AddLast(fourByThreeForest.ElementAtCoordinates(1, 1));
            _initialPath.AddLast(fourByThreeForest.ElementAtCoordinates(2, 1));
            _initialPath.AddLast(fourByThreeForest.ElementAtCoordinates(3, 1));

            var result = _cookieForestParser.FindNextPossiblePath(fourByThreeForest, _initialPath);

            Assert.That(result.CurrentPath.Last.Value.X, Is.EqualTo(fourByThreeForest.ElementAtCoordinates(2, 1).X));
            Assert.That(result.CurrentPath.Last.Value.Y, Is.EqualTo(fourByThreeForest.ElementAtCoordinates(2, 1).Y));

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
