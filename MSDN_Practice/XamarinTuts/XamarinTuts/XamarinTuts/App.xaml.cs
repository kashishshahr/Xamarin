using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinTuts
{
    public partial class App : Application
    {
        const string displayText = "displayText";
        public string DisplayText { get; set; }
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            Console.WriteLine("OnStart");
            if(Properties.ContainsKey(displayText))
            {
                DisplayText = (string)Properties[displayText];
            }
        }

        protected override void OnSleep()
        {
            Console.WriteLine("OnSleep");
            //There is no method for application termination. Under normal circumstances, application termination will occur from the OnSleep method.
            Properties[displayText] = DisplayText;
        }

        protected override void OnResume()
        {
            Console.WriteLine("OnResume");
        }
    }
}
