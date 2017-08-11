using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using TripInside.Droid.Renderers;
using TripInside.MyControls;

[assembly: ExportRenderer(typeof(PlaceholderEditor), typeof(PlacehoderEditorRenderer))]
namespace TripInside.Droid.Renderers
{
    public class PlacehoderEditorRenderer : EditorRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);

            if (Element == null)
                return;

            var element = (PlaceholderEditor)Element;

            Control.Hint = element.Placeholder;
            Control.SetHintTextColor(element.PlaceholderColor.ToAndroid());
        }
    }
}