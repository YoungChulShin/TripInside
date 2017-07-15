using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripInside.Types;
using Xamarin.Forms;

namespace TripInside.Models
{
    public class TripHistoryInfo
    {
        public int Id { get; set; }
        public DateTime RegisterDate { get; set; }
        //public string WeatherString { get; set; }
        public Image Weather { get; set; }
        //{
        //    get
        //    {
        //        if (WeatherString == WeatherType.Sunny)
        //        {

        //        }
        //        else if (WeatherString == WeatherType.Rainny)
        //        {

        //        }
        //        else if (WeatherString == WeatherType.Cloudy)
        //        {

        //        }
        //        else if (WeatherString == WeatherType.Snowy)
        //        {
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }
        //}

        public string RegisterDateString
        {
            get
            {
                return string.Format("{0}({1}) {2}",
                    RegisterDate.ToString("yyyy-MM-dd"),
                    RegisterDate.ToString("ddd"),
                    RegisterDate.ToString("HH:mm"));
            }
        }

        public long Latitude { get; set; }
        public long Longitude { get; set; }
        public string Location { get; set; }
        public string Contents { get; set; }

        public Image Image1 { get; set; }
        public Image Image2 { get; set; }
        public Image Image3 { get; set; }
        public Image Image4 { get; set; }
        public Image Image5 { get; set; }
    }
}
