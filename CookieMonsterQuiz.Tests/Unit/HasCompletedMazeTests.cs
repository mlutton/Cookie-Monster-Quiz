using System.Linq;
using CookieMonsterQuiz.Tests.Utilities;
using NUnit.Framework;

namespace CookieMonsterQuiz.Tests.Unit
{
    [TestFixture]
    class HasCompletedMazeTests
    {
        private CookieForestParser _cookieForestParser;

        [SetUp]
        public void Setup()
        {
            _cookieForestParser = new CookieForestParser();
        }

        [Test]
        public void TestThatHasCompletedMazeReturnsTrueIfListIsAOneByOneForest()
        {
            var oneByOneForest = ForestBuilder.BuildForestOfSize(1, 1);

            var isOnEdgeOfForest = _cookieForestParser.HasCompletedMaze(oneByOneForest, oneByOneForest.First());

            Assert.That(isOnEdgeOfForest, Is.True);
        }

        [Test]
        public void TestThatHasCompletedMazeReturnsFalseIfListIsATwoByOneForest()
        {
            var twoByOneForest = ForestBuilder.BuildForestOfSize(2, 1);

            var isOnEdgeOfForest = _cookieForestParser.HasCompletedMaze(twoByOneForest, twoByOneForest.First());

            Assert.That(isOnEdgeOfForest, Is.False);
        }

        [Test]
        public void TestThatHasCompletedMazeReturnsTrueIfListIsATwoByOneForestAndCurrentTileIsOnEdge()
        {
            var twoByOneForest = ForestBuilder.BuildForestOfSize(2, 1);

            var edgeTile = twoByOneForest.Second();

            var isOnEdgeOfForest = _cookieForestParser.HasCompletedMaze(twoByOneForest,edgeTile);

            Assert.That(isOnEdgeOfForest, Is.True);
        }
    }
}
