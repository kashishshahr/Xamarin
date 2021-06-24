using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UITutorial
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        
        private int tapCount=0;

        private async void OnTapGestureRecognizerTapped(object sender, EventArgs e)
        {
            tapCount++;
            
            if (tapCount % 2 == 0)
            {
                await Navigation.PushAsync(new DetailPage());
            }
            else
            {
                Console.WriteLine("TAPPPPP");
            }
        }
    }
}
