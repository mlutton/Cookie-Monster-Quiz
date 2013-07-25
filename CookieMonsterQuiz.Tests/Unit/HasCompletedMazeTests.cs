using System.Linq;
using CookieMonsterQuiz.Tests.Utilities;
using NUnit.Framework;

namespace CookieMonsterQuiz.Tests.Unit
{
    [TestFixture]
    class HasCompletedMazeTests
    {
        [Test]
        public void TestThatHasCompletedMazeReturnsTrueIfListIsAOneByOneForest()
        {
            var cookieForestParser = new CookieForestParser();
            var oneByOneForest = ForestBuilder.BuildForestOfSize(1, 1);

            var isOnEdgeOfForest = cookieForestParser.HasCompletedMaze(oneByOneForest, oneByOneForest.First());

            Assert.That(isOnEdgeOfForest, Is.True);
        }

        [Test]
        public void TestThatHasCompletedMazeReturnsFalseIfListIsATwoByOneForest()
        {
            var cookieForestParser = new CookieForestParser();
            var twoByOneForest = ForestBuilder.BuildForestOfSize(2, 1);

            var isOnEdgeOfForest = cookieForestParser.HasCompletedMaze(twoByOneForest, twoByOneForest.First());

            Assert.That(isOnEdgeOfForest, Is.False);
        }

        [Test]
        public void TestThatHasCompletedMazeReturnsTrueIfListIsATwoByOneForestAndCurrentTileIsOnEdge()
        {
            var cookieForestParser = new CookieForestParser();
            var twoByOneForest = ForestBuilder.BuildForestOfSize(2, 1);

            var edgeTile = twoByOneForest.Second();

            var isOnEdgeOfForest = cookieForestParser.HasCompletedMaze(twoByOneForest,edgeTile);

            Assert.That(isOnEdgeOfForest, Is.True);
        }
    }
}
