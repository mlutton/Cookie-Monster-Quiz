using System;
using NUnit.Framework;

namespace CookieMonsterQuiz.Tests.Unit
{
    [TestFixture]
    class CookieMonsterTests
    {
        [Test]
        public void TestThatFindPathThroughForestThrowsWhenPassingInNull()
        {
            var cookieMonster = new CookieMonster();

            Assert.Throws<ArgumentNullException>(() => cookieMonster.FindPathThroughForest(null));
        }
    }
}
