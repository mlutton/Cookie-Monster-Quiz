﻿using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace CookieMonsterQuiz.Tests.Unit
{
    [TestFixture]
    class FindInitialEntryTileTests
    {
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
                () => _cookieForestParser.FindInitialEntryTile(new List<CookieMonsterTile>()));
        }

        [Test]
        public void TestThatFindInitialEntryTileThrowsWhenPassingInInvalidTileList()
        {
            var invalidOneByOneForest = new List<CookieMonsterTile> {new CookieMonsterTile() {X = 9999, Y = 9999}};

            Assert.Throws<ArgumentOutOfRangeException>(
                () => _cookieForestParser.FindInitialEntryTile(invalidOneByOneForest));
        }

        [Test]
        public void TestThatFindInitialEntryTileThrowsWhenPassingInAValidTileInTheListThatHasThorns()
        {
            var validOneByOneForestWithThorns = new List<CookieMonsterTile>
            {
                new CookieMonsterTile() {X = 1, Y = 1, CookieCount = CookieMonsterTile.TileHasThorns}
            };

            Assert.Throws<ArgumentOutOfRangeException>(
                () => _cookieForestParser.FindInitialEntryTile(validOneByOneForestWithThorns));
        }

        [Test]
        public void TestThatFindInitialEntryTileReturnsTileAt1X1()
        {
            var validOneByOneForestWithThorns = new List<CookieMonsterTile>
            {
                new CookieMonsterTile() {X = 1, Y = 1, CookieCount = 0}
            };

            var initialEntryTile = _cookieForestParser.FindInitialEntryTile(validOneByOneForestWithThorns);

            Assert.That(initialEntryTile, Is.Not.Null);
            Assert.That(initialEntryTile.X, Is.EqualTo(CookieForestParser.InitialXPosition));
            Assert.That(initialEntryTile.Y, Is.EqualTo(CookieForestParser.InitialYPosition));
        }
    }
}
