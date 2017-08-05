using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private ObservableCollection<CameraGallery> _items;
        private INavigation _navigation;
        private List<Image> _images;
        private int _imageIndex;
        private ImageSource _currentImage;
        private Stream _stream;
        private CameraGallery _selectedItem;

        public CreateInsideCameraViewModel(INavigation navigaion, List<Image> images, int index)
        {
            _navigation = navigaion;
            _imageIndex = index;
            _images = images;


            Items = new ObservableCollection<CameraGallery>();
        }

        public ObservableCollection<CameraGallery> Items
        {
            get
            {
                return _items;
            }
            set
            {
                _items = value;
                OnPropertyChanged();
            }
        }

        public ImageSource TakePicture
        {
            get
            {
                return ImageSource.FromResource("TripInside.Resources.Images.Weathers.takepicture.png");
            }
        }

        public ImageSource Gallery
        {
            get
            {
                return ImageSource.FromResource("TripInside.Resources.Images.Weathers.gallery.png");
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

        public ICommand RemoveItem
        {
            get
            {
                return new Command<CameraGallery>((parameter) =>
                {
                    if (parameter.IsSelectedPicture)
                    {
                        Items.RemoveAt(_items.IndexOf(parameter));
                        MessagingCenter.Send<CreateInsideView, ImageSource>(new CreateInsideView(), "RemoveCameraPicture", parameter.CameraPicture);
                    }
                });
            }
        }

        public ICommand CheckItem
        {
            get
            {
                return new Command<CameraGallery>((parameter) =>
                {
                    Items[Items.IndexOf(parameter)].IsSelectedPicture = !parameter.IsSelectedPicture;
                });
            }
        }

        public ICommand GetPictureFromGallery
        {
            get
            {
                return new Command(async () =>
                {
                    ImageSource image = await GetImageFromGalleary();
                    Items.Add(new CameraGallery()
                    {
                        CameraPicture = image
                    });
                    MessagingCenter.Send<CreateInsideView, ImageSource>(new CreateInsideView(), "AddCameraPicture", image);
                });
            }
        }

        private async Task<ImageSource> GetImageFromGalleary()
        {
            Stream imageStream = await DependencyService.Get<IPicturePicker>().GetImageStreamAsync();
          //  var result = imageStream.Length;
            return ImageSource.FromStream(() => imageStream);
        }
    }
}
