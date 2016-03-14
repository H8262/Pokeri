using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokeri
{
    class Deck
    {
        List<Card> deck;

        public Deck()
        {
            deck = new List<Card>();
        }


        public void BuildDeck(Card card)
        {
            Random rng = new Random();
            for(int i = 0; i == 51; i++)
            {
                Card card1 = new Card();
                int suit = rng.Next(1, 5);
                int number = rng.Next(1, 14);


            }

            /*
            Card card1 = new Card { Suit = 0, Number = 1 };
            deck.Add(card1);
            Card card2 = new Card { Suit = 0, Number = 2 };
            deck.Add(card2);
            Card card3 = new Card { Suit = 0, Number = 3 };
            deck.Add(card3);       */ 
        }

        
    public void ScrambleDeck ()
        {
            int i = deck.Count;
                               
        }
    }
}
