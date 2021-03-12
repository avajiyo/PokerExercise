using System;
using System.Collections.Generic;
using System.Text;

namespace Poker_Exercise
{
    class Card
    {

        private readonly string[] _ranks = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };
        private readonly string[] _suites = { "Diamond", "Spade", "Heart", "Club" };

        public string Rank { get; set; }
        public int RankIndex { get; set; }
        public string Suit { get; set; }
        public int SuitIndex { get; set; }

        public Card(int suit, int rank)
        {
            Rank = _ranks[rank];
            Suit = _suites[suit];

            RankIndex = rank;
            SuitIndex = suit;
        }
    }

    class Hand
    {
        public Card[] Cards { get; set; }
        public Hand(Card[] cards)
        {
            Cards = cards;
        }
    }
}
