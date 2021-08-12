using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Tasks.Models
{
    public class Agent
    {


        
        private int isAssigned;

        public int IsAssigned
        {
            get { return isAssigned; }
            set { isAssigned = value; }
        }
        private bool isTrackable;

        public bool IsTrackable
        {
            get { return isTrackable; }
            set { isTrackable = value; }
        }

        private int _agentId;
        public int AgentId { get { return _agentId; } set { _agentId = value; } }
        private string _agentName;
        public string AgentName { get { return _agentName; } set { _agentName = value; } }
        private string _agentDescription;
        public string AgentDecription { get { return _agentDescription; } set { _agentDescription= value; } }
        private string _agentLocation;
        public string AgentLocation { get { return _agentLocation; } set { _agentLocation = value; } }
        private string _agentImageUrl;

        

        public string AgentImageUrl { get { return _agentImageUrl; } set { _agentImageUrl = value; } }
       
    }
}
