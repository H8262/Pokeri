using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Pokeri
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GamePage : Page
    {
        public Kortti kortti1;
        public Kortti kortti2;
        public Kortti ai1Card1;
        public Kortti ai1Card2;
        public Kortti ai2Card1;
        public Kortti ai2Card2;
        public Kortti ai3Card1;
        public Kortti ai3Card2;
        public Kortti tableCard1;
        public Kortti tableCard2;
        public Kortti tableCard3;
        public Kortti tableCard4;
        public Kortti tableCard5;

        public GamePage()
        {
            ApplicationView.PreferredLaunchWindowingMode
                = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            ApplicationView.PreferredLaunchViewSize = new Size(800, 600);

            Random rand = new Random();
            this.InitializeComponent();
            Deck deck = new Deck();
            Card card = new Card();
            Hand playerHand = new Hand(); //pelaajan käsi
            Hand ai1Hand = new Hand(); // tietokonevastustajien kädet
            Hand ai2Hand = new Hand();
            Hand ai3Hand = new Hand();
            Hand table = new Hand(); // pöydän kortit

            deck.BuildDeck(card);
            deck.DebugList();
            Card card1 = new Card(); // ei kaunis, kehittelen loopin jos aikaa
            Card card2 = new Card();
            Card card3 = new Card();
            Card card4 = new Card();
            Card card5 = new Card();
            Card card6 = new Card();
            Card card7 = new Card();
            Card card8 = new Card();
            Card card9 = new Card();
            Card card10 = new Card();
            Card card11 = new Card();
            Card card12 = new Card();
            Card card13 = new Card();

            card1 = deck.ServeCard();
            card2 = deck.ServeCard();
            card3 = deck.ServeCard();
            card4 = deck.ServeCard();
            card5 = deck.ServeCard();
            card6 = deck.ServeCard();
            card7 = deck.ServeCard();
            card8 = deck.ServeCard();
            card9 = deck.ServeCard();
            card10 = deck.ServeCard();
            card11 = deck.ServeCard();
            card12 = deck.ServeCard();
            card13 = deck.ServeCard();

            deck.DebugList();

            playerHand.AddCard(card1);
            playerHand.AddCard(card2);
            ai1Hand.AddCard(card3);
            ai1Hand.AddCard(card4);
            ai2Hand.AddCard(card5);
            ai2Hand.AddCard(card6);
            ai3Hand.AddCard(card7);
            ai3Hand.AddCard(card8);
            table.AddCard(card9);
            table.AddCard(card10);
            table.AddCard(card11);
            table.AddCard(card12);
            table.AddCard(card13);
                   
            kortti1 = new Kortti // lisätään kortti canvakselle
            {
                Suit = card1.Suit,
                Number = card1.Number,
                LocationX = 330,
                LocationY = 450,
                Hidden = false
            };

            kortti2 = new Kortti
            {
                Suit = card2.Suit,
                Number = card2.Number,
                LocationX = 370,
                LocationY = 450,
                Hidden = false

            };

            ai1Card1 = new Kortti
            {
                Suit = card3.Suit,
                Number = card3.Number,
                LocationX = 70,
                LocationY = 100,
                Hidden = true
            };
            ai1Card2 = new Kortti
            {
                Suit = card4.Suit,
                Number = card4.Number,
                LocationX = 110,
                LocationY = 100,
                Hidden = true
            };

            ai2Card1 = new Kortti
            {
                Suit = card5.Suit,
                Number = card5.Number,
                LocationX = 330,
                LocationY = 50,
                Hidden = true
            };
            ai2Card2 = new Kortti
            {
                Suit = card6.Suit,
                Number = card6.Number,
                LocationX = 370,
                LocationY = 50,
                Hidden = true
            };
            ai3Card1 = new Kortti
            {
                Suit = card7.Suit,
                Number = card7.Number,
                LocationX = 590,
                LocationY = 100,
                Hidden = true
            };
            ai3Card2 = new Kortti
            {
                Suit = card8.Suit,
                Number = card8.Number,
                LocationX = 630,
                LocationY = 100,
                Hidden = true
            };
            tableCard1 = new Kortti
            {
                Suit = card9.Suit,
                Number = card9.Number,
                LocationX = 363,
                LocationY = 248,
                Hidden = true
            };
            tableCard2 = new Kortti
            {
                Suit = card10.Suit,
                Number = card10.Number,
                LocationX = 283,
                LocationY = 248,
                Hidden = true
            };
            tableCard3 = new Kortti
            {
                Suit = card11.Suit,
                Number = card11.Number,
                LocationX = 203,
                LocationY = 248,
                Hidden = true
            };
            tableCard4 = new Kortti
            {
                Suit = card12.Suit,
                Number = card12.Number,
                LocationX = 443,
                LocationY = 248,
                Hidden = true
            };
            tableCard5 = new Kortti
            {
                Suit = card13.Suit,
                Number = card13.Number,
                LocationX = 523,
                LocationY = 248,
                Hidden = true
            };



            MyCanvas.Children.Add(kortti1);
            MyCanvas.Children.Add(kortti2);
            MyCanvas.Children.Add(ai1Card1);
            MyCanvas.Children.Add(ai1Card2);
            MyCanvas.Children.Add(ai2Card1);
            MyCanvas.Children.Add(ai2Card2);
            MyCanvas.Children.Add(ai3Card1);
            MyCanvas.Children.Add(ai3Card2);
            MyCanvas.Children.Add(tableCard1);
            MyCanvas.Children.Add(tableCard2);
            MyCanvas.Children.Add(tableCard3);
            MyCanvas.Children.Add(tableCard4);
            MyCanvas.Children.Add(tableCard5);

            foreach (Kortti kortti in MyCanvas.Children)
            {
                kortti.UpdateLooks();
                kortti.UpdatePosition();
            }

        }

        private void Reveal_Click(object sender, RoutedEventArgs e)
        {
            foreach (Kortti kortti in MyCanvas.Children)
            {
                kortti.Hidden = false;
                kortti.UpdateLooks();
                kortti.UpdatePosition();
            }
        }

        private void Hide_Click(object sender, RoutedEventArgs e)
        {
            ai1Card1.Hidden = true;
            ai1Card2.Hidden = true;
            ai2Card1.Hidden = true;
            ai2Card2.Hidden = true;
            ai3Card1.Hidden = true;
            ai3Card2.Hidden = true;
            tableCard1.Hidden = true;
            tableCard2.Hidden = true;
            tableCard3.Hidden = true;
            tableCard4.Hidden = true;
            tableCard5.Hidden = true;
            foreach (Kortti kortti in MyCanvas.Children)
            {
                kortti.UpdateLooks();
                kortti.UpdatePosition();
            }

        }
    }
}
