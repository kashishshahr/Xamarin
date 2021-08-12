using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Tasks.ViewModel;
using System;
using Tasks.Models;
using System.Threading.Tasks;
using Tasks.TabbedPages;

namespace Tasks.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ControllerPage : ContentPage
    {
        AgentService agentService;
        AgentViewModel agentViewModel;
        ControllerViewModel ControllerViewModel;

        public Command AgentAssignmentCommand { get; private set; }

        public ControllerPage(ControllerViewModel controllerViewModel)
        {
            InitializeComponent();
            ControllerViewModel = controllerViewModel;
            this.BindingContext = ControllerViewModel;
            agentService = new AgentService();
            agentViewModel = new AgentViewModel();
            AgentsCollection.BindingContext = agentViewModel;

            

        }
        private async Task animationAsync(View btn)
        {
            await btn.ScaleTo(0.75, 100);
            await btn.ScaleTo(1, 100);

        }
        private async void EditAgenImageClickedAsync(object sender, EventArgs e)
        {
            ImageButton b = sender as ImageButton;
            await animationAsync(b);
            
        }
        private async void LocationOfAgentImageClickedAsync(object sender, EventArgs e)
        {
            ImageButton b = sender as ImageButton;
            await animationAsync(b);
          
            
        }

        private async void DeleteAgenImageClickedAsync(object sender, EventArgs e)
        {
            ImageButton b = sender as ImageButton;
            await animationAsync(b);
        }

    

        private async void AddAgentToList(object sender, EventArgs e)
        {
            Button b = sender as Button;
            animationAsync(b);
            await Navigation.PushAsync(new AddAgentPage(ControllerViewModel));
        }

        private void SearchButtonPressed(object sender, EventArgs e)
        {

            //AgentsCollection.ItemsSource = searchBar. SearchResults;
            //searchResult.IsVisible = true;
        }

        private void SearchTextChanged(object sender, TextChangedEventArgs e)
        {
            SearchBar searchBar = (SearchBar)sender;
             var res= AgentService.GetSearchResults(searchBar.Text);
            if (res.Count != 0)
            {
                Not_Found.IsVisible = false;
                AgentsCollection.ItemsSource = res;
            }
            else
            {
                AgentsCollection.ItemsSource = null;
                Not_Found.IsVisible = true;
            }
        }
    }
}