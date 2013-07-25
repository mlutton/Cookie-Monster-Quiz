using System.Linq;
using CookieMonsterQuiz.Tests.Utilities;
using NUnit.Framework;

namespace CookieMonsterQuiz.Tests.Integration
{
    [TestFixture]
    class OnebyOneForestTests
    {
        [Test]
        public void TestThatOneByOneForestReturnsItself()
        {
            var cookieMonsterParser = new CookieForestParser();
            var cookieMonster = new CookieMonster(cookieMonsterParser);

            var oneByOneForest = ForestBuilder.BuildForestOfSize(1, 1);

            var result = cookieMonster.FindPathThroughForest(oneByOneForest);

            Assert.That(result.First.Value.X, Is.EqualTo(CookieForestParser.InitialXPosition));
            Assert.That(result.First.Value.Y, Is.EqualTo(CookieForestParser.InitialYPosition));

        }
    }
}
