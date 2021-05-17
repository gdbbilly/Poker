using System.Collections.Generic;
using System.Linq;

namespace Poker
{
    public class Player
    {

        private List<Card> card = new List<Card>();
        private List<int> values = new List<int> { 0, 0, 0, 0, 0 };

        public Player(string cards)
        {
            card.Add(new Card(cards[0].ToString(), cards[1].ToString()));
            card.Add(new Card(cards[3].ToString(), cards[4].ToString()));
            card.Add(new Card(cards[6].ToString(), cards[7].ToString()));
            card.Add(new Card(cards[9].ToString(), cards[10].ToString()));
            card.Add(new Card(cards[12].ToString(), cards[13].ToString()));

            card.OrderBy(x => x.Value);
    
            setValueCardsToCompare();
        }

        public eRanking Rank()
        {
            bool straight = isStraight();
            bool flush = isFlush();
            bool fourKind = isFourKind();
            bool threeKind = isThreeKind();
            int pair = numOfPairs();

            if (straight && flush)
            {
                return eRanking.STRAIGHT_FLUSH;
            }
            if (fourKind)
            {
                return eRanking.FOUR_KIND;
            }
            if (threeKind && pair == 2)
            {
                return eRanking.FULL_HOUSE;
            }
            if (flush)
            {
                return eRanking.FLUSH;
            }
            if (straight)
            {
                return eRanking.STRAIGHT;
            }
            if (threeKind)
            {
                return eRanking.THREE_KIND;
            }
            if (pair == 2)
            {
                return eRanking.TWO_PAIR;
            }
            if (pair == 1)
            {
                return eRanking.PAIR;
            }
            return eRanking.HIGH_CARD;
        }

        public List<int>  CardsValue()
        {
            return values;
        }

        private bool isStraight()
        {
            for (int i = 0; i < 4; i++)
            {
                if (card[i].Value + 1 != card[i + 1].Value)
                {
                    return false;
                }
            }
            return true;
        }
        private bool isFlush()
        {
            for (int i = 0; i < 4; i++)
            {
                if (card[i].Suit != card[i + 1].Suit)
                {
                    return false;
                }
            }
            return true;
        }
        private bool isFourKind()
        {
            //trocar para uma logica com distinct
            if (card[0].Value == card[1].Value && card[1].Value == card[2].Value && card[2].Value == card[3].Value)
            {
                return true;
            }
            if (card[1].Value == card[2].Value && card[2].Value == card[3].Value && card[3].Value == card[4].Value)
            {
                return true;
            }
            return false;
        }
        private bool isThreeKind()
        {
            if (card[0].Value == card[2].Value)
            {
                return true;
            }
            if (card[1].Value == card[3].Value)
            {
                return true;
            }
            if (card[2].Value == card[4].Value)
            {
                return true;
            }
            return false;
        }
        private int numOfPairs()
        {
            int count = 0;
            for (int i = 0; i < 4; i++)
            {
                if (card[i].Value == card[i + 1].Value)
                {
                    count++;
                    i++;
                }
            }
            return count;
        }
        private void setValueCardsToCompare()
        {
            switch (Rank())
            {
                case eRanking.STRAIGHT_FLUSH:
                case eRanking.STRAIGHT:
                    values[0] = card[4].Value;
                    break;
                case eRanking.FLUSH:
                case eRanking.HIGH_CARD:
                    for (int i = 0; i < 5; ++i)
                    {
                        values[i] = card[4 - i].Value;
                    }
                    break;
                case eRanking.FULL_HOUSE:
                case eRanking.FOUR_KIND:
                case eRanking.THREE_KIND:
                    values[0] = card[2].Value;
                    break;
                case eRanking.TWO_PAIR:
                    
                    if (card[0].Value != card[1].Value)
                    {
                        values[0] = card[4].Value;
                        values[1] = card[2].Value;
                        values[2] = card[0].Value;
                    }
                    else if (card[2].Value != card[3].Value)
                    { 
                        values[0] = card[4].Value;
                        values[1] = card[0].Value;
                        values[2] = card[2].Value;
                    }
                    else
                    { 
                        values[0] = card[2].Value;
                        values[1] = card[0].Value;
                        values[2] = card[4].Value;
                    }
                    break;
                case eRanking.PAIR:
                    int pairValue = 0;
                    for (int i = 0; i < 3; ++i)
                    {
                        if (card[i].Value == card[i + 1].Value)
                        {
                            pairValue = card[i].Value;
                            break;
                        }
                    }
                    values[0] = pairValue;

                    for (int i = 4, r = 1; i >= 0; i--)
                    { 
                        if (card[i].Value == pairValue)
                        {
                            continue;
                        }
                        values[r++] = card[i].Value;
                    }
                    break;
            }
        }
    }
}
