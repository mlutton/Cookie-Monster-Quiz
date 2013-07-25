
using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace CookieMonsterQuiz.Tests.Unit
{
    [TestFixture]
    class FindInitialEntryTileTests
    {
        [Test]
        public void TestThatFindIntialEntryTileThrowsWhenPassingInNull()
        {
            var cookieForestParser = new CookieForestParser();

            Assert.Throws<ArgumentNullException>(() => cookieForestParser.FindInitialEntryTile(null));
        }

        [Test]
        public void TestThatFindInitialEntryTileThrowsWhenPassingInEmptyList()
        {
            var cookieForestParser = new CookieForestParser();

            Assert.Throws<ArgumentOutOfRangeException>(
                () => cookieForestParser.FindInitialEntryTile(new List<CookieMonsterTile>()));
        }

        [Test]
        public void TestThatFindInitialEntryTileThrowsWhenPassingInInvalidTileList()
        {
            var cookieForestParser = new CookieForestParser();
            var invalidOneByOneForest = new List<CookieMonsterTile> {new CookieMonsterTile() {X = 9999, Y = 9999}};

            Assert.Throws<ArgumentOutOfRangeException>(
                () => cookieForestParser.FindInitialEntryTile(invalidOneByOneForest));
        }
    }
}
