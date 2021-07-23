using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tasks.TabbedPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ControllerTabPage : ContentPage
    {
        public ControllerTabPage()
        {
            InitializeComponent();

        }


        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            RegisterProgressBar.IsVisible = true;
            var x = await ProgressBarProgressAsync(RegisterProgressBar);


        }

        private async Task<bool> ProgressBarProgressAsync(ProgressBar p)
        {
            return await p.ProgressTo(1.0, 2000, Easing.Linear);
        }
    }
}