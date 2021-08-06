using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WatchHere.Models
{

    public enum CountryIdEnum
    {
        India,Canada,Germany,London
    }
    class CountryClass:INotifyPropertyChanged
    {
        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
        
        public string _temp;
        public string temp { get { return _temp; } set { _temp = value; OnPropertyChanged(nameof(temp)); } }
        public DateTime ZoneTime;
        public TimeZoneInfo Zone;
        string[] Names;
        string[] TNames;
        public string Name;
         string[] CountryIds;
        public CountryClass(int id)
        {
            CountryIds =new string[4]{ "Asia/Kolkata", "Canada/Eastern", "Europe/Berlin", "Europe/London" };
            CountryId = CountryIds[id];
            Names = new string[4] { "India", "Canada", "Germany", "London" };
            TNames = new string[4] { "Ahmedabad", "91761", "Falkensee", "leeds" };
            Name = Names[id];
            GetWeather(TNames[id]);
            Zone = TimeZoneInfo.FindSystemTimeZoneById(CountryIds[id]);
            ZoneTime = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.Local,Zone);

        }
        public string CountryId;

        public event PropertyChangedEventHandler PropertyChanged;

        private async void GetWeather(string loc)
        {
            
            try
            {

                string url = $"http://api.weatherapi.com/v1/current.json?key=0a9b92601b5a4176b7e133629210608&q={loc}&aqi=no";
                HttpClient httpClient = new HttpClient();


                HttpResponseMessage responseMessage = await httpClient.GetAsync(url);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var content = await responseMessage.Content.ReadAsStringAsync();
                    var weatherList = JsonConvert.DeserializeObject<main>(content);

                    Console.WriteLine();
                    temp = weatherList.Current.temp_c.ToString()+ "\u00B0 C";
                }
                else
                {
                    temp = "Sorry";
                }
                
            }
            catch (Exception e)
            {
                string ee = e.Message;
            }
            
        }

    }
}
