using System;
using System.Collections.Generic;
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
    public sealed partial class LoadingPage : Page
    {
        Data data;
        public LoadingPage()
        {
            this.InitializeComponent();
        }

            protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is Data)
            {
                data = (Data)e.Parameter;
                Player.Text = "Player " + data.player;
                Ai1.Text = "Ai1 " + data.ai1;
                Ai2.Text = "Ai2 " + data.ai2;
                Ai3.Text = "Ai3 " + data.ai3;                


            }
            else
            {
                Player.Text = "Game is broken! Good Job!";
            }
            base.OnNavigatedTo(e);
        }

        private void NewGame_Click(object sender, RoutedEventArgs e)
        {

            this.Frame.Navigate(typeof(GamePage),data);
        }
    }
}
