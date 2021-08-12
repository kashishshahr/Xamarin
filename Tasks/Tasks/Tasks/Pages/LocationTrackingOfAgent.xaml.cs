using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Models;
using Tasks.ViewModel;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tasks.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LocationTrackingOfAgent : ContentPage
    {
        
        public LocationTrackingOfAgent(Agent selectedAgent)
        {
            //InitializeComponent();

            Agentname.Text = selectedAgent.AgentName;
            LocationTracking(selectedAgent.AgentLocation);
        }
        public async void LocationTracking(string loc)
        {
            
            if (Device.RuntimePlatform == Device.iOS)
            {
                // https://developer.apple.com/library/ios/featuredarticles/iPhoneURLScheme_Reference/MapLinks/MapLinks.html
                await Launcher.OpenAsync("http://maps.apple.com/?q=394+Pacific+Ave+San+Francisco+CA");
            }
            else if (Device.RuntimePlatform == Device.Android)
            {
                // open the maps app directly
                await Launcher.OpenAsync($"geo:0,0?q=394+{loc}");
            }
            else if (Device.RuntimePlatform == Device.UWP)
            {
                await Launcher.OpenAsync("bingmaps:?where=394 Pacific Ave San Francisco CA");
            }
        }
    }
}