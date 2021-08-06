using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Tasks.Models;
using Tasks.TabbedPages;
using Xamarin.Forms;

namespace Tasks.ViewModel
{
    class SearchViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public SearchViewModel()
        {
            SearchResults = null;
        }
        protected virtual void NotifyPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public ICommand PerformSearch => new Command<string>((string query) =>
        {
            Console.WriteLine(query);
            SearchResults = AgentService.GetSearchResults(query);
        });
        private ObservableCollection<Agent> _searchResults= AgentService.GetAgentList();

        public ObservableCollection<Agent> SearchResults
        {
            get { return _searchResults; }
            set { _searchResults = value; NotifyPropertyChanged(nameof(SearchResults)); }
            
        }

    }
}
