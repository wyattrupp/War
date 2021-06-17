using System;
using System.Collections.Generic;
using System.Linq;
using War.enums;

namespace War
{
    public class Deck
    {
        public Card[] Cards;


        public Deck()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Card"/> class. 
        /// Allows you to specify a list of <see cref="Card"/>s within the new <see cref="Deck"/>.
        /// </summary>
        /// <param name="cards">The <see cref="Card"/>s you wish to populate the new <see cref="Deck"/> with.</param>
        public Deck(Card[] cards)
        {
            Cards = cards;
        }


        /// <summary>
        /// Initializes a master <see cref="Deck"/> with 52 standard <see cref="Card"/>s.
        /// </summary>
        public void InitializeMasterDeck()
        {
            List<Card> cards = new();
            Suit[] suits = new Suit[] { Suit.Clubs, Suit.Diamonds, Suit.Hearts, Suit.Spades };

            foreach (var suit in suits)
            {
                cards.Add(new Card() { Rank = Rank.ace, Suit = suit });
                cards.Add(new Card() { Rank = Rank.two, Suit = suit });
                cards.Add(new Card() { Rank = Rank.three, Suit = suit });
                cards.Add(new Card() { Rank = Rank.four, Suit = suit });
                cards.Add(new Card() { Rank = Rank.five, Suit = suit });
                cards.Add(new Card() { Rank = Rank.six, Suit = suit });
                cards.Add(new Card() { Rank = Rank.seven, Suit = suit });
                cards.Add(new Card() { Rank = Rank.eight, Suit = suit });
                cards.Add(new Card() { Rank = Rank.nine, Suit = suit });
                cards.Add(new Card() { Rank = Rank.ten, Suit = suit });
                cards.Add(new Card() { Rank = Rank.jack, Suit = suit });
                cards.Add(new Card() { Rank = Rank.queen, Suit = suit });
                cards.Add(new Card() { Rank = Rank.king, Suit = suit });
            }

            Cards = cards.ToArray();
        }

        /// <summary>
        /// Shuffle this <see cref="Deck"/> instance.
        /// </summary>
        public void Shuffle()
        {
            Random rng = new();
            int n = Cards.Length;

            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card value = Cards[k];
                Cards[k] = Cards[n];
                Cards[n] = value;
            }
        }

        /// <summary>
        /// Take a specified number of <see cref="Card"/>s from this <see cref="Deck"/> instance.
        /// </summary>
        /// <param name="numberOfCards">The number of <see cref="Card"/>s you want to take off the <see cref="Deck"/>.</param>
        /// <returns>The requested amount of <see cref="Card"/>s</returns>
        public Card[] TakeCards(int numberOfCards)
        {

            if (numberOfCards > Cards.Length)
            {
                throw new Exception("You cannot take more cards than are in the deck");
            }

            // Get the requested amount of cards from the deck
            Card[] requestedCards = Cards.Take(numberOfCards).ToArray();

            // Remove the cards that have been taken from the current deck
            Cards = Cards.Skip(numberOfCards).ToArray();

            return requestedCards;
        }

        /// <summary>
        /// Take a single <see cref="Card"/> from this <see cref="Deck"/> instance
        /// </summary>
        /// <returns>A single <see cref="Card"/></returns>
        public Card TakeCard()
        {

            if (Cards.Length < 1)
            {
                throw new Exception("You cannot take more cards than are in the deck");
            }

            // Get the requested amount of cards from the deck
            Card firstCard = Cards.First();
            // Remove the cards that have been taken from the current deck
            Cards = Cards.Skip(1).ToArray();
            return firstCard;
        }

        /// <summary>
        /// Take a list of <see cref="Card"/>s and append them to the current <see cref="Deck"/>
        /// </summary>
        /// <param name="addedCards">The <see cref="Card"/>s you wish to add to the <see cref="Deck"/></param>
        public void AppendCards(List<Card> addedCards)
        {
            Card[] cards = addedCards.ToArray(); // Convert to array for more efficient appending
            int newlength = Cards.Length + cards.Length;
            Card[] newCards = new Card[newlength];

            // Add existing cards to new array
            for (int x = 0; x < Cards.Length; x++)
            {
                newCards[x] = Cards[x];
            }

            // Add new cards to new array
            for (int z = 0; z < cards.Length; z++)
            {
                newCards[z + Cards.Length] = cards[z];
            }

            Cards = newCards;
        }

    }
}