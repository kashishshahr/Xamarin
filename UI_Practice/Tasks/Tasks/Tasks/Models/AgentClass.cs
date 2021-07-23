using System;
using System.Collections.Generic;
using System.Text;

namespace Tasks.Models
{
    public class Agent
    {
        private int _agentId;
        public int AgentId { get { return _agentId; } set { _agentId = value; } }
        private string _agentName;
        public string AgentName { get { return _agentName; } set { _agentName = value; } }
        private string _agentDescription;
        public string AgentDecription { get { return _agentDescription; } set { _agentDescription= value; } }
        private string _agentImageUrl;
        public string AgentImageUrl { get { return _agentImageUrl; } set { _agentImageUrl = value; } }
    }
}
