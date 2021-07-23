using System;
using System.Collections.Generic;
using System.Text;
using Tasks.Models;
using Tasks.TabbedPages;

namespace Tasks.ViewModel
{
    public class AgentViewModel
    {
        public List<Agent> Agents { get; set; }
        public AgentViewModel()
        {
            Agents = new AgentService().GetAgentList();
        }
    }
}
