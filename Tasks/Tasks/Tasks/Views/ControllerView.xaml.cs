using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;








/// <summary>
/// How to get access to prgress bar From Main page
/// </summary>
namespace Tasks.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ControllerView : ContentView
    {
        public ControllerView()
        {
            InitializeComponent();
            passwordControllerEyeImage.IsVisible = false;
            controllerPasswordEyeImage.IsVisible = false;
        }
        private async Task ProgressBarProgressAsync(ProgressBar p)
        {
            p.Progress = 0;
            p.IsVisible = true;
            await p.ProgressTo(1.0, 2000, Easing.Linear);
            p.IsVisible = false;
            return;
        }
        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            Button b = sender as Button;
            await animationAsync(b);
            //await ProgressBarProgressAsync(RegisterProgressBar);
        }
        private async Task animationAsync(View btn)
        {
            await btn.ScaleTo(0.75, 100);
            await btn.ScaleTo(1, 100);

        }

        private void OnControllerPasswordEyeIconTap(object sender, EventArgs e)
        {
            ShowHidePassword(sender, controllerPasswordEntry);
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

        private void OnControllerConfirmEyeIconTap(object sender, EventArgs e)
        {
            ShowHidePassword(sender, controllerConfirmPasswordEntry);
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