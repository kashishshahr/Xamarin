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
    public partial class AppLifeCycle : ContentPage
    {
        public AppLifeCycle()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            entry.Text = (Application.Current as App).DisplayText;
        }
        void OnEntryCompleted(object sender, EventArgs e)
        {
            (Application.Current as App).DisplayText = entry.Text;
        }
    }
}