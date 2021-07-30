using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Tasks.Models;

namespace Tasks.TabbedPages
{
    public class AgentService:INotifyPropertyChanged
    {
        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        static ObservableCollection<Agent> _listOfAgents=GetAgentList();
        public ObservableCollection<Agent> listOfAgents { get { return _listOfAgents; } 
            set 
            { 
                _listOfAgents = value;
                NotifyPropertyChanged(nameof(listOfAgents));
            }  
        }
            int id = 4;
            static string imageLink = "https://cdn4.iconfinder.com/data/icons/gradient-circle-blue/36/1014-512.png";

        public event PropertyChangedEventHandler PropertyChanged;
        
        public AgentService()
        {

            listOfAgents = new ObservableCollection<Agent>() {
                new Agent()
                {

                    AgentId=1,IsAssigned=true,AgentName="Agent Rohan",AgentDecription="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore",AgentImageUrl=imageLink,
                    IsTrackable=true
                },
                new Agent()
                {
                    AgentId=2,AgentName="Agent Mohan",AgentDecription="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore",AgentImageUrl=imageLink,IsAssigned=true,
                    IsTrackable=true
        },
                new Agent()
                {
                    AgentId=3,AgentName="Agent Sonu",AgentDecription="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore",AgentImageUrl=imageLink,IsAssigned=true,
                    IsTrackable=false
                },
                new Agent()
                {
                    AgentId=4,AgentName="Agent A",AgentDecription="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore",AgentImageUrl=imageLink,IsAssigned=false
                },
                new Agent()
                {
                    AgentId=5,AgentName="Agent B",AgentDecription="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore",AgentImageUrl=imageLink,IsAssigned=false
                },
                new Agent()
                {
                    AgentId=6,AgentName="Agent C",AgentDecription="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore",AgentImageUrl=imageLink,IsAssigned=false
                },
                new Agent()
                {
                    AgentId=7,AgentName="Agent D",AgentDecription="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore",AgentImageUrl=imageLink,IsAssigned=false
                },
                new Agent()
                {
                    AgentId=8,AgentName="Agent E",AgentDecription="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore",AgentImageUrl=imageLink,IsAssigned=true,
                    IsTrackable=true
                },
                new Agent()
                {
                    AgentId=9,AgentName="Agent F",AgentDecription="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore",AgentImageUrl=imageLink,IsAssigned=true,
                    IsTrackable=false
                },
                new Agent()
                {
                    AgentId=10,AgentName="Agent G",AgentDecription="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore",AgentImageUrl=imageLink,IsAssigned=true,
                    IsTrackable=true
                },
            };
        }

        public static ObservableCollection<Agent> GetSearchResults(string text)
        {
            var searchedAgentsList = _listOfAgents.Where(agent => agent.AgentName.ToLower().Contains(text.ToLower())).ToList();
            var observableAgents = new ObservableCollection<Agent>(searchedAgentsList);
            return observableAgents;
        }

        public static ObservableCollection<Agent> GetAgentList()
        {
            return _listOfAgents;
        }
        public static Agent GetAgent(int id)
        {
            Agent a=_listOfAgents.Where(A => A.AgentId == id).FirstOrDefault<Agent>();
            return a;
        }
        public static void UpdateAgent(Agent agent)
        {

            //Agent a = _listOfAgents.Where(A => A.AgentId == agent.AgentId).FirstOrDefault<Agent>();
            _listOfAgents.Remove(agent);
            _listOfAgents.Add(agent);
            //a.AgentImageUrl = agent.AgentImageUrl;
            //a.AgentDecription = agent.AgentDecription;
            //a.AgentName = agent.AgentName;
            //a.IsAssigned = agent.IsAssigned;
            //a.IsTrackable = agent.IsTrackable;
        }
        public void AddAgentList(string agentName, string agentDecription)
        {
            listOfAgents.Add(new Agent()
            {
                AgentId = id++,
                AgentName = agentName,
                AgentDecription = agentDecription,
                AgentImageUrl = imageLink
            });
        }
    }
}
