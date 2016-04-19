using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokeri
{
    class Hand
    {
        List<Card> hand;

        public Hand()
        {
            hand = new List<Card>();
        }

        public void AddCard(Card card)
        {
            hand.Add(card);
        }
        public void ShowHands()
        {           

            foreach (Card card in hand)
            {
                Debug.WriteLine(" " + card.Suit + " " + card.Number);
            }
        }

        public int GetHandValues()
        {
            if (Suora() == true && Vari() == true) { return 10; }
            if (Neloset() == true) { return 9; }
            if (Vari() == true) { return 7; }
            if (Suora() == true) { return 6; }
            else return 0;

        }

        public bool Suora()
        {
            int h = 0;
            int k = 0;
            int z = 0;
            int f = hand.Count;


            foreach(Card card in hand)
            {
                h = card.Number;
                foreach(Card card1 in hand)
                {
                    k = card.Number;
                    if (h+1 == k)
                    {
                        z++;
                    }
                }
            }
                                    
            if (z >= 5)
            {
                return true;
            }
            else return false;
        }
        public bool Vari()
        {
            int h = 0;
            int k = 0;
            int z = 0;
            foreach(Card card in hand)
            {
                h = card.Suit;

                foreach(Card card1 in hand)
                {
                    k = card.Suit;
                    if(h == k)
                    {
                        z++;
                    }
                }
            }
            z -= hand.Count();
            if (z >= 5)
            {
                return true;
            }
            else return false;
        }
        public bool Neloset()
        {
            int h = 0;
            int k = 0;            
            foreach(Card card in hand)
            {
                int z = 0;
                h = card.Number;
                foreach(Card card1 in hand)
                {
                    if (card != card1)
                    {
                        k = card.Number;
                        if (h == k)
                        { z++; }
                    }
                }
                if (z == 3) return true;                    
            }
            return false;
        }
    }
}
