using System;
using System.Collections.Generic;
using CookieMonsterQuiz.Tests.Utilities;
using NUnit.Framework;

namespace CookieMonsterQuiz.Tests.Unit
{
    [TestFixture]
    class FindInitialEntryTileTests
    {
        private const int InvalidXPositionValue = 9999;
        private const int InvalidYPositionValue = 9999;

        private CookieForestParser _cookieForestParser;

        [SetUp]
        public void Setup()
        {
            _cookieForestParser = new CookieForestParser();
        }

        [Test]
        public void TestThatFindIntialEntryTileThrowsWhenPassingInNull()
        {
            Assert.Throws<ArgumentNullException>(() => _cookieForestParser.FindInitialEntryTile(null));
        }

        [Test]
        public void TestThatFindInitialEntryTileThrowsWhenPassingInEmptyList()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => _cookieForestParser.FindInitialEntryTile(new List<CookieForestTile>()));
        }

        [Test]
        public void TestThatFindInitialEntryTileThrowsWhenPassingInInvalidTileList()
        {
            var invalidOneByOneForest = ForestBuilder.BuildForestOfSize(1, 1);
            
            invalidOneByOneForest.ElementAtCoordinates(1, 1)
                .SetTileXValueTo(InvalidXPositionValue)
                .SetTileYValueTo(InvalidYPositionValue);

            Assert.Throws<ArgumentOutOfRangeException>(
                () => _cookieForestParser.FindInitialEntryTile(invalidOneByOneForest));
        }

        [Test]
        public void TestThatFindInitialEntryTileThrowsWhenPassingInAValidTileInTheListThatHasThorns()
        {
            var validOneByOneForestWithThorns = ForestBuilder.BuildForestOfSize(1, 1);

            validOneByOneForestWithThorns.ElementAtCoordinates(1, 1).SetTileToHaveThorns();

            Assert.Throws<ArgumentOutOfRangeException>(
                () => _cookieForestParser.FindInitialEntryTile(validOneByOneForestWithThorns));
        }

        [Test]
        public void TestThatFindInitialEntryTileReturnsTileAt1X1()
        {
            var validOneByOneForestWithThorns = ForestBuilder.BuildForestOfSize(1, 1);

            var initialEntryTile = _cookieForestParser.FindInitialEntryTile(validOneByOneForestWithThorns);

            Assert.That(initialEntryTile, Is.Not.Null);
            Assert.That(initialEntryTile.X, Is.EqualTo(CookieForestParser.InitialXPosition));
            Assert.That(initialEntryTile.Y, Is.EqualTo(CookieForestParser.InitialYPosition));
        }

        [Test]
        public void TestThatFindInitialEntryTileReturnsTileAt1X1ForLargeList()
        {
            var validOneByOneForestWithThorns = ForestBuilder.BuildForestOfSize(10, 10);

            var initialEntryTile = _cookieForestParser.FindInitialEntryTile(validOneByOneForestWithThorns);

            Assert.That(initialEntryTile, Is.Not.Null);
            Assert.That(initialEntryTile.X, Is.EqualTo(CookieForestParser.InitialXPosition));
            Assert.That(initialEntryTile.Y, Is.EqualTo(CookieForestParser.InitialYPosition));
        }
    }
}
