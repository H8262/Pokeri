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
            if (Suora() == true && Vari() == true) return 10;
            if (Neloset() == true) return 9;
            if (TaysKasi() == true) return 8;
            if (Vari() == true) return 7;
            if (Suora() == true) return 6;
            if (Kolmoset() == true) return 5;
            if (KaksiParia() == true) return 4;
            if (Pari() == true) return 3;
            else return 0;
        }

        public bool Suora()
        {

            int h = 0;
            int k = 0;
            int z = 0;
            int f = hand.Count;

            for (int i = 0; i < f; i++)
            {                
                Card card = hand.ElementAt(i);
                h = card.Number;
                for (int g = 0; g < f; g++)
                {
                    Card card1 = hand.ElementAt(g);
                    if (card != card1)
                    {
                        k = card1.Number;
                        if (h == k)
                        {
                            z--;
                        }

                        if (h + 1 == k)
                        {
                            z++;
                        }
                    }
                    if (z >= 4) return true;
                }
            }
                return false;
        }

        public bool Vari()
        {
            /*
            int h = 0;
            int k = 0;

            foreach(Card card in hand)
            {
                int z = 0;
                h = card.Suit;
                foreach(Card card1 in hand)
                {
                    if (card != card1)
                    {
                        k = card.Suit;
                        if (h == k)
                        {
                            z++;
                        }
                    }
                    if (z == 4) return true;
                }
            }
            return false;
            */

            int h = 0;
            int k = 0;
            int z = 0;
            int f = hand.Count;

            for (int i = 0; i < f; i++)
            {
                z = 0;
                Card card = hand.ElementAt(i);
                h = card.Suit;
                for (int g = 0; g < hand.Count; g++)
                {
                    Card card1 = hand.ElementAt(g);

                    if (card != card1)
                    {
                        k = card1.Suit;
                        if (h == k)
                        {
                            z++;
                        }
                    }
                    if (z >= 4) return true;
                }
            }
            return false;

        }
        public bool Neloset()
        {
            /*
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
            */

            int h = 0;
            int k = 0;
            int z = 0;
            int f = hand.Count;

            for (int i = 0;i < f; i++)
            {
                z = 0;
                Card card = hand.ElementAt(i);
                h = card.Number;
                for (int g = 0; g < hand.Count; g++)
                {
                    Card card1 = hand.ElementAt(g);

                    if(card != card1)
                    {
                        k = card1.Number;
                        if(h == k)
                        {
                            z++;
                        }
                    }
                    if (z == 3) return true;
                }
            }
            return false;
        }

        public bool Kolmoset()
        {
            int h = 0;
            int k = 0;
            int z = 0;
            int f = hand.Count;

            for (int i = 0; i < f; i++)
            {
                z = 0;
                Card card = hand.ElementAt(i);
                h = card.Number;
                for (int g = 0; g < hand.Count; g++)
                {
                    Card card1 = hand.ElementAt(g);

                    if (card != card1)
                    {
                        k = card1.Number;
                        if (h == k)
                        {
                            z++;
                        }
                    }
                    if (z == 2) return true;
                }
            }
            return false;
        }

        public bool KaksiParia()
        {
            int h = 0;
        int k = 0;
        int z = 0;
        int f = hand.Count;
        int j = 0;

            for (int i = 0; i<f; i++)
            {
                z = 0;
                Card card = hand.ElementAt(i);
                h = card.Number;
                for (int g = 0; g<hand.Count; g++)
                {
                    Card card1 = hand.ElementAt(g);

                    if(card != card1)
                    {
                        k = card1.Number;
                        if(h == k)
                        {
                            j++;
                        }
                    }
                }
            }
            if (j == 4) return true;
            return false;
        }
        public bool Pari()
        {
            int h = 0;
            int k = 0;
            int z = 0;
            int f = hand.Count;

            for (int i = 0; i < f; i++)
            {
                z = 0;
                Card card = hand.ElementAt(i);
                h = card.Number;
                for (int g = 0; g < hand.Count; g++)
                {
                    Card card1 = hand.ElementAt(g);

                    if (card != card1)
                    {
                        k = card1.Number;
                        if (h == k)
                        {
                            return true;
                        }
                    }                  
                }
            }
            return false;
        }

        public bool TaysKasi()
        {
            int h = 0;
            int k = 0;
            int z = 0;
            int f = hand.Count;

            for (int i = 0; i < f; i++)
            {                
                Card card = hand.ElementAt(i);
                h = card.Number;
                for (int g = 0; g < hand.Count; g++)
                {
                    Card card1 = hand.ElementAt(g);

                    if (card != card1)
                    {
                        k = card1.Number;
                        if (h == k)
                        {
                            z++;
                        }
                    }
                    if (z >= 8) return true;
                }
            }
            return false;
        }

        public void RemoveCards()
        {
            /*foreach (Card card in hand)
            {
                hand.Remove(card);
            }
            */
            hand.Clear();
        }
    }
}
