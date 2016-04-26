﻿using System;
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
        Random random = new Random();
        public Deck()
        {
            deck = new List<Card>();
        }


        public void BuildDeck(Card card)
        {
            for(int i = 0;i<4;i++)
            {
                for(int v=0;v<13;v++)
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

        public Card ServeCard()
        {
            /*            
            int rand1 = random.Next(0, 4);
            int rand2 = random.Next(0, 13);
            */
            bool onnistui = true;

            int index = random.Next(0, deck.Count);
            Card card = deck.ElementAt(index);
            
            onnistui = deck.Remove(card);
            if(onnistui == false)
            {
                ServeCard();
                Debug.WriteLine("Jako epäonnistui --> uudestaan");
            }
            Debug.WriteLine("Jako onnistui " + deck.Count + " " + index);
            return card;

            /*foreach (Card card in deck)
            {
                // kortti tuo arvottu
                if (card.Number == rand2 && card.Suit == rand1)
                {
                    
                    Debug.WriteLine("Poistettu " + deck.Count);
                    Card card111 = new Card { Suit = rand1, Number = rand2 };
                    return card111;                    
                }
            }
            return null;
            */
        }

        /*do
        {
            if (deck.Contains(new Card { Suit = rand1, Number = rand2 }))
            {
                deck.Remove(new Card { Suit = rand1, Number = rand2 });
                Card ServeCard = new Card { Suit = rand1, Number = rand2 };
                i = 1;                 
                return new Card { Suit = rand1, Number = rand2 };
            }
            else
            {
                return new Card { Suit = 5, Number = 20 };
            }
        } while (i == 0);
    }*/

        public void DebugList ()
        {
            foreach (Card card in deck)
            {
                Debug.WriteLine(card.Suit + " " + card.Number);
            }
        }
        public void RemoveDeck()
        {
            deck.Clear();
        }

    }
}
