using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinTuts
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopupsTutorial : ContentPage
    {
        public PopupsTutorial()
        {
            InitializeComponent();
        }
        async void OnDisplayAlertButtonClicked(object sender, EventArgs e){
            await DisplayAlert("Alert", "This is an alert.", "OK");
        }
        async void OnDisplayAlertQuestionButtonClicked(object sender, EventArgs e){
            bool response = await DisplayAlert("Save?", "Would you like to save your data?", "Yes", "No");
            Console.WriteLine("Save data: " + response);
        }

        private async void OnDisplayActionSheetButtonClicked(object sender, EventArgs e)
        {
            string action = await DisplayActionSheet("Send to?", null, null, "Email", "Twitter", "Facebook");
            Console.WriteLine("Action: " + action);

        }
    }
}