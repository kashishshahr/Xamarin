using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Models;
using Tasks.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tasks.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddAgentPage : ContentPage,INotifyPropertyChanged
    {

        ControllerViewModel cvm;
        public Agent agent;
        AgentViewModel agentViewModel;
        public AddAgentPage(ControllerViewModel CVM)
        {
            InitializeComponent();
            agent = new Agent();
            cvm = CVM;
            agentViewModel = new AgentViewModel();
            AgentAddingStack.BindingContext = agentViewModel.AgentInfo;
        }
    
        private async void OnAgentAddClicked(object sender, EventArgs e)
        {
            
            int Id = agentViewModel.Agents.Count + 1;
            Agent agent = new Agent
            {
                AgentId=Id++,
                AgentName = AgentNameEntry.Text,
                AgentDecription = AgentDescriptionEntry.Text,
                AgentImageUrl = AgentImageUrlEntry.Text,
                AgentLocation=AgentLocationEntry.Text
                ,
                IsAssigned = 2

            };
            agentViewModel.AddAgentCommand.Execute(agent);
            await Navigation.PopAsync();
        }
    }
}