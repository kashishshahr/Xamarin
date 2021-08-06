using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WatchHere.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WatchHere
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            //0a9b92601b5a4176b7e133629210608 web api key
            
            Color AmColor = Color.White;
            Color PmColor = Color.Cyan;

                CountryClass india=new CountryClass(0);
                CountryClass canada=new CountryClass(1);
                CountryClass germany = new CountryClass(2);
                CountryClass london=new CountryClass(3);
                
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                DateTime[] ZoneTime=new DateTime[4];
                ZoneTime[0] = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.Local, india.Zone);
                ZoneTime[1] = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.Local, canada.Zone);
                ZoneTime[2] = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.Local, germany.Zone);
                ZoneTime[3] = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.Local, london.Zone);
                if (india.ZoneTime.ToString("tt") == "AM")
                {
                    IndianNameLabel.TextColor = AmColor;
                    IndianTimeLabel.TextColor = AmColor;
                    IndianTempLabel.TextColor = AmColor;

                }
                else
                {
                    IndianTimeLabel.TextColor = PmColor;
                    IndianNameLabel.TextColor = PmColor;
                    IndianTempLabel.TextColor = PmColor;
                }

                IndianNameLabel.Text = india.Name;
                IndianTimeLabel.Text = ZoneTime[0].ToString("dd/MM/yyyy    hh:mm:ss:ttt");
                IndianTempLabel.Text = india.temp;
                //------------------------------------------------------------------

                TorrontoNameLabel.Text = canada.Name;
                TorrontoTimeLabel.Text = ZoneTime[1].ToString("dd/MM/yyyy    hh:mm:ss:ttt");
                TorrontoTempLabel.Text = canada.temp;
                if (canada.ZoneTime.ToString("tt") == "AM")
                {
                    TorrontoNameLabel.TextColor = AmColor;
                    TorrontoTimeLabel.TextColor = AmColor;
                    TorrontoTempLabel.TextColor = AmColor;

                }
                else
                {
                    TorrontoNameLabel.TextColor = PmColor;
                    TorrontoTimeLabel.TextColor = PmColor;
                    TorrontoTempLabel.TextColor = PmColor;
                }
                
                FrankfurtNameLabel.Text =germany.Name;
                FrankfurtTempLabel.Text =germany.temp;
                FrankfurtTimeLabel.Text = ZoneTime[2].ToString("dd/MM/yyyy    hh:mm:ss tt");
                if (germany.ZoneTime.ToString("tt") == "AM")
                {
                    FrankfurtNameLabel.TextColor = AmColor;
                    FrankfurtTimeLabel.TextColor = AmColor;
                    FrankfurtTempLabel.TextColor = AmColor;

                }
                else
                {
                    FrankfurtNameLabel.TextColor = PmColor;
                    FrankfurtTimeLabel.TextColor = PmColor;
                    FrankfurtTempLabel.TextColor = PmColor;
                }
                
                LondonNameLabel.Text = london.Name;
                LondonTempLabel.Text = london.temp;
                LondonTimeLabel.Text = ZoneTime[3].ToString("dd/MM/yyyy    hh:mm:ss:ttt");
                if (london.ZoneTime.ToString("tt") == "AM")
                {
                    LondonNameLabel.TextColor = AmColor;
                    LondonTimeLabel.TextColor = AmColor;
                    LondonTempLabel.TextColor = AmColor;

                }
                else
                {
                    LondonNameLabel.TextColor = PmColor;
                    LondonTimeLabel.TextColor = PmColor;
                    LondonTempLabel.TextColor = PmColor;
                }
                return true;
            });
        }
        
        private void InvisibleClick(object sender, EventArgs e)
        {
            var classId=(sender as Label).ClassId;
            Console.WriteLine(classId);
            if(classId== "IndianInvisibleClass")
            {
                IndiaCard.IsVisible = false;
                IndianInVisible.IsVisible =false;
                IndianVisible.IsVisible =true;
                
            } else if (classId == "CanadaClass")
            {
                CanadaCard.IsVisible = false;
                CanadaInVisible.IsVisible = false;
                CanadaVisible.IsVisible = true;
            } else if (classId == "GermanyClass")
            {

                GermanyCard.IsVisible = false;
                GermanyInVisible.IsVisible = false;
                GermanyVisible.IsVisible = true;
            } else if (classId == "LondonInvisibleClass")
            {

                LondonCard.IsVisible = false;
                LondonInVisible.IsVisible = false;
                LondonVisible.IsVisible = true;
            }
        }
        private void ImageTapped(object sender, EventArgs e)
        {
            
        }

        private void VisibleClick(object sender, EventArgs e)
        {
            var classId = (sender as Label).ClassId;
            Console.WriteLine(classId);
            if (classId == "IndianVisibeClass")
            {
                IndiaCard.IsVisible = true;
                IndianInVisible.IsVisible = true;
                IndianVisible.IsVisible = false;

            }
            else if (classId == "CanadaVisibeClass")
            {
                CanadaCard.IsVisible = true;
                CanadaInVisible.IsVisible = true;
                CanadaVisible.IsVisible = false;
            }
            else if (classId == "GermanyVisibeClass")
            {

                GermanyCard.IsVisible = true;
                GermanyInVisible.IsVisible = true;
                GermanyVisible.IsVisible = false;
            }
            else if (classId == "LondonVisibeClass")
            {

                LondonCard.IsVisible = true;
                LondonInVisible.IsVisible = true;
                LondonVisible.IsVisible = false;
            }
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
