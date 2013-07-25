
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
    }
}
