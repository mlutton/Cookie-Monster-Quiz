using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;

namespace CookieMonsterQuiz.Tests.Unit
{
    [TestFixture]
    class CookieMonsterTests
    {
        private Mock<ICookieForestParser> _cookieForestParserMock;
        private CookieMonster _cookieMonster;

        [SetUp]
        public void Setup()
        {
            _cookieForestParserMock = new Mock<ICookieForestParser>();
            _cookieMonster = new CookieMonster(_cookieForestParserMock.Object);
        }

        [Test]
        public void TestThatFindPathThroughForestThrowsWhenPassingInNull()
        {
            Assert.Throws<ArgumentNullException>(() => _cookieMonster.FindPathThroughForest(null));
        }

        [Test]
        public void TestThatFindPathThroughForestCallsFindInitialEntryLocation()
        {
            _cookieMonster.FindPathThroughForest(new List<CookieForestTile>());
            
            _cookieForestParserMock.Verify(c => c.FindInitialEntryTile(It.IsAny<List<CookieForestTile>>()));   
        }

        [Test]
        public void TestThatFindPathThroughForestCallsHasCompletedMaze()
        {
            _cookieMonster.FindPathThroughForest(new List<CookieForestTile>());

            _cookieForestParserMock.Verify(c => c.HasCompletedMaze(It.IsAny<List<CookieForestTile>>(), It.IsAny<CookieForestTile>()));
        }

        [Test]
        public void TestThatFindPathThroughForestCallsFindNextPossiblePath()
        {
            _cookieMonster.FindPathThroughForest(new List<CookieForestTile>());

            _cookieForestParserMock.Verify(c => c.FindNextPossiblePath(It.IsAny<List<CookieForestTile>>(), It.IsAny<LinkedList<CookieForestTile>>()));
        }
    }
}
