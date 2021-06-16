using System;

namespace War
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck player1Deck = new();
            Deck player2Deck = new();
            Deck masterDeck = new();
            masterDeck.InitializeMasterDeck();
            masterDeck.Shuffle();
            player1Deck = new(masterDeck.TakeCards(26));
            player2Deck = new(masterDeck.TakeCards(26));

            while(player1Deck.Cards.Length != 52 && player2Deck.Cards.Length != 52)
            {

            }

            if(player1Deck.Cards.Length == 52)
            {
                Console.WriteLine("PLAYER 1 WINS!!!");
            }
            else if (player2Deck.Cards.Length == 52)
            {
                Console.WriteLine("PLAYER 2 WINS!!!");
            }
            else
            {
                Console.WriteLine("You really shouldn't be here...");
            }

            Console.WriteLine("YEET");
        }
    }
}
