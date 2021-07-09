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
        public MainPage()
        {
            InitializeComponent();

            ControllerRadio = false;
            AgentRadio= false;
            HightlightWhite= (Color)Application.Current.Resources["highlightWhite"];
            newWhite = (Color)Application.Current.Resources["newWhite"];
            newBlue = (Color)Application.Current.Resources["newBlue"];
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
            AgentRadioImage.Source = "checked.png";
            if (ControllerRadio.Equals(true))
            {
                ControllerLayout.BackgroundColor = newWhite;
                ControllerRadioImage.Source = "unchecked.png";
                ControllerRadio = false;
            }
        }
        private async void btn_clicked(object sender,EventArgs e)
        {
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
            ControllerRadioImage.Source = "checked.png";
            if(AgentRadio.Equals(true))
            {
                AgentLayout.BackgroundColor = newWhite;
                AgentRadioImage.Source = "unchecked.png";
                AgentRadio = false;
            }
         
        }
    }
}
