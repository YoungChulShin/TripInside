using System;
using Xamarin.Forms;
namespace TripInside.Models
{
    public class NationalInfo
    {
		public string Code { get; set; } = string.Empty;
		public string Name { get; set; } = string.Empty;
        public ImageSource Flag { get; set; }
    }
}
