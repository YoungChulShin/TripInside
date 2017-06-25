using System;
using TripInside.MyControls;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(DatePicker), typeof(MyDatePicker))]
namespace TripInside.iOS.MyControls
{
    public class MyDatePicker : DatePickerRenderer
    {
		protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
		{
			base.OnElementChanged(e);
			Control.Font = Control.Font.WithSize(14);
		}
    }
}
