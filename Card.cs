using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighLowCardGame
{
    class Card
    {
        private int _Suit;
        private int _Values;
        private string[] suit = { "Hearts", "Diamonds", "Clubs", "Spades" };
        private string[] face = { "Ace", "Jack", "Queen", "King" };

        public Card(int s,int v)
        {
            _Values = v;
            _Suit = s;
        }

        public int Suit
        {
            get
            {
                return _Suit;
            }
            set
            {
                _Suit = value;
            }
        }
        public int Values
        {
            get
            {
                return _Values;
            }
            set
            {
                _Values = value;
            }
        }
        public void PrintCard()
        {
            Console.WriteLine(_Values + " " + _Suit);
        }

        public string GetNameSuit()
        {
            string ncard = "";
            if (_Values == 1) { ncard = face[0]; }
            else if (_Values == 11) { ncard = face[1]; }
            else if (_Values == 12) { ncard = face[2]; }
            else if (_Values == 13) { ncard = face[3]; }
            else { ncard = _Values.ToString(); }
            return ncard + " of " + suit[_Suit-1];
        }
    }
}
