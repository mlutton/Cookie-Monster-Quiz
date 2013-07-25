using System.Linq;
using CookieMonsterQuiz.Tests.Utilities;
using NUnit.Framework;

namespace CookieMonsterQuiz.Tests.Integration
{
    [TestFixture]
    class TwoTileForestTests
    {
        [Test]
        public void TestThatTwoByOneTileForestCompletesSuccessfully()
        {
            var cookieMonsterParser = new CookieForestParser();
            var cookieMonster = new CookieMonster(cookieMonsterParser);

            var twoByOneForest = ForestBuilder.BuildForestOfSize(2, 1);

            var result = cookieMonster.FindPathThroughForest(twoByOneForest);

            Assert.That(result, Has.Count.EqualTo(2));
            Assert.That(result.ElementAt(0).X, Is.EqualTo(1));
            Assert.That(result.ElementAt(0).Y, Is.EqualTo(1));
            Assert.That(result.ElementAt(1).X, Is.EqualTo(2));
            Assert.That(result.ElementAt(1).Y, Is.EqualTo(1));
        }

        [Test]
        public void TestThatOneByTwoTileForestCompletesSuccessfully()
        {
            var cookieMonsterParser = new CookieForestParser();
            var cookieMonster = new CookieMonster(cookieMonsterParser);

            var twoByOneForest = ForestBuilder.BuildForestOfSize(1, 2);

            var result = cookieMonster.FindPathThroughForest(twoByOneForest);

            Assert.That(result, Has.Count.EqualTo(1));
            Assert.That(result.ElementAt(0).X, Is.EqualTo(1));
            Assert.That(result.ElementAt(0).Y, Is.EqualTo(1));
        }
    }
}
