using System;
using System.Collections.Generic;
using System.Text;
using Tasks.Models;

namespace Tasks.TabbedPages
{
    public class AgentService
    {
        List<Agent> listOfAgents;
            int id = 4;
            string imageLink = "https://cdn4.iconfinder.com/data/icons/gradient-circle-blue/36/1014-512.png";
        public AgentService()
        {

            listOfAgents = new List<Agent>() {
                new Agent()
                {
                    AgentId=1,AgentName="Agent Rohan",AgentDecription="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore",AgentImageUrl=imageLink
                },
                new Agent()
                {
                    AgentId=2,AgentName="Agent Mohan",AgentDecription="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore",AgentImageUrl=imageLink
                },
                new Agent()
                {
                    AgentId=3,AgentName="Agent Sonu",AgentDecription="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore",AgentImageUrl=imageLink
                },
                new Agent()
                {
                    AgentId=4,AgentName="Agent A",AgentDecription="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore",AgentImageUrl=imageLink
                },
                new Agent()
                {
                    AgentId=5,AgentName="Agent B",AgentDecription="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore",AgentImageUrl=imageLink
                },
                new Agent()
                {
                    AgentId=6,AgentName="Agent C",AgentDecription="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore",AgentImageUrl=imageLink
                },
                new Agent()
                {
                    AgentId=7,AgentName="Agent D",AgentDecription="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore",AgentImageUrl=imageLink
                },
                new Agent()
                {
                    AgentId=8,AgentName="Agent E",AgentDecription="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore",AgentImageUrl=imageLink
                },

            };
        }
        public List<Agent> GetAgentList()
        {
            return listOfAgents;
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
