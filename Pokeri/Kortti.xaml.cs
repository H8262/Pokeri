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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Pokeri
{
    public sealed partial class Kortti : UserControl
    {
        // location
        public double LocationX { get; set; }
        public double LocationY { get; set; }

        public bool Hidden // onko kortti piilotettu pelaajalta
        {
            get; set;
        }


        public int Suit;
        public int Number;
        public double frameHeight = 105;
        public double frameWidth = 75;
        public Kortti()
        {
            this.InitializeComponent();
        }
        public void UpdatePosition()
        {
            SetValue(Canvas.LeftProperty, LocationX);
            SetValue(Canvas.TopProperty, LocationY);
        }
        public void UpdateLooks()
        {
            if (Hidden == false)
            {
                SpriteSheetOffset.X = Number * -frameWidth;
                SpriteSheetOffset.Y = Suit * -frameHeight;
            }
            else
            {
                SpriteSheetOffset.X = 0;
                SpriteSheetOffset.Y = -420;
            }
        }
    }
}
