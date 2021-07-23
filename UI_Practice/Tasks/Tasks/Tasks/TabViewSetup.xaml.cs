using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Tasks.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tasks
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabViewSetup : ContentPage
    {
        Color HighlightColor;
        Color NormalColor;
        string agentname = string.Empty;
        string agentPassword = string.Empty;
        public TabViewSetup()
        {
            InitializeComponent();
            HighlightColor = Color.FromHex("#282828");
            NormalColor = Color.Black;
            agentPasswordEyeImage.Source = "eye.png";
            ControllerVisible.IsVisible = false;
            AgentVisible.IsVisible = true;
            agentPasswordEntry.IsPassword = true;
            ControllerStack.Opacity = 0.6;
            AgentStack.Opacity = 1;
            agentname = ControllerDeviceNameEntry.Text;
            agentPassword = agentPasswordEntry.Text;

        }

        private void OnControllerTapped(object sender, EventArgs e)
        {
            Task.Delay(500);
            Grid.SetColumn(RoleSelection, 1);
            AgentVisible.IsVisible = false;
            ControllerVisible.IsVisible = true;
            ControllerStack.Opacity = 1;
            AgentStack.Opacity = 0.6;
        }

        private void OnAgentTapped(object sender, EventArgs e)
        {

            Task.Delay(500);
            Grid.SetColumn(RoleSelection, 0);
            AgentVisible.IsVisible = true;
            ControllerVisible.IsVisible = false;
            AgentStack.Opacity = 1;
            ControllerStack.Opacity = 0.6;
        }

        private async Task animationAsync(View btn)
        {
            await btn.ScaleTo(0.75, 100);
            await btn.ScaleTo(1, 100);

        }
        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            Button b = sender as Button;
            await animationAsync(b);
            await ProgressBarProgressAsync(RegisterProgressBar);
        }


        private async Task ProgressBarProgressAsync(ProgressBar p)
        {
            p.Progress = 0;
            p.IsVisible = true;
             await p.ProgressTo(1.0, 2000, Easing.Linear);
            p.IsVisible = false;
            return;
        }

        private void OnAgentEyeIconTap(object sender, EventArgs e)
        {
            ShowHidePassword(sender, agentPasswordEntry);
        }

        private void ShowHidePassword(object sender, Entry entry)
        {
            Image image = (sender as Image);

            if (entry.IsPassword)
            {
                image.Source = "eye.png";
                entry.IsPassword = false;
            }
            else
            {
                image.Source = "hideeye.png";
                entry.IsPassword = true;
            }
        }

        private void OnControllerPasswordEyeIconTap(object sender, EventArgs e)
        {
            ShowHidePassword(sender, controllerPasswordEntry);
        }

        private void OnControllerConfirmEyeIconTap(object sender, EventArgs e)
        {
            ShowHidePassword(sender, controllerConfirmPasswordEntry);
        }





        async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var x = e.CurrentSelection.FirstOrDefault() as Agent;
            if (x == null)
                return;
            await DisplayAlert("Selected Agent", $"You Selected {x.AgentName}", "OK");
            ((CollectionView)sender).SelectedItem = null;


        }

        private void AgentNameTextChanged(object sender, TextChangedEventArgs e) => CheckForValidation();
        private void AgentPasswordTextChanged(object sender, TextChangedEventArgs e) => CheckForValidation();
        private void CheckForValidation()
        {

            agentname = ControllerDeviceNameEntry.Text;
            agentPassword = agentPasswordEntry.Text;
           
        }

        

        private async void OnAgentSwipedAsync(object sender, EventArgs e)
        {
            string name = (sender as SwipeItem).Text;
            Console.WriteLine("Swiped");
            await DisplayAlert("Selected Agent", $"You Selected {name}", "OK");

        }

        private void OnAgentGoBackClickedAsync(object sender, EventArgs e)
        {
            AgentListPop.IsVisible = false;

        }
        private async void OnAgentGoClickedAsync(object sender, EventArgs e)
        {
            ImageButton b = sender as ImageButton;

            if (string.IsNullOrWhiteSpace(agentPasswordEntry.Text) || string.IsNullOrWhiteSpace(ControllerDeviceNameEntry.Text))
            {

                await DisplayAlert("Invalid", "You must  enter details", "Ok");
            }
            else
            {

                await animationAsync(b);
                await ProgressBarProgressAsync(RegisterProgressBar);

                AgentListPop.IsVisible = true;
            }

        }

        private async void OnAgentSelectedAsync(object sender, EventArgs e)
        {
            ImageButton imagebutton=sender as ImageButton;
            await animationAsync(imagebutton);
            await DisplayAlert("Selected", "yes", "ok");
        }

        private async void OnLetsGoClickAsync(object sender, EventArgs e)
        {
            await DisplayAlert("All Done", "Agent selected", "OK");
        }

    }
    }