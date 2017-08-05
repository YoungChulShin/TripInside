using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TripInside.Models
{
    public class CameraGallery : BaseModel
    {
        private ImageSource _cameraPicture;
        private bool _isSelectedPicture = false;
        
        public ImageSource CameraPicture
        {
            get
            {
                return _cameraPicture;
            }
            set
            {
                _cameraPicture = value;
                OnPropertyChanged();
            }
        }
        public ImageSource DeletePicture
        {
            get
            {
                return ImageSource.FromResource("TripInside.Resources.Images.Weathers.deletepicture.png");
            }
        }
        public ImageSource SelectedPicture
        {
            get
            {
                return ImageSource.FromResource("TripInside.Resources.Images.Controls.checked.png");
            }
        }
        public bool IsSelectedPicture
        {
            get
            {
                return _isSelectedPicture;
            }
            set
            {
                _isSelectedPicture = value;
                OnPropertyChanged();
            }
        }
    }
}
