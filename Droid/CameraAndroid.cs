
using Android.App;
using Android.Content;
using Android.Net;
using Android.OS;
using Android.Provider;
using Java.IO;
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
            var dir = new Java.IO.File(Environment.GetExternalStoragePublicDirectory(
            Environment.DirectoryPictures), "TripInside");
            
            var file = new File(dir, string.Format("tripInside{0}.jpg", "test"));


            intent.PutExtra(MediaStore.ExtraOutput, Uri.FromFile(file));

            ((Activity)Forms.Context).StartActivityForResult(intent, 2);
        }

        public void BringUpPhotoGallery()
        {
            var imageIntent = new Intent();
            imageIntent.SetType("image/*");
            imageIntent.SetAction(Intent.ActionGetContent);



            var intent = Intent.CreateChooser(imageIntent, "Select photo");

            ((Activity)Forms.Context).StartActivityForResult(intent, 1);
        }
    }
}