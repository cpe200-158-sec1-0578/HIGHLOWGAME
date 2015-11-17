using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighLowCardGame
{
    class Gameplay
    {
        private Player Player1, Player2;
        private Deck pDeck;

        public Gameplay()
        {
            pDeck = new Deck();
            creatPlayer();
            PlayLoop();
        }
        public void creatPlayer()
        {
            string p1name, p2name;
            Console.Write("Please enter first player name: ");
            p1name = Console.ReadLine();
            Console.Write("Please enter second player name: ");
            p2name = Console.ReadLine();
            Player1 = new Player(p1name, 0, pDeck);
            Console.WriteLine();
            Player2 = new Player(p2name, 26, pDeck);
        }
        public void PlayLoop() 
        {
            while (Player1.Pile.Count > 0 && Player2.Pile.Count > 0)
            {
                Player1.Dealing();
                Player2.Dealing();

                Console.WriteLine(Check());
                Console.ReadKey();
            }
            if (Player1.Count > Player2.Count) { Console.WriteLine("\n" + Player1.Name + "  WIN! "); }
            else if (Player1.Count < Player2.Count) { Console.WriteLine("\n" + Player2.Name + "  WIN! "); }
            else { Console.WriteLine("\n Tie"); }
        }

        public string Check()
        {
            string result = "";

            if (Player1.currentCard.Values > Player2.currentCard.Values)
            {
                Player2.Take();
                Player2.Remove();
                Player1.Remove();

                result = Player2.Name + " WIN! " + "(" + Player1.Name + "= " + Player1.Count + " " + Player2.Name + "= " + Player2.Count + " )";
            }
            else if (Player1.currentCard.Values < Player2.currentCard.Values)
            {
                Player1.Take();
                Player1.Remove();
                Player2.Remove();

                result = Player1.Name + " WIN! " + "(" + Player1.Name + "= " + Player1.Count + " " + Player2.Name + "= " + Player2.Count + " )";
            }
            else if (Player1.currentCard.Values == Player2.currentCard.Values)
            {
                Console.WriteLine(" Draw! ");
                int j = Player1.currentCard.Values;

                if (j < Player1.Pile.Count && j < Player2.Pile.Count)
                {
                    Player1.Dealing(Player1.currentCard.Values + 1);
                    Player2.Dealing(Player2.currentCard.Values + 1);

                    Console.Write(CheckAgain(j));
                }
                else if (Player1.Pile.Count != 1 || Player2.Pile.Count != 1)
                {
                    Player1.Shuffle();
                    Player2.Shuffle();

                    Console.WriteLine("not enough card, ....Shuffling....\n\n Press any key to Continue");
                }
                else if (Player1.Pile.Count == 1 || Player2.Pile.Count == 1)
                {
                    Player1.Remove();
                    Player2.Remove();

                    Console.WriteLine("Last Card, Game will END");
                }
            }
            return result;
        }

        public string CheckAgain(int k)
        {
            string result = "";


            if (Player1.currentCard.Values > Player2.currentCard.Values)
            {
                Player2.Take(k + 1);
                Player2.Remove(k + 1);
                Player1.Remove(k + 1);

                result = Player2.Name + " WIN! " + "(" + Player1.Name + "= " + Player1.Count + " " + Player2.Name + "= " + Player2.Count + " )";
            }
            else if (Player1.currentCard.Values < Player2.currentCard.Values)
            {
                Player1.Take(k + 1);
                Player1.Remove(k + 1);
                Player2.Remove(k + 1);

                result = Player1.Name + " WIN! " + "(" + Player1.Name + "= " + Player1.Count + " " + Player2.Name + "= " + Player2.Count + " )";
            }
            else if (Player1.currentCard.Values == Player2.currentCard.Values)
            {
                Console.WriteLine(" Draw! ");

                Player1.Shuffle();
                Player2.Shuffle();

                Console.WriteLine(" Press any key to Continue ");
            }
            return result;
        }
    }
}
