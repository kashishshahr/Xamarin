using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Tasks
{
    public partial class OldMainPage : ContentPage
    {
        public OldMainPage()
        {
            InitializeComponent();
        }

        

        private async void ControllerInvoked(object sender, EventArgs e)
        {
           await DisplayAlert("SwipeView", "Controller Setup", "Ok");
            //await Navigation.PushAsync(new ControllerPage()); 

        }
        private async void AgentInvoked(object sender, EventArgs e)
        {
            await DisplayAlert("SwipeView", "Agent Setup", "Ok");
        }
    }
}
