using System;
using System.Collections.Generic;
using System.Text;
using Tasks.Models;
using Tasks.TabbedPages;
using System.ComponentModel;

using System.Windows.Input;
using Xamarin.Forms;
using Tasks.Pages;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Essentials;

namespace Tasks.ViewModel
{
    public class AgentViewModel : INotifyPropertyChanged
    {

        private Agent _agent;
        public Agent AgentInfo
        {
            get
            {
                return _agent;
            }
            set
            {
                _agent = value;
                OnPropertyChanged(nameof(AgentInfo));
            }
        }
        private Agent _selectedAgent;
        public ObservableCollection<Agent> _Agents;
        public ObservableCollection<Agent> Agents { get { return _Agents; } set { _Agents = value; OnPropertyChanged(nameof(Agents)); } }

        public Agent SelectedAgent { get { return _selectedAgent; } set { _selectedAgent = value; OnPropertyChanged(nameof(SelectedAgent)); } }
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand AgentSelectedCommand { get; private set; }
        public ICommand EditSelectedAgent { get; private set; }
        public ICommand AddAgentCommand { get; private set; }
        public Command EditingAgentCommand { get; private set; }
        public ICommand DeleteSelectedAgent { get; private set; }
        public ICommand AgentAssignmentCommand { get; private set; }
        public ICommand PinPointAgentCommand { get; private set; }
        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
            public Agent oldAgent;
        
        public ObservableCollection<Agent> _CollectionOfAgents;
        public ObservableCollection<Agent> CollectionOfAgents { get { return _CollectionOfAgents; } set { _CollectionOfAgents = value; OnPropertyChanged(nameof(CollectionOfAgents)); } }
        public AgentViewModel()
        {
            CollectionOfAgents = AgentService.returnData();
            Agents = AgentService.GetAgentList();
            SelectedAgent = null;
            AgentSelectedCommand = new Command((agent) =>
            {
                Agent selectedAgentObject = (Agent)agent;
                Console.WriteLine(selectedAgentObject.AgentName);
                SelectedAgent = new Agent();
                SelectedAgent = selectedAgentObject;

            });
            
            EditSelectedAgent = new Command(async (agent) =>
            {
                Agent selectedAgentObject = (Agent)agent;
  
                await Application.Current.MainPage.Navigation.PushAsync(new EditAgentPage(selectedAgentObject.AgentId));
            });
            DeleteSelectedAgent = new Command((agent) =>
            {
                Agent selectedAgentObject = (Agent)agent;
                Console.WriteLine("Deleting Name:"+selectedAgentObject.AgentName);
                this.Agents.Remove(selectedAgentObject);

            });
            PinPointAgentCommand = new Command(async (agent) =>
            {
                Console.WriteLine("In PinPoint");
                Agent selectedAgentObject = (Agent)agent;
                
                SelectedAgent = selectedAgentObject;
                string loc = selectedAgentObject.AgentLocation;
                if (Device.RuntimePlatform == Device.iOS)
                {
                    // https://developer.apple.com/library/ios/featuredarticles/iPhoneURLScheme_Reference/MapLinks/MapLinks.html
                    await Launcher.OpenAsync("http://maps.apple.com/?q=394+Pacific+Ave+San+Francisco+CA");
                }
                else if (Device.RuntimePlatform == Device.Android)
                {
                    // open the maps app directly
                    await Launcher.OpenAsync($"geo:0,0?q=394+{loc}");
                }
                else if (Device.RuntimePlatform == Device.UWP)
                {
                    await Launcher.OpenAsync("bingmaps:?where=394 Pacific Ave San Francisco CA");
                }
                //ContentPage cp = new ContentPage();
                //cp.Title = "Location Tracking Page";
                //Label label = new Label();
                //label.Text = selectedAgentObject.AgentDecription;
                //Label agentNamelabel = new Label();
                //agentNamelabel.Text = selectedAgentObject.AgentName;
                //Image image = new Image();
                //image.HeightRequest = 50;
                //image.WidthRequest = 50;
                //image.Source = "appbg.png";
                //StackLayout panel = new StackLayout { 
                //HorizontalOptions=LayoutOptions.Center,
                //VerticalOptions=LayoutOptions.Center

                //};
                //panel.Children.Add(image);
                //panel.Children.Add(agentNamelabel);
                //panel.Children.Add(label);
                //cp.Content =panel;
                //await Application.Current.MainPage.Navigation.PushAsync(new LocationTrackingOfAgent(SelectedAgent));

            });
            AddAgentCommand = new Command((agent) =>
              {
                  this.Agents.Add((Agent)agent);
              });
            EditingAgentCommand = new Command((eagent) =>
              {
                  Agent newAgent = (Agent)eagent;
                  Agent oldAgent=this.Agents.FirstOrDefault(a => a.AgentId == newAgent.AgentId);
                  int index = this.Agents.IndexOf(oldAgent);
                  this.Agents.Remove(oldAgent);
                  this.Agents.Insert(index, newAgent);
                  
                  //Agent ea = (Agent)eagent;
                  //var a=this.Agents.FirstOrDefault(agent=>agent.AgentId==ea.AgentId);
                  //if(a!=null)
                  //{
                  //    a.AgentName = ea.AgentName;
                  //    a.AgentDecription = ea.AgentDecription;
                  //    a.AgentImageUrl = ea.AgentImageUrl;
                  //    a.IsAssigned = ea.IsAssigned;
                  //    a.IsTrackable = ea.IsTrackable;
                  //    OnPropertyChanged(nameof(Agents));
                  //}
                  
              });

        }

    }
}
