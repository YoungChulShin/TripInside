using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TripInside.Models
{
    public class CameraGallery
    {
        public ImageSource CameraPicture { get; set; }
        public ImageSource DeletePicture
        {
            get
            {
                return ImageSource.FromResource("TripInside.Resources.Images.Weathers.deletepicture.png");
            }
        }
    }
}
