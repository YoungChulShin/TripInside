using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TripInside.DependencyServices;
using TripInside.Models;
using TripInside.View.Trip;
using Xamarin.Forms;

namespace TripInside.ViewModel.Trip
{
    public class CreateInsideCameraViewModel : BaseViewModel
    {
        private INavigation _navigation;
        private List<Image> _images;
        private int _imageIndex;
        private ImageSource _currentImage;
        private Stream _stream;
        public CreateInsideCameraViewModel(INavigation navigaion, List<Image> images, int index)
        {
            _navigation = navigaion;
            _imageIndex = index;
            _images = images;
        }

        public ImageSource BackwardImage
        {
            get
            {
                return ImageSource.FromResource("TripInside.Resources.Images.Controls.backward.png");
            }
        }

        public ImageSource ForwardImage
        {
            get
            {
                return ImageSource.FromResource("TripInside.Resources.Images.Controls.forward.png");
            }
        }

        public ImageSource CurrentImage
        {
            get
            {
                return _currentImage;
            }
            set
            {
                _currentImage = value;
                OnPropertyChanged();
            }
        }

        public ICommand MoveBack
        {
            get
            {
                return new Command(x =>
                {
                   MessagingCenter.Send<CreateInsideView, Stream>(
                       new CreateInsideView(), "UpdateCameraPicture", _stream);
                   
                   _navigation.PopModalAsync();
                });
            }
        }

        public ICommand GetPictureFromGallery
        {
            get
            {
                return new Command(async () =>
                {

                    _stream = await DependencyService.Get<IPicturePicker>().GetImageStreamAsync();
                    CurrentImage = ImageSource.FromStream(() => _stream);
                    
                });
            }
        }
    }
}
