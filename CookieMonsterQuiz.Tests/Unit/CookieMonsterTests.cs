using System;
using System.Collections.Generic;
using System.Linq;
using CookieMonsterQuiz.Tests.Utilities;
using Moq;
using NUnit.Framework;

namespace CookieMonsterQuiz.Tests.Unit
{
    [TestFixture]
    class CookieMonsterTests
    {
        private Mock<ICookieForestParser> _cookieForestParserMock;
        private CookieMonster _cookieMonster;

        private List<CookieForestTile> _oneByOneForest;
        private List<CookieForestTile> _twoByTwoForest;
        
        [SetUp]
        public void Setup()
        {
            _cookieForestParserMock = new Mock<ICookieForestParser>();

            SetupParserMockToReturnFirstElementForFindInitialEntryTile();
            SetupParseMockToDynamicallyReturnTrueFalseOnHasCompletedMaze();

            _oneByOneForest = ForestBuilder.BuildForestOfSize(1, 1);
            _twoByTwoForest = ForestBuilder.BuildForestOfSize(2, 2);

            var currentPathForTwoByTwoForest = CreateCurrentPathForTwoByTwoForest();

            SetupParserToReturnNextElementOnTwoByTwoForest(currentPathForTwoByTwoForest);

            _cookieMonster = new CookieMonster(_cookieForestParserMock.Object);

        }

        private LinkedList<CookieForestTile> CreateCurrentPathForTwoByTwoForest()
        {
            var currentPathForTwoByTwoForest = new LinkedList<CookieForestTile>();
            currentPathForTwoByTwoForest.AddLast(_twoByTwoForest.ElementAtCoordinates(1, 1));
            currentPathForTwoByTwoForest.AddLast(_twoByTwoForest.ElementAtCoordinates(2, 1));
            return currentPathForTwoByTwoForest;
        }

        private void SetupParserToReturnNextElementOnTwoByTwoForest(LinkedList<CookieForestTile> currentPathForTwoByTwoForest)
        {
            _cookieForestParserMock.Setup(
                cf =>
                    cf.FindNextPossiblePath(It.IsAny<List<CookieForestTile>>(), It.IsAny<LinkedList<CookieForestTile>>()))
                .Returns(
                    (List<CookieForestTile> tileList, LinkedList<CookieForestTile> currentPath) =>
                        new FindNextPossiblePathResult() {CurrentPath = currentPathForTwoByTwoForest, AvailableTiles = tileList});
        }

        private void SetupParseMockToDynamicallyReturnTrueFalseOnHasCompletedMaze()
        {
            _cookieForestParserMock.Setup(
                cf => cf.HasCompletedMaze(It.IsAny<List<CookieForestTile>>(), It.IsAny<CookieForestTile>()))
                .Returns(
                    (List<CookieForestTile> tileList, CookieForestTile tile) =>
                        tileList.Max(t => t.X) == tile.X);
        }

        private void SetupParserMockToReturnFirstElementForFindInitialEntryTile()
        {
            _cookieForestParserMock.Setup(cf => cf.FindInitialEntryTile(It.IsAny<List<CookieForestTile>>()))
                .Returns((List<CookieForestTile> list) => list.First());
        }

        [Test]
        public void TestThatFindPathThroughForestThrowsWhenPassingInNull()
        {
            Assert.Throws<ArgumentNullException>(() => _cookieMonster.FindPathThroughForest(null));
        }

        [Test]
        public void TestThatFindPathThroughForestCallsFindInitialEntryLocation()
        {
            _cookieMonster.FindPathThroughForest(_oneByOneForest);
            
            _cookieForestParserMock.Verify(c => c.FindInitialEntryTile(It.IsAny<List<CookieForestTile>>()));   
        }

        [Test]
        public void TestThatFindPathThroughForestCallsHasCompletedMaze()
        {
            _cookieMonster.FindPathThroughForest(_oneByOneForest);

            _cookieForestParserMock.Verify(c => c.HasCompletedMaze(It.IsAny<List<CookieForestTile>>(), It.IsAny<CookieForestTile>()));
        }

        [Test]
        public void TestThatFindPathThroughForestReturnsInitialEntryCellIfHasCompletedMazeIsTrue()
        {
            var pathResult = _cookieMonster.FindPathThroughForest(_oneByOneForest);

           Assert.That(pathResult, Has.Count.EqualTo(1));

           Assert.That(pathResult.First().X, Is.EqualTo(CookieForestParser.InitialXPosition));
           Assert.That(pathResult.First().Y, Is.EqualTo(CookieForestParser.InitialYPosition));
        }

        [Test]
        public void TestThatFindPathThroughForestCallsFindNextPossiblePath()
        {
            _cookieMonster.FindPathThroughForest(_twoByTwoForest);

            _cookieForestParserMock.Verify(c => c.FindNextPossiblePath(It.IsAny<List<CookieForestTile>>(), It.IsAny<LinkedList<CookieForestTile>>()));
        }

        [Test]
        public void TestThatFindPathThroughForestCallsHasCompletedMazeAfterFindNextPossiblePath()
        {
            _cookieMonster.FindPathThroughForest(_twoByTwoForest);

            _cookieForestParserMock.Verify(c => c.HasCompletedMaze(It.IsAny<List<CookieForestTile>>(), It.Is((CookieForestTile ctx) => ctx.X == 2)));
        }
    }
}
