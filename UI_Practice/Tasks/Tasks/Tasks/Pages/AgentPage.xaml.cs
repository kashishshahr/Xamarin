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
    public partial class AgentPage : ContentPage
    {
        public AgentPage()
        {
            InitializeComponent();
        }
        private async void OnAgentGoClicked(object sender, EventArgs e)
        {
            var x = await ProgressBarProgressAsync(GoProgressBar);
        }
        private async Task<bool> ProgressBarProgressAsync(ProgressBar p)
        {
            p.IsVisible = true;
            return await p.ProgressTo(1.0, 2000, Easing.Linear);
        }
    }
}