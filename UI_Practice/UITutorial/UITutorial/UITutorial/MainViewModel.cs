
using System.Collections.ObjectModel;
using System.ComponentModel;


namespace UITutorial
{
    class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        ObservableCollection<Places> _places;
        public ObservableCollection<Places> Places { get { return _places; }
            set {
                _places = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Places"));
            } }
        public MainViewModel()
        {
            Places = new ObservableCollection<Places>();
            addData();
        }
        private void addData()
        {
            Places.Add(
                new Places
                {
                    Id = 0,
                    Country = "Norway",
                    Title = "Nature's Place",
                    ImageSource= "https://images.pexels.com/photos/1940038/pexels-photo-1940038.jpeg"

                });
            Places.Add(
                new Places
                {
                    Id = 1,
                    Country = "Nepal",
                    Title = "Adventure of Mountain",
                    ImageSource= "https://images.pexels.com/photos/1531660/pexels-photo-1531660.jpeg"
                });
            Places.Add(
                new Places
                {
                    Id = 1,
                    Country = "Maldives",
                    Title = "Beach Is Life Where you can Drown",
                    ImageSource= "https://wallpapercave.com/wp/wp3398923.jpg"
                });
        }
    }
}
