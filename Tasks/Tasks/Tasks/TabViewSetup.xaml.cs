using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Tasks.Models;
using Tasks.Pages;
using Tasks.ViewModel;
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
        ControllerViewModel controllerViewModel;
        AgentViewModel agentViewModel;
        public TabViewSetup()
        {
            InitializeComponent();
            agentViewModel = new AgentViewModel();
            controllerViewModel = new ControllerViewModel();
            ControllerStack2.BindingContext = controllerViewModel;
            BindingContext = agentViewModel;
            

            agentPasswordEyeImage.IsVisible = false;
            passwordControllerEyeImage.IsVisible = false;
            controllerPasswordEyeImage.IsVisible = false;
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
            Controller c=controllerViewModel.controller;
            await Navigation.PushAsync(new ControllerPage(controllerViewModel));
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

        private void AgentNameTextChanged(object sender, TextChangedEventArgs e) 
            {
            if(IsAgentEntriesNullOrWhiteSpace())
            {
         
                agentOfDeviceEntry.TextColor = Color.Gray;
            }
            else
            {
                agentOfDeviceEntry.TextColor = Color.White;
            }
        }
        private void AgentPasswordTextChanged(object sender, TextChangedEventArgs e)
        {
            if (IsAgentEntriesNullOrWhiteSpace())
            {
            
                agentOfDeviceEntry.TextColor = Color.Gray;
            }
            else
            {
                agentOfDeviceEntry.TextColor = Color.White;
            }
        }
        private bool IsAgentEntriesNullOrWhiteSpace()
        {
            
            agentname = ControllerDeviceNameEntry.Text;
            agentPassword = agentPasswordEntry.Text;
            if(string.IsNullOrWhiteSpace(agentname)||string.IsNullOrWhiteSpace(agentPassword))
            {
                return true;
            }
            return false;
           
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
        private async void OnAgentGo_UparrowClickedAsync(object sender, EventArgs e)
        {
            ImageButton b = sender as ImageButton;

            if (IsAgentEntriesNullOrWhiteSpace())
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

            AgentListPop.IsVisible = false;
            agentOfDeviceEntry.TextColor = Color.White;
        }

        private async void OnLetsGoClickAsync(object sender, EventArgs e)
        {
            Agent selected = agentViewModel.SelectedAgent;
            await DisplayAlert("An Agent is assigned to your device", agentOfDeviceEntry.Text, "OK");
        }


        private void OnAgentPasswordEntryFocus(object sender, FocusEventArgs e)
        {
            agentPasswordEyeImage.IsVisible = true;
        } private void OnAgentPasswordEntryUnFocus(object sender, FocusEventArgs e)
        {
            agentPasswordEyeImage.IsVisible = false;
        }

        private void OnControllerPasswordEntryFocus(object sender, FocusEventArgs e)
        {
            passwordControllerEyeImage.IsVisible = true;
        }
        private void OnControllerPasswordEntryUnFocus(object sender, FocusEventArgs e)
        {
            passwordControllerEyeImage.IsVisible = false;
        }

        private void OnContrllerConfirmPasswordFocus(object sender, FocusEventArgs e)
        {
            controllerPasswordEyeImage.IsVisible = true;
        }

        private void OnContrllerConfirmPasswordUnFocus(object sender, FocusEventArgs e)
        {
            controllerPasswordEyeImage.IsVisible = false;
        }
    }
    }