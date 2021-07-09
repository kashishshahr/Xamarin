using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

    [assembly: ExportFont("Questa_Regular.otf",Alias="Questa")]
    [assembly: ExportFont("OpenSans-Italic.ttf", Alias="ItalicFont")]
    [assembly: ExportFont("OpenSans-Regular.ttf", Alias="RegularFont")]
    [assembly: ExportFont("OpenSans-Bold.ttf", Alias="BoldFont")]
    [assembly: ExportFont("OpenSans-Semibold.ttf", Alias="SemiBoldFont")]
    [assembly: ExportFont("Samantha Demo.ttf", Alias="Samantha")]
namespace Tasks
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
