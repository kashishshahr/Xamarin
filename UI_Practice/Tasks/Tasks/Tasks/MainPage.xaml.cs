using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Tasks
{
    public partial class MainPage : ContentPage
    {
        Color HightlightWhite;
        Color newBlue;
        Color newWhite;
        string uncheckedpng;
        string checkedpng;
        public MainPage()
        {
            InitializeComponent();

            ControllerRadio = false;
            AgentRadio= false;
            //HightlightWhite= (Color)Application.Current.Resources["highlightWhite"];
            HightlightWhite = Color.GhostWhite;
            newWhite = (Color)Application.Current.Resources["newWhite"];
            newBlue = (Color)Application.Current.Resources["newBlue"];
            uncheckedpng = "bunchecked.png";
            checkedpng = "bchecked.png";
            AgentLayout.BackgroundColor = Color.White;
            ControllerLayout.BackgroundColor = Color.White;
            ControllerRadioImage.Source = uncheckedpng;
            AgentRadioImage.Source = uncheckedpng;
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

        bool ControllerRadio, AgentRadio;

        private void OnAgentRadioButtonTapped(object sender, EventArgs e)
        {
            AgentLayout.BackgroundColor = HightlightWhite;
            AgentRadio = true;
            AgentRadioImage.Source = checkedpng;
            if (ControllerRadio.Equals(true))
            {
                ControllerLayout.BackgroundColor = newWhite;
                ControllerRadioImage.Source = uncheckedpng;
                ControllerRadio = false;
            }
        }
        private async void btn_clicked(object sender,EventArgs e)
        {
            await Task.Delay(200);
            setupButton.Scale = 0.9;
            await Task.Delay(200);

            setupButton.Scale = 1;
            if (ControllerRadio) {
                await Navigation.PushAsync(new ControllerPage());
            }
                
            else if (AgentRadio) {
                await Navigation.PushAsync(new AgentPage());
            }
                //Selected.Text = AgentRadioLabel.Text + " Selected";
            else
                await DisplayAlert("Alert", "Choose one of the options", "Ok");
        }
        private void OnControllerRadioButtonTapped(object sender, EventArgs e)
        {
            ControllerLayout.BackgroundColor = HightlightWhite;
            ControllerRadio = true;
            ControllerRadioImage.Source = checkedpng;
            if(AgentRadio.Equals(true))
            {
                AgentLayout.BackgroundColor = newWhite;
                AgentRadioImage.Source = uncheckedpng;
                AgentRadio = false;
            }
         
        }
    }
}
