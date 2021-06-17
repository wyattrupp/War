using NUnit.Framework;
using War;
using System.Linq;
using System.Collections.Generic;
using War.enums;

namespace WarUnitTests
{
    public class Tests
    {

        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void TestConstructor()
        {
            // Arrange
            var card = new Card { Rank = War.enums.Rank.ace, Suit = War.enums.Suit.Clubs };
            var cards = new Card[] { card };

            // Act
            var deck = new Deck(cards);

            // Assert
            Assert.AreEqual(1, deck.Cards.Length);
            Assert.AreSame(cards, deck.Cards);
        }

        [Test]
        public void TestDraw1()
        {
            // Arrange
            var card = new Card { Rank = War.enums.Rank.ace, Suit = War.enums.Suit.Clubs };
            var cards = new Card[] { card, card, card };
            var deck = new Deck(cards);

            // Act
            deck.TakeCard();

            //Assert
            // Ensure one card is removed when this is called
            Assert.AreEqual(2, deck.Cards.Length);

        }

        [Test]
        public void TestDraw3()
        {
            // Arrange
            var card = new Card { Rank = War.enums.Rank.ace, Suit = War.enums.Suit.Clubs };
            var cards = new Card[] { card, card, card };
            var deck = new Deck(cards);

            //Act
            // Ensure no cards are left once this is called
            deck.TakeCards(3);

            //Assert
            Assert.AreEqual(0, deck.Cards.Length);
        }

        [Test]
        public void TestDraw0()
        {
            // Arrange
            var card = new Card { Rank = War.enums.Rank.ace, Suit = War.enums.Suit.Clubs };
            var cards = new Card[] { card, card, card };
            var deck = new Deck(cards);

            //Act
            // Ensure no cards are left once this is called
            deck.TakeCards(0);

            //Assert
            Assert.AreEqual(3, deck.Cards.Length);
        }

        [Test]
        public void TestAppend()
        {
            // Arrange
            var card = new Card { Rank = War.enums.Rank.ace, Suit = War.enums.Suit.Clubs };
            var cards = new Card[] { card, card, card };
            var deck = new Deck(cards);

            //Act
            // Ensure no cards are left once this is called
            deck.AppendCards(cards.ToList());

            //Assert
            Assert.AreEqual(6, deck.Cards.Length);
        }

        [Test]
        public void TestInitializeMasterDeck()
        {
            // Arrange
            var deck = new Deck();
            Setup();

            //Act
            // Ensure no cards are left once this is called
            deck.InitializeMasterDeck();

            //Assert
            Assert.AreEqual(52, deck.Cards.Length);
        }


    }
}