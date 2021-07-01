using Core;
using System;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace PhoneWord
{
    class OldMainPage:ContentPage
    {
        string translatednumber;
        Label _enterLabel;
        Entry _phoneNumberText;
        Button _translateButton,_callButton;
        public OldMainPage()
        {
            this.Padding = 20;//Try this if it works
            //Padding = new Thickness(20,20,20,20);
            _enterLabel = new Label() 
            { 
                Text="Enter a PhoneWord: ",
                FontSize=Device.GetNamedSize(NamedSize.Large,typeof(Label)) 
            };

            _phoneNumberText = new Entry() 
            { 
                Placeholder="1-855-XAMARIN"
            };

            _translateButton = new Button() 
            {
                Text="Translate"
            };
            _callButton = new Button() 
            { 
                Text = "Call", IsEnabled = false 
            };
            _translateButton.Clicked += OnTranslate;
            _callButton.Clicked += OnCall;
            _phoneNumberText.TextChanged += OnTextChange;
            StackLayout panel = new StackLayout() { Spacing = 15 };
            panel.Children.Add(_enterLabel);
            panel.Children.Add(_phoneNumberText);
            panel.Children.Add(_translateButton);
            panel.Children.Add(_callButton);
            //this.Content = panel;
            Content = panel;
        }

        private void OnTextChange(object sender, TextChangedEventArgs e)
        {
            string text=(sender as Entry).Text;
            if(string.IsNullOrEmpty(text))
            {
                _callButton.Text = "Call";
                _callButton.IsEnabled=false;
                translatednumber = "";
            }
        }


        private async void OnCall(object sender, EventArgs e)
        {
            if(await DisplayAlert("Dial a Number","Would you like to call "+translatednumber+"?","Yes","No"))
            {
                //TODO dial the phone
                //await DisplayAlert("Dialing", " On this number: "+translatednumber, "ok");
                try
                {
                    PhoneDialer.Open(translatednumber);
                    
                }catch(ArgumentNullException)
                {
                    await DisplayAlert("Unable to dial", "Phone number was not valid", "OK");
                }catch(FeatureNotSupportedException)
                {
                    await DisplayAlert("Unable to dial", "Phone Dialing not supported", "OK");
                }catch(Exception)
                {
                    // Other error has occurred.
                    await DisplayAlert("Unable to dial", "Phone dialing failed.", "OK");
                }
            }
        }
        private void OnTranslate(object sender, System.EventArgs e)
        {
            translatednumber = PhonewordTranslator.ToNumber(_phoneNumberText.Text.ToString());
            
            if(!string.IsNullOrEmpty(translatednumber))
            {
                _callButton.IsEnabled = true;
                _callButton.Text = "Call " + translatednumber;
            }
            else
            {
                _callButton.IsEnabled = false;
                _callButton.Text = "Call ";
            }
        }
    }
}
