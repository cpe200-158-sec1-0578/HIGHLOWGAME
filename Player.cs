using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighLowCardGame
{
    class Player
    {
        private List<Card> _pile;
        private string _Name;
        private int _Count;
        private Card _currentCard;

        public List<Card> Pile
        {
            get
            {
                return _pile;
            }
        }
        public Card currentCard
        {
            get
            {
                return _currentCard;
            }
        }
        public string Name
        {
            get
            {
                return _Name;
            }
        }
        public int Count
        {
            get
            {
                return _Count;
            }
        }
        public Player(string name, int i, Deck D)
        {
            _Name = name;
            _pile = new List<Card>(26);

            for (int j = 0; j < 26; j++, i++)
            {
                _pile.Add(D.DDeck[i]);
            }
            //PrintPile();
        }
        public void PrintPile()
        {
            for (int i = 0; i < _pile.Count; i++)
            {
                Console.WriteLine(_pile[i].Values + " " + _pile[i].Suit);
            }
        }
        public void Dealing(int Deal = 1)
        {
            _currentCard = Pile[Deal - 1];
            Console.Write(_Name + ": " + _currentCard.GetNameSuit() + "\t");
        }

        public void Take(int Deal = 1)
        {
            _Count += Deal * 2;
        }

        public void Remove(int Deal = 1)
        {
            _pile.RemoveRange(0, Deal);
        }

        public void Shuffle()
        {
            int size = _pile.Count;
            for (int i = 0; i < size; i++)
            {
                Random r = new Random(Guid.NewGuid().GetHashCode());
                int a = r.Next(0, size);
                Card c = _pile[a];
                _pile[a] = _pile[i];
                _pile[i] = c;
            }
        }
    }
}
