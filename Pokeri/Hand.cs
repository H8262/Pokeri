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

    }
}
