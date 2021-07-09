using System;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tasks
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class ControllerPage : ContentPage
    {
        public ControllerPage()
        {
            InitializeComponent();
            
        }
        

        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            RegisterProgressBar.IsVisible = true;
          var x=await ProgressBarProgressAsync(RegisterProgressBar);
            
            
        }

        private async Task<bool> ProgressBarProgressAsync(ProgressBar p)
        {
            return await p.ProgressTo(1.0, 2000, Easing.Linear);
        }
    }
}