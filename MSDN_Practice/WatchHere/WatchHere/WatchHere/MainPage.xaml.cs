using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WatchHere
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            Color AmColor = Color.White;
            Color PmColor = Color.Cyan;
            //List<String> times = new List<string>()
            //{
            //    "Indian/Antananarivo","Indian/Chagos","Indian/Christmas","Indian/Cocos","Indian/Comoro","Indian/Kerguelen","Indian/Mahe","Indian/Maldives","Indian/Mauritius","Indian/Mayotte","Indian/Reunion"
            //};
            //Console.WriteLine("Kashish");
            //// Get All Time Zones  
            //foreach (TimeZoneInfo z in TimeZoneInfo.GetSystemTimeZones())
            //{
            //    TimeZoneInfo estZone = TimeZoneInfo.FindSystemTimeZoneById(z.Id.ToString());
            //    DateTime canTime = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.Local, estZone);
            //    Console.WriteLine("Time= {0}:{1}", z.Id, canTime);
            //}


            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                TimeZoneInfo indianZone = TimeZoneInfo.FindSystemTimeZoneById("Asia/Kolkata");
                TimeZoneInfo CanadaTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Canada/Eastern");
                TimeZoneInfo GermanyTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Europe/Berlin");
                TimeZoneInfo LondonTimeZOne = TimeZoneInfo.FindSystemTimeZoneById("Europe/London");

                DateTime indianZoneTime = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.Local, indianZone);

                if (indianZoneTime.ToString("tt") == "AM")
                {
                    IndianNameLabel.TextColor =  AmColor;
                    IndianTimeLabel.TextColor =  AmColor;

                }
                else
                {
                    IndianTimeLabel.TextColor =  PmColor;
                    IndianNameLabel.TextColor =  PmColor;
                }

                IndianNameLabel.Text = "India";
                IndianTimeLabel.Text = indianZoneTime.ToString("dd/MM/yyyy    hh:mm:ss:ttt");
                //------------------------------------------------------------------
                DateTime CanadaTime = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.Local, CanadaTimeZone);
                TorrontoNameLabel.Text = "Canada:Torronto";
                TorrontoTimeLabel.Text = CanadaTime.ToString("dd/MM/yyyy    hh:mm:ss:ttt");
                if (CanadaTime.ToString("tt") == "AM")
                {
                    TorrontoNameLabel.TextColor =  AmColor;
                    TorrontoTimeLabel.TextColor =  AmColor;

                }
                else
                {
                    TorrontoNameLabel.TextColor =  PmColor;
                    TorrontoTimeLabel.TextColor =  PmColor;
                }
                DateTime GermanyTime = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.Local, GermanyTimeZone);
                FrankfurtNameLabel.Text = "Germany";
                FrankfurtTimeLabel.Text = GermanyTime.ToString("dd/MM/yyyy    hh:mm:ss tt");
                if (GermanyTime.ToString("tt") == "AM")
                {
                    FrankfurtNameLabel.TextColor =  AmColor;
                    FrankfurtTimeLabel.TextColor =  AmColor;

                }
                else
                {
                    FrankfurtNameLabel.TextColor =  PmColor;
                    FrankfurtTimeLabel.TextColor =  PmColor;
                }
                DateTime LondonTime = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.Local, LondonTimeZOne);
                LondonNameLabel.Text = "London";
                LondonTimeLabel.Text = LondonTime.ToString("dd/MM/yyyy    hh:mm:ss:ttt");
                if (LondonTime.ToString("tt") == "AM")
                {
                    LondonNameLabel.TextColor =  AmColor;
                    LondonTimeLabel.TextColor =  AmColor;

                }
                else
                {
                    LondonNameLabel.TextColor =  PmColor;
                    LondonTimeLabel.TextColor =  PmColor;
                }
                return true;
            });
        }

        private void ImageTapped(object sender, EventArgs e)
        {
            
        }
    }

    [ContentProperty(nameof(Source))]
    public class ImageResourceExtension : IMarkupExtension
    {
        public String Source { get; set; }
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Source == null)
                return null;
            else
            {
                var imageSource = ImageSource.FromResource(Source, typeof(ImageResourceExtension).GetTypeInfo().Assembly);
                return imageSource;

            }
        }
    }
}
