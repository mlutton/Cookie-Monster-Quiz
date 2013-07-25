using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;

namespace CookieMonsterQuiz.Tests.Unit
{
    [TestFixture]
    class CookieMonsterTests
    {
        [Test]
        public void TestThatFindPathThroughForestThrowsWhenPassingInNull()
        {
            var cookieForestParserMock = new Mock<ICookieForestParser>();
            var cookieMonster = new CookieMonster(cookieForestParserMock.Object);

            Assert.Throws<ArgumentNullException>(() => cookieMonster.FindPathThroughForest(null));
        }

        [Test]
        public void TestThatFindPathThroughForestCallsFindInitialEntryLocation()
        {
            var cookieForestParserMock = new Mock<ICookieForestParser>();
            var cookieMonster = new CookieMonster(cookieForestParserMock.Object);

            cookieMonster.FindPathThroughForest(new List<CookieForestTile>());
            cookieForestParserMock.Verify(c => c.FindInitialEntryTile(It.IsAny<List<CookieForestTile>>()));   
        }
    }
}
