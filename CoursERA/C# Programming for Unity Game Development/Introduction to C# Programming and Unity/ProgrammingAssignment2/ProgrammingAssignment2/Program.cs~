using System;

namespace ProgrammingAssignment2
{
    /// <summary>
    /// Programming Assignment 2 solution
    /// </summary>
    class MainClass
    {
        /// <summary>
        /// Deals 2 cards to 3 players and displays cards for players
        /// </summary>
        /// <param name="args">command-line arguments</param>
        public static void Main(string[] args)
        {
            // print welcome message
            Console.WriteLine("=== Welcome to BlackJack ===");
            Console.WriteLine();

            // create and shuffle a deck
            Deck deck = new Deck();
            deck.Shuffle();

            // deal 2 cards each to 3 players (deal properly, dealing
            // the first card to each player before dealing the
            // second card to each player)
            Card player1_Card1 = deck.TakeTopCard();
            Card player2_Card1 = deck.TakeTopCard();
            Card player3_Card1 = deck.TakeTopCard();

            Card player1_Card2 =  deck.TakeTopCard();
            Card player2_Card2 =  deck.TakeTopCard();
            Card player3_Card2 =  deck.TakeTopCard();

            // flip all the cards over

            player1_Card1.FlipOver();
            player2_Card1.FlipOver();
            player3_Card1.FlipOver();


            player1_Card2.FlipOver();
            player2_Card2.FlipOver();
            player3_Card2.FlipOver();

            // print the cards for player 1
            Console.WriteLine("Player1_Card1 == Rank - " + player1_Card1.Rank + " -- Suit - " + player1_Card1.Suit);
            Console.WriteLine("Player1_Card2 == Rank - " + player1_Card2.Rank + " -- Suit - " + player1_Card2.Suit);
            Console.WriteLine();

            // print the cards for player 2
            Console.WriteLine("Player2_Card1 == Rank - " + player2_Card1.Rank + " -- Suit - " + player2_Card1.Suit);
            Console.WriteLine("Player2_Card2 == Rank - " + player2_Card2.Rank + " -- Suit - " + player2_Card2.Suit);
            Console.WriteLine();

            // print the cards for player 3
            Console.WriteLine("Player3_Card1 == Rank - " + player3_Card1.Rank + " -- Suit - " + player3_Card1.Suit);
            Console.WriteLine("Player3_Card2 == Rank - " + player3_Card2.Rank + " -- Suit - " + player3_Card2.Suit);
          

            Console.WriteLine();
        }
    }
}
