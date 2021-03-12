using System;
using System.Collections.Generic;

namespace Poker_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            // Generate a deck of cards (52 unique cards) with each card having a suite and a value
            Console.WriteLine("Generating a deck of cards...");
            Card[] deck = CreateCards();

            // Randomly deal 4 hands of 5 unique cards for each hand
            Hand[] hands = new Hand[4];

            for (int i = 0; i < 4; i++)
            {
                Hand hand = new Hand(PickFiveCards(ref deck));
                hands[i] = hand;

                Console.WriteLine($"Player {i + 1}\'s Hand: ");
                DisplayCards(hands[i].Cards);

                // Identify the hand types
                Console.WriteLine($"Hand Type: {HandClassifier.IdentifyHandType(hand).ToString()}");


            }


        }

        public static Card[] CreateCards()
        {
            Card[] newCards = new Card[52];

            int i = 0;
            
            for (int suit = 0; suit < 4; suit++)
            {
                for (int rank = 0; rank < 13; rank++)
                {
                    newCards[i++] = new Card(suit, rank);
                }
            }

            return newCards;
        }

        public static Card[] PickFiveCards(ref Card[] remainingCards)
        {
            Card[] randomCards = new Card[5];
            List<int> usedIndex = new List<int>();

            // Generates 5 random numbers between 0 and 51, that are not found in usedIndex list.
            int[] ranNums = GenerateRandomNumbers(5, usedIndex);

            for (int i = 0; i < 5; i++)
            {
                // Pick a random card from the remaining cards in the deck
                randomCards[i] = remainingCards[ranNums[i]];
            }

            return randomCards;

        }

        private static int[] GenerateRandomNumbers(int num, List<int> usedIndex)
        {
            Random rand = new Random();
            int number;

            for (int i = 0; i < num; i++)
            {
                do
                {
                    number = rand.Next(0, 51);
                } while (usedIndex.Contains(number));
                usedIndex.Add(number);
            }

            return usedIndex.ToArray();
        }

        public static void DisplayCards(Card[] cards)
        {
            foreach(Card c in cards)
            {
                Console.WriteLine($"Suit: {c.Suit} \tRank: {c.Rank}");
            }

            Console.WriteLine(new string ('=', 20));
        }
    }
}
