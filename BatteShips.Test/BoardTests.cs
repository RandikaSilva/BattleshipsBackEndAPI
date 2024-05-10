using NUnit.Framework;
using BattleShips.Engines;
using System;

namespace BattleShips.Test
{
    [TestFixture]
    public class BoardTests
    {
        private Board _board;

        [SetUp]
        public void SetUp()
        {
            _board = new Board();
        }

        [Test]
        public void PlaceShipsRandomly_ShipsPlacedSuccessfully()
        {
            // Act
            _board.PlaceShipsRandomly();

            // Assert
            Assert.That(_board.GetBoardState(), Has.Some.EqualTo('S'));
        }

        [Test]
        public void ValidateCoordinates_ValidCoordinates_ReturnsExpectedResult()
        {
            // Act
            _board.PlaceShipsRandomly();

            // Assert
            Assert.That(_board.GetBoardState(), Has.Some.EqualTo('S'));
        }

        [TestCase("A1", "user", ExpectedResult = true)]
        [TestCase("J10", "user", ExpectedResult = true)]
        [TestCase("A1", "computer", ExpectedResult = true)]
        [TestCase("J10", "computer", ExpectedResult = true)]
        [TestCase("K1", "user", ExpectedResult = false)]
        [TestCase("A0", "user", ExpectedResult = false)]
        [TestCase("A", "user", ExpectedResult = false)]
        [TestCase("11", "user", ExpectedResult = false)]
        public bool ValidateCoordinates_ValidCoordinates_ReturnsExpectedResult(string coordinates, string userType)
        {
            // Act
            return _board.ValidateCoordinates(coordinates, userType);
        }

    }
}
