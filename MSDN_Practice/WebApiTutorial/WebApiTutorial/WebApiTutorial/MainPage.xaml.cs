using ClassLibrary;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace WebApiTutorial
{
    public partial class MainPage : ContentPage
    {
        RestService _restService;
        public MainPage()
        {
            InitializeComponent();
            _restService = new RestService();
        }
        async void OnButtonClicked(object sender,EventArgs e)
        {
            List<Repository> repositories = await _restService.GetRepositoriesAsync(Constant.GitHubReposEndPoint);
            collectionView.ItemsSource = repositories;
        }
    }
}
