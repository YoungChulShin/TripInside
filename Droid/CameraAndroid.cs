
using Android.App;
using Android.Content;
using Android.Provider;
using TripInside.DependencyServices;
using Xamarin.Forms;

//assembly: Dependency(typeof(ImageTest.Droid.CameraAndroid))]
[assembly: Dependency(typeof(TripInside.Droid.CameraAndroid))]
namespace TripInside.Droid
{
    public class CameraAndroid : ICamera
    {
        public CameraAndroid()
        {
        }

        public void BringUpCamera()
        {
            var intent = new Intent(MediaStore.ActionImageCapture);
            ((Activity)Forms.Context).StartActivityForResult(intent, 1);
        }

        public void BringUpPhotoGallery()
        {
            var imageIntent = new Intent();
            imageIntent.SetType("image/*");
            imageIntent.SetAction(Intent.ActionGetContent);

            ((Activity)Forms.Context).StartActivityForResult(Intent.CreateChooser(imageIntent, "Select photo"), 1);
        }
    }
}