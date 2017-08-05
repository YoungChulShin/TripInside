using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Threading.Tasks;
using System.IO;
using Android.Database;
using Android.Provider;

//using Xamarin.Forms.Platform.Android;


namespace TripInside.Droid
{
    [Activity(Label = "TripInside.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public static readonly int PickImageId = 1000;
        public static readonly int GetImageFromGallery = 1;
        public static readonly int GetImageFromCamera = 2;
        public TaskCompletionSource<Stream> PickImageTaskCompletionSource { set; get; }

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
           // global::Xamarin.FormsMaps.Init(this, bundle);

            LoadApplication(new App());
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (requestCode == PickImageId)
            {
                if ((resultCode == Result.Ok) && (data != null))
                {
                    Android.Net.Uri uri = data.Data;
                    Stream stream = ContentResolver.OpenInputStream(uri);

                    // Set the Stream as the completion of the Task
                    PickImageTaskCompletionSource.SetResult(stream);
                }
                else
                {
                    PickImageTaskCompletionSource.SetResult(null);
                }
            }
            else if (requestCode == GetImageFromGallery)
            {
                if (resultCode == Result.Ok)
                {
                    var result = data.GetByteArrayExtra("data");
                    if (data .Data != null)
                    {
                        //Grab the Uri which is holding the path to the image
                        Android.Net.Uri uri = data.Data;

                        //Read the meta data of the image to determine what orientation the image should be in
                        //int orientation = getOrientation(uri);

                        //Stat a background task so we can do all the bitmap stuff off the UI thread
                        BitmapWorkerTask task = new BitmapWorkerTask(this.ContentResolver, uri);
                        task.Execute(0);
                    }
                }
            }
            else if (requestCode == GetImageFromCamera)
            {
                if (resultCode == Result.Ok)
                {
                    var dir = new Java.IO.File(Android.OS.Environment.GetExternalStoragePublicDirectory(
                          Android.OS.Environment.DirectoryPictures), "TripInside");

                    var file = new Java.IO.File(dir, string.Format("tripInside{0}.jpg", "test"));
                    Intent mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
                    Android.Net.Uri contentUri = Android.Net.Uri.FromFile(file);
                    mediaScanIntent.SetData(contentUri);
                    SendBroadcast(mediaScanIntent);

                    //int orientation = getOrientation(contentUri);
                    BitmapWorkerTask task = new BitmapWorkerTask(this.ContentResolver, contentUri);
                    task.Execute(0);
                }
            }
        }

        public int getOrientation(Android.Net.Uri photoUri)
        {
            ICursor cursor = Application.ApplicationContext.ContentResolver.Query(photoUri, new String[] { MediaStore.Images.ImageColumns.Orientation }, null, null, null);

            if (cursor.Count != 1)
            {
                return -1;
            }

            cursor.MoveToFirst();
            return cursor.GetInt(0);
        }
    }
}
