using System;
using System.ComponentModel;
using System.Windows.Input;
using Tasks.Models;
using Xamarin.Forms;

namespace Tasks.ViewModel
{
    public class ControllerViewModel : INotifyPropertyChanged
        
    {
        public ICommand registerCommand { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        private Controller _controller; 
        public Controller controller {
            get { return _controller; }
            set { _controller = value; OnPropertyChanged(nameof(controller)); }
        }
        
        public ControllerViewModel()
        {
            
            controller = new Controller();
            
            registerCommand = new Command(async () =>
             {
                 await App.Current.MainPage.DisplayAlert("Registered", controller.DeviceName, "Ok");
             });
        }

        private async void OnRegister()
        {
            throw new NotImplementedException();
        }

        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
