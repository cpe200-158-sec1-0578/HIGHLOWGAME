using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighLowCardGame
{
    class Deck
    {
        private List<Card> _DDeck;

        public List<Card> DDeck
        {
            get
            {
                return _DDeck;
            }
        }
        public Deck()
        {
            _DDeck = new List<Card>(52);

            for (int i = 1; i <=4; i++)
            {
                for (int j = 1; j <= 13; j++)
                {
                    _DDeck.Add(new Card(i, j));
                }
            }
            Shuffle();
        }
        public void Shuffle()
        {
            int size = _DDeck.Count;
            for (int i = 0; i < size; i++)
            {
                Random r = new Random(Guid.NewGuid().GetHashCode());
                int a = r.Next(0, 52);
                Card c = _DDeck[a];
                _DDeck[a] = _DDeck[i];
                _DDeck[i] = c;
            }
        }

        public void PrintDeck()
        {
            for (int i = 0; i < 52; i++)
            {
                _DDeck[i].PrintCard();
            }
        }
    }
}
