using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace Tasks
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<DeviceRoles> role;

        public ObservableCollection<DeviceRoles> Roles
        {
            get { return role; }
            set { role = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("roles"));
            }
        }

        public MainViewModel()
        {
            Roles = new ObservableCollection<DeviceRoles>();
            AddRole();
        }
        private void AddRole()
        {
            Roles.Add(new DeviceRoles
            {
                Id = 0,
                Name = "Controller",
                imgSource = "https://images.idgesg.net/images/article/2017/10/user_interface_futuristic_digital_transformation_thinkstock_826567492-100740667-large.jpg"
            }); 
            Roles.Add(new DeviceRoles
            {
                Id = 1,
                Name = "Agent",
                imgSource = "https://thumbs.dreamstime.com/z/agent-word-marketing-concept-hand-arrange-wood-letters-as-109347719.jpg"

            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
