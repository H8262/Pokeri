using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
        public GamePage()
        {
            Random rand = new Random();
            this.InitializeComponent();
            Deck deck = new Deck();
            Card card = new Card();


            deck.BuildDeck(card);
            deck.DebugList();
            Card card1 = new Card();        
            deck.ServeCard(card1);
            deck.DebugList();

            string Card1Suit = Convert.ToString(card1.Suit);
            string Card1Number = Convert.ToString(card1.Number);

            debug.Text = Card1Suit + " " + Card1Number;
            

            


        }
    }
}
