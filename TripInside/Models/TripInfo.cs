using System;
using Xamarin.Forms;

namespace TripInside.Models
{
    public class TripInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NationalCode { get; set; }
        public string NationalName { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public DateTime CreateDate { get; set; }
        public ImageSource NationalFlag { get; set; }
        public string DurationString
        {
            get
            {
                return $"{FromDate.ToString("yyyy.MM.dd")} ~ {ToDate.ToString("yyyy.MM.dd")}";
            }
        }
        public string InsideString
        {
            get
            {
                return "4 개";
            }
        }
    }
}
