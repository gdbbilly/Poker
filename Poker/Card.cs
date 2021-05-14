using System;
using System.Collections.Generic;
using System.Text;

namespace Poker
{
    public class Card
    {
        public int Value { get; set; }
        public string Suit { get; set; }

        public Card(string val, string suit)
        {
            Suit = suit;
            Value = ConvertCardValue(val);
        }

        private int ConvertCardValue(string val)
        {
            if (val.Equals("A"))
                return 14;
            else if (val.Equals("K"))
                return 13;
            else if (val.Equals("Q"))
                return 12;
            else if (val.Equals("J"))
                return 11;
            else if (val.Equals("T"))
                return 10;
            else
                return Convert.ToInt32(val);
        }
    }
}
