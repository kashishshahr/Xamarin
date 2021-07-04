using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tasks
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            //resourceImage.Source = ImageSource.FromResource("Tasks.images.controller.jpg");
            
            //resourceImage1.Source = ImageSource.FromResource("Tasks.images.controller.jpg");
        }

       

        string Role = "";
        private void CarouselView_CurrentItemChanged(object sender, CurrentItemChangedEventArgs e)
        {
            DeviceRoles Prevrole = e.PreviousItem as DeviceRoles;
            DeviceRoles Currentrole = e.CurrentItem as DeviceRoles;
            //await DisplayAlert("Device will be used as", Currentrole.Name, "ok");
            Role = Currentrole.Name;

        }

        private async void OnSetUp(object sender, EventArgs e)
        {
            if(Role=="Controller")
                await Navigation.PushAsync(new ControllerPage());
            else if (Role == "Agent")
                await Navigation.PushAsync(new AgentPage());
        }   

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if (Role == "Controller")
                await DisplayAlert("Controller Device", "Shows location of agent's device", "OK");
            else if (Role == "Agent")
                await DisplayAlert("Agent Device", "Send's location to controller's device", "OK");
        }
    }
}