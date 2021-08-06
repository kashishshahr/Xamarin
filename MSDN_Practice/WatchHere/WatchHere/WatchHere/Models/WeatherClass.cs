using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace WatchHere
{
    public class main
    {
        public location Location;

        public current Current;
        


    }
    public class location
    {
        public string name;
        public string region;
        public string country;
        public float lat;
        public float lon;
        public string tz_id;
        public string localtime_epoch;
        public DateTime localtime;
    }
    public class condition
    {
        public string text;
       public  string icon;
        public int code;
    }
   public class current
    {
      public  string last_updated_epoch;
      public  DateTime last_updated;
      public  string temp_c;
      public  string temp_f;
      public  bool is_day;
      public  condition Condition;
      public  double wind_mph;
      public  double wind_kph;
      public  double wind_degree;
      public  string wind_dir;
      public  double pressure_mb;
      public  double pressure_in;
      public  float precip_mm;
      public  float precip_in;
      public  double humidity;
      public  double cloud;
      public  double feelslike_c;
      public  double feelslike_f;
      public  double vis_km;
      public  double vis_miles;
      public  double uv;
      public  double gust_mph;
        public double gust_kph;



    }
}
