using System;
using System.Collections.Generic;

namespace War
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press Enter to begin the game of War.");
            Console.Read();

            // Set up the master deck and shuffle it
            Deck masterDeck = new();
            masterDeck.InitializeMasterDeck();
            masterDeck.Shuffle();

            // Distribute the cards to each player
            Deck player1Deck = new(masterDeck.TakeCards(26));
            Deck player2Deck = new(masterDeck.TakeCards(26));

            // Begin the match
            List<Card> fieldCards;
            while (player1Deck.Cards.Length != 52 && player2Deck.Cards.Length != 52)
            {
                // Clear the field before each turn
                fieldCards = new();

                // Play the turn
                War(player1Deck, player2Deck, fieldCards);
            }

            // Determine and print the results of the match
            if (player1Deck.Cards.Length == 52)
            {
                Console.WriteLine("PLAYER 1 WINS!!!");
            }
            else if (player2Deck.Cards.Length == 52)
            {
                Console.WriteLine("PLAYER 2 WINS!!!");
            }

            Console.WriteLine("Game over!");
        }

        private static List<Card> War(Deck player1Deck, Deck player2Deck, List<Card> fieldCards)
        {
            if(player1Deck.Cards.Length == 0)
            {
                // Player1 doesn't have enough cards to continue the war. They lose!
                player2Deck.AppendCards(fieldCards);
                return null;
            }

            if (player2Deck.Cards.Length == 0)
            {
                // Player1 doesn't have enough cards to continue the war. They lose!
                player1Deck.AppendCards(fieldCards);
                return null;
            }

            fieldCards.Add(player1Deck.TakeCard());
            fieldCards.Add(player2Deck.TakeCard());

            if (fieldCards[^1].Rank < fieldCards[^2].Rank)
            {
                // Player 1 won the matchup, give them the cards
                player1Deck.AppendCards(fieldCards);
            }
            else if (fieldCards[^1].Rank > fieldCards[^2].Rank)
            {
                // Player 2 won the matchup, give them the cards
                player2Deck.AppendCards(fieldCards);
            }
            else
            {
                // Ensure that each player's deck contains enough cards for war. If not, they lose.
                if (player1Deck.Cards.Length < 4)
                {
                    // Player1 doesn't have enough cards to continue the war. They lose!
                    fieldCards.AddRange(player1Deck.TakeCards(player1Deck.Cards.Length));
                    player2Deck.AppendCards(fieldCards);
                    return null;
                }

                if (player2Deck.Cards.Length < 4)
                {
                    // Player1 doesn't have enough cards to continue the war. They lose!
                    fieldCards.AddRange(player2Deck.TakeCards(player2Deck.Cards.Length));
                    player1Deck.AppendCards(fieldCards);
                    return null;
                }
                // War. Put down 3 cards each "face down", then recurse to do the 1 card each "face up" for comparison.
                fieldCards.AddRange(player1Deck.TakeCards(3));
                fieldCards.AddRange(player2Deck.TakeCards(3));
                War(player1Deck, player2Deck, fieldCards);
            }

            return fieldCards;
        }
    }
}
