using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            for(int i = 0;i<4;i++)
            {
                for(int v=0;v<14;v++)
                {
                    deck.Add(new Card { Suit = i,Number=v});
                }
            }


        }
            /*
            Card card1 = new Card { Suit = 0, Number = 1 };
            deck.Add(card1);
            Card card2 = new Card { Suit = 0, Number = 2 };
            deck.Add(card2);
            Card card3 = new Card { Suit = 0, Number = 3 };
            deck.Add(card3);       */ 
        

        
    public void ScrambleDeck ()
        {
            int i = deck.Count;
                               
        }
    public void DebugList ()
        {
            foreach (Card card in deck)
            {
                Debug.WriteLine(card.Suit + " " + card.Number);
            }
        }
    }
}
