using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tasks
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabViewSetup : ContentPage
    {
        Color HighlightColor;
        Color NormalColor;
        public TabViewSetup() 
        { 
            InitializeComponent(); 
            HighlightColor = Color.FromHex("#282828"); 
            NormalColor = Color.Black;
            ControllerFrame.BackgroundColor = HighlightColor;
            ControllerFrame.Opacity = 1;
            AgentFrame.Opacity = 0.6;
            AgentFrame.BackgroundColor = NormalColor;
            AgentVisible.IsVisible = false;
        }

        private void OnControllerTapped(object sender, EventArgs e)
        {
            Task.Delay(500);
            ControllerFrame.BackgroundColor = HighlightColor;
            ControllerFrame.Opacity = 1;
            AgentFrame.Opacity = 0.6;
            AgentVisible.IsVisible = false;
            ControllerVisible.IsVisible = true;

            AgentFrame.BackgroundColor = NormalColor;
        }

        private void OnAgentTapped(object sender, EventArgs e)
        {
            Task.Delay(1000);
            AgentFrame.BackgroundColor = HighlightColor;
            AgentFrame.Opacity = 1;
            ControllerFrame.Opacity = 0.6;

            AgentVisible.IsVisible = true;
            ControllerVisible.IsVisible = false;
            ControllerFrame.BackgroundColor = NormalColor;
        }

        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            RegisterProgressBar.IsVisible = true;
            RegisterProgressBar.Progress = 0;
            var x = await ProgressBarProgressAsync(RegisterProgressBar);
        }

        private async Task<bool> ProgressBarProgressAsync(ProgressBar p)
        {
            return await p.ProgressTo(1.0, 2000, Easing.Linear);
        }
    }
}