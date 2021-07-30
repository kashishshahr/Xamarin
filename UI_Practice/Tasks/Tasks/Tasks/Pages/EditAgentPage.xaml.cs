using System;
using System.Threading.Tasks;
using Tasks.Models;
using Tasks.TabbedPages;
using Tasks.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tasks.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditAgentPage : ContentPage
    {
        ControllerViewModel cvm;
        AgentViewModel agentViewModel;
        AgentService agentService;
        Agent editAgent;
        
        public EditAgentPage(int deviceId)
        {
            InitializeComponent();
            agentViewModel = new AgentViewModel();
            
            editAgent = AgentService.GetAgent(deviceId);
        
            this.BindingContext = editAgent;
            
        }
        public void setCvm(ControllerViewModel CVM)
        {
            cvm = CVM;
        }
        public  Agent EditAgent()
        {
            
            int id=-1;
            int.TryParse(AgentIdEntry.Text,out id);
            Agent a = new Agent
            {
                AgentId = id++,
                AgentName = AgentNameEntry.Text,
                AgentDecription = AgentDecriptionEntry.Text,
                AgentImageUrl = AgentImageUrlEntry.Source.ToString(),
            };

            //agentService.UpdateAgent(editAgent.AgentId, a);
            return a;
        }
        
        private async void Button_Clicked(object sender, EventArgs e)
        {
            //int Id ;
            //int.TryParse(AgentIdEntry.Text, out Id);
            //Agent agent = new Agent
            //{
            //    AgentId = Id,
            //    AgentName = AgentNameEntry.Text,
            //    AgentDecription = AgentDecriptionEntry.Text,
            //    AgentImageUrl = AgentImageUrlEntry.Source.ToString(),
            //    IsAssigned = false

            //};
            
            
            await Navigation.PopAsync();
            
        }
    }
}