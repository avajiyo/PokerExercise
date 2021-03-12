using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Poker_Exercise
{
    class HandClassifier
    {
        public enum HandType
        {
            StraightFlush, FourOfAKind, FullHouse, Flush, Straight, ThreeOfAKind, TwoPair, OnePair, HighCard
        }

        public static HandType IdentifyHandType(Hand hand)
        {

            bool isFlush = false;
            bool isStraight = false;
            bool hasTwoPair = false;


            int[] rankCounter = new int[13];
            foreach (Card card in hand.Cards)
            {
                // First, count how often each rank in the hand appears.
                for (int i = 0; i < 13; i++)
                {
                    if (card.RankIndex == i)
                    {
                        rankCounter[i]++;
                    }
                }
            }

            // Sorting 
            hand.Cards = hand.Cards.Where(x => x != null).OrderBy(x => x.SuitIndex).ToArray();




            // If there are 3 cards that have the same suit as their neighbours, it is a flush.
            int matchingSuit = 0;
            for (int i = 0; i < 4; i++)
            {
                if (hand.Cards[i].SuitIndex == hand.Cards[i + 1].SuitIndex)
                {
                    matchingSuit++;
                }
            }

            if(matchingSuit == 3)
            {
                isFlush = true;
            } else if(matchingSuit == 1)
            {
                hasTwoPair = true;
            }

            // Sorting hand by rank
            hand.Cards = hand.Cards.Where(x => x != null).OrderBy(x => x.RankIndex).ToArray();

            // If the highest rank - lowest rank is 4, it is a Straight.
            int highestCardRank = hand.Cards[4].RankIndex;
            int lowestCardRank = hand.Cards[0].RankIndex;

            if(highestCardRank - lowestCardRank == 4)
            {
                isStraight = true;
            }


            if(isStraight && isFlush)
            {
                return HandType.StraightFlush;
            }
            // Determine the hands based on the number of occurences of the same rank
            else if (rankCounter[0] == 4 && rankCounter[1] == 1)
            {
                return HandType.FourOfAKind;
            }
            else if (rankCounter[0] == 3 && rankCounter[1] == 2)
            {
                return HandType.FullHouse;
            }
            else if (isFlush)
            {
                return HandType.Flush;
            }
            else if (isStraight)
            {
                return HandType.Straight;
            }
            else if (rankCounter[0] == 3 && rankCounter[1] == 1 && rankCounter[2] == 1)
            {
                return HandType.ThreeOfAKind;
            }
            else if (hasTwoPair)
            {
                return HandType.TwoPair;
            }
            else if (rankCounter[0] == 4 && rankCounter[1] == 0)
            {
                return HandType.OnePair;
            }
            else
            {
                return HandType.HighCard;
            }

        }
    }
}
