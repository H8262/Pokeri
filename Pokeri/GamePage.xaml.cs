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
                LocationX = 100,
                LocationY = 100                        
            };

            kortti2 = new Kortti
            {
                Suit = card2.Suit,
                Number = card2.Number,
                LocationX = 400,
                LocationY = 100
            };
            kortti1.UpdateLooks();
            kortti2.UpdateLooks();


            kortti1.UpdatePosition();
            kortti2.UpdatePosition();

            MyCanvas.Children.Add(kortti1);
            MyCanvas.Children.Add(kortti2);



        }
    }
}
