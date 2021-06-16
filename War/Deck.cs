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
        /// Initializes a new instance of the <see cref="T:War.Deck"/> class. 
        /// Allows you to specify a list of cards within the new deck.
        /// </summary>
        /// <param name="cards">The cards you wish to populate the new deck with.</param>
        public Deck(Card[] cards)
        {
            Cards = cards;
        }


        /// <summary>
        /// Initializes a master deck with 52 default cards.
        /// </summary>
        public void InitializeMasterDeck()
        {
            List<Card> cards = new();
            Suit[] suits = new Suit[] { Suit.Clubs, Suit.Diamonds, Suit.Hearts, Suit.Spades };
            Color[] colors = new Color[] { Color.Black, Color.Red };
            foreach (var color in colors)
            {
                foreach (var suit in suits)
                {
                    cards.Add(new Card() { Color = color, Rank = Rank.ace, Suit = suit });
                    cards.Add(new Card() { Color = color, Rank = Rank.two, Suit = suit });
                    cards.Add(new Card() { Color = color, Rank = Rank.three, Suit = suit });
                    cards.Add(new Card() { Color = color, Rank = Rank.four, Suit = suit });
                    cards.Add(new Card() { Color = color, Rank = Rank.five, Suit = suit });
                    cards.Add(new Card() { Color = color, Rank = Rank.six, Suit = suit });
                    cards.Add(new Card() { Color = color, Rank = Rank.seven, Suit = suit });
                    cards.Add(new Card() { Color = color, Rank = Rank.eight, Suit = suit });
                    cards.Add(new Card() { Color = color, Rank = Rank.nine, Suit = suit });
                    cards.Add(new Card() { Color = color, Rank = Rank.ten, Suit = suit });
                    cards.Add(new Card() { Color = color, Rank = Rank.jack, Suit = suit });
                    cards.Add(new Card() { Color = color, Rank = Rank.queen, Suit = suit });
                    cards.Add(new Card() { Color = color, Rank = Rank.king, Suit = suit });
                }
            }

            Cards = cards.ToArray();
        }

        /// <summary>
        /// Shuffle this instance.
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

        public Card[] TakeCards(int numberOfCards)
        {
            // Get the requested amount of cards from the deck
            Card[] requestedCards = Cards.Take(numberOfCards).ToArray();
            // Remove the cards that have been taken from the current deck
            Cards = Cards.Skip(numberOfCards).ToArray();
            return requestedCards;
        }

        /// <summary>
        /// Take cards and append them to the current Deck
        /// </summary>
        /// <param name="addedCards"></param>
        public void AppendCards(Card[] addedCards)
        {
            int newlength = Cards.Length + addedCards.Length;
            Card[] newCards = new Card[newlength];

            // Add existing cards to new array
            for (int x = 0; x < Cards.Length; x++)
            {
                newCards[x] = Cards[x];
            }

            // Add new cards to new array
            for (int z = Cards.Length; z < addedCards.Length; z++)
            {
                addedCards[z] = addedCards[z];
            }

            Cards = newCards;
        }

        /// <summary>
        /// Releases all resource used by the <see cref="T:War.Deck"/> object.
        /// </summary>
        /// <remarks>Call <see cref="Dispose"/> when you are finished using the <see cref="T:War.Deck"/>. The
        /// <see cref="Dispose"/> method leaves the <see cref="T:War.Deck"/> in an unusable state. After calling
        /// <see cref="Dispose"/>, you must release all references to the <see cref="T:War.Deck"/> so the garbage
        /// collector can reclaim the memory that the <see cref="T:War.Deck"/> was occupying.</remarks>
        public void Dispose()
        {
            Array.Clear(Cards, 0, Cards.Length);
        }
    }
}