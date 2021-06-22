using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinTuts
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        bool flag = true;
        private void OnButtonClicked(object sender, EventArgs e)
        {
            //Button b = sender as Button;
            //b.Text = "Click me Againnn!";
            if (flag)
            {
                flag = false;
                (sender as Button).Text = "Click me Again!";
                (sender as Button).TextColor = Color.Red;
                (sender as Button).BackgroundColor = Color.Blue;
                (sender as Button).BorderColor = Color.Aqua;
            }
            else
            {
                flag = true;
                (sender as Button).Text = "Click me !";
                (sender as Button).TextColor = Color.Blue;
                (sender as Button).BackgroundColor = Color.Aqua;
                (sender as Button).BorderColor = Color.Red;
            }

            
        }
        private async void NavigateButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EntryTut());
        }

        private async void EditorialNavigationButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EditorTutorial());
        }

        private async void ImageNavigationButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ImageTutorial());

        }
        private async void PopUpNavigationButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PopupsTutorial());

        }

        private async void GridNavigationButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GridTutorial());
        }

        private async void ListViewNavigationButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CollectionView());

        }

        private async void AppLifeCycleNavigationButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AppLifeCycle());

        }
    }
}
