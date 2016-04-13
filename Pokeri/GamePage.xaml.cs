﻿using System;
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
        string PlayerName;
        string PlayerCash;
        string Ai1Cash;
        string Ai2Cash;
        string Ai3Cash;
        string TableCash;
        int CallValue = 50; // how much is Call?

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
        Player player;
        Player ai1;
        Player ai2;
        Player ai3;
        Player tablePlayer;

        Hand ai1Hand;
        Hand ai2Hand;
        Hand ai3Hand;
        Hand table;


        // timer juttuja
        private DispatcherTimer timer;
        private int turnCounter = 0; // what turn is it?
        private int counter = 0; //whose turn is it?

        //start turn
        public void StartTurn()
        {
            timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();

        }
        // timer jutut päättyy

        public GamePage()
        {
            ApplicationView.PreferredLaunchWindowingMode
                = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            ApplicationView.PreferredLaunchViewSize = new Size(800, 600);

            player = new Player { Name = "Player", Money = 2000 };
            ai1 = new Player { Name = "AI Player 1", Money = 2000 };
            ai2 = new Player { Name = "AI Player 2", Money = 2000 };
            ai3 = new Player { Name = "AI Player 3", Money = 2000 };
            tablePlayer = new Player { Name = "Table", Money = 0 };

            PlayerName = player.Name;

            Random rand = new Random();
            this.InitializeComponent();
            Deck deck = new Deck();
            Card card = new Card();
            Hand playerHand = new Hand(); //pelaajan käsi
            ai1Hand = new Hand(); // tietokonevastustajien kädet
            ai2Hand = new Hand();
            ai3Hand = new Hand();
            table = new Hand(); // pöydän kortit

            deck.BuildDeck(card);
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

            Debug.WriteLine("Player hand:");
            playerHand.ShowHands();
            Debug.WriteLine("AI1 hand:");
            ai1Hand.ShowHands();
            Debug.WriteLine("AI2 hand:");
            ai2Hand.ShowHands();
            Debug.WriteLine("AI3 hand:");
            ai3Hand.ShowHands();
            Debug.WriteLine("Table hand:");
            table.ShowHands();

            kortti1 = new Kortti // lisätään kortti canvakselle
            {
                Suit = card1.Suit,
                Number = card1.Number,
                LocationX = 330,
                LocationY = 450,
                Hidden = true
            };

            kortti2 = new Kortti
            {
                Suit = card2.Suit,
                Number = card2.Number,
                LocationX = 370,
                LocationY = 450,
                Hidden = true

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

            UpdateUI();
            DisableButtons();
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
        public void UpdateUI()
        {

            PlayerCash = Convert.ToString(player.Money);
            Ai1Cash = Convert.ToString(ai1.Money);
            Ai2Cash = Convert.ToString(ai2.Money);
            Ai3Cash = Convert.ToString(ai3.Money);
            TableCash = Convert.ToString(tablePlayer.Money);

            playerNameGamePage.Text = PlayerName;
            playerMoneyGamePage.Text = PlayerCash + " $";
            ai1MoneyGamePage.Text = Ai1Cash + " $";
            ai2MoneyGamePage.Text = Ai2Cash + " $";
            ai3MoneyGamePage.Text = Ai3Cash + " $";
            tableMoneyGamePage.Text = TableCash + " $";
            ai1.GetCallValue(CallValue);
            ai2.GetCallValue(CallValue);
            ai3.GetCallValue(CallValue);
            CallValueTextBlock.Text = "Call Value: " + Convert.ToString(CallValue);

            foreach (Kortti kortti in MyCanvas.Children)
            {
                kortti.UpdateLooks();
                kortti.UpdatePosition();
            }

            switch(ai1.Action)
            {
                case 0: ai1ActionTextBlock.Text = "Call!" + CallValue + " $"; break;
                case 1: ai1ActionTextBlock.Text = "Raise!" + CallValue + " $"; break;
                case 5: ai1ActionTextBlock.Text = "Waiting..."; break;
            }
            switch (ai2.Action)
            {
                case 0: ai2ActionTextBlock.Text = "Call!" + CallValue + " $"; break;
                case 1: ai2ActionTextBlock.Text = "Raise!" + CallValue + " $"; break;
                case 5: ai2ActionTextBlock.Text = "Waiting..."; break;
            }
            switch (ai3.Action)
            {
                case 0: ai3ActionTextBlock.Text = "Call!" + CallValue + " $"; break;
                case 1: ai3ActionTextBlock.Text = "Raise!" + CallValue + " $"; break;
                case 5: ai3ActionTextBlock.Text = "Waiting..."; break;
            }
            if (turnCounter == 5)
            {
                tableCard1.Hidden = false;
                tableCard2.Hidden = false;
                tableCard3.Hidden = false;
            }
            if (turnCounter == 7)
            {
                tableCard4.Hidden = false;
            }
            if (turnCounter == 8)
            {
                tableCard5.Hidden = false;
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

        public void StartGame_Click(object sender, RoutedEventArgs e)
        {
            kortti1.Hidden = false;
            kortti2.Hidden = false;

            player.Money -= 50;
            ai1.Money -= 50;
            ai2.Money -= 50;
            ai3.Money -= 50;
            tablePlayer.Money += 200;
            UpdateUI();
            StartGame.IsEnabled = false;
            StartGame.Visibility = Visibility.Collapsed;
            StartTurn();
        }
        private void Timer_Tick(object sender, object e)
        {
            int rv = 0; //return value from methods, how much money ai will spend
            UpdateUI();
            counter++;
            if (counter >= 4)
            {
                ai1.Action = 5;
                ai2.Action = 5;
                ai3.Action = 5;
                UpdateUI();
                EnableButtons();
                timer.Stop();              
                counter = 0;
            }
            if (counter == 1)
            {            
                ai2.Action = 5;
                ai3.Action = 5;
                UpdateUI();
                rv = ai1.AiTurn(ai1Hand);
                tablePlayer.Money += rv;
                if (ai1.Action == 1)
                {
                    CallValue = ai1.ReturnNewCallValue();
                    UpdateUI();
                }
                UpdateUI();
            }
            if (counter == 2)
            {
                ai1.Action = 5;
                ai3.Action = 5;
                UpdateUI();
                rv = ai2.AiTurn(ai2Hand);
                tablePlayer.Money += rv;
                if(ai2.Action == 1)
                {
                    CallValue = ai2.ReturnNewCallValue();
                    UpdateUI();
                }
                UpdateUI();
            }
            if (counter == 3)
            {
                ai2.Action = 5;
                ai1.Action = 5;
                rv = ai3.AiTurn(ai3Hand);
                tablePlayer.Money += rv;
                UpdateUI();
                if (ai3.Action == 1)
                {
                    CallValue = ai3.ReturnNewCallValue();
                    UpdateUI();
                }
                turnCounter++;
            }            
        }

        private void Call_Click(object sender, RoutedEventArgs e)
        {
            DisableButtons();
            player.Money -= CallValue;
            tablePlayer.Money += CallValue;
            StartTurn();
        }
        private void DisableButtons()
        {
            Call.IsEnabled = false;
            Raise.IsEnabled = false;
        }
        private void EnableButtons()
        {
            Call.IsEnabled = true;
            Raise.IsEnabled = true;
        }

        private void Raise_Click(object sender, RoutedEventArgs e)
        {
            DisableButtons();
            CallValue += 50;
            player.Money -= CallValue;
            tablePlayer.Money += CallValue;
            StartTurn();
        }
    }
}
