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


            _items = new ObservableCollection<CameraGallery>();
            //_items.Add(new CameraGallery()
            //{
            //    CameraPicture = ImageSource.FromResource("TripInside.Resources.Images.Controls.ImageTest.jpg")
            //});
            //_items.Add(new CameraGallery()
            //{
            //    CameraPicture = ImageSource.FromResource("TripInside.Resources.Images.Controls.ImageTest2.jpg")
            //});
            //_items.Add(new CameraGallery()
            //{
            //    CameraPicture = ImageSource.FromResource("TripInside.Resources.Images.Controls.ImageTest3.jpg")
            //});
            //_items.Add(new CameraGallery()
            //{
            //    CameraPicture = ImageSource.FromResource("TripInside.Resources.Images.Controls.ImageTest4.jpg")
            //});
            //_items.Add(new CameraGallery()
            //{
            //    CameraPicture = ImageSource.FromResource("TripInside.Resources.Images.Controls.ImageTest5.jpg")
            //});
            OnPropertyChanged("Items");
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

        public CameraGallery SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;
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

        //public ICommand MoveBack
        //{
        //    get
        //    {
        //        return new Command(x =>
        //        {
        //           MessagingCenter.Send<CreateInsideView, Stream>(
        //               new CreateInsideView(), "UpdateCameraPicture", _stream);
                   
        //           _navigation.PopModalAsync();
        //        });
        //    }
        //}

        public ICommand RemoveItem
        {
            get
            {
                return new Command(x =>
                {
                    if (_selectedItem != null)
                    {
                        Items.Remove(_selectedItem);
                    }
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

                    Items.Add(new CameraGallery()
                    {
                        CameraPicture = ImageSource.FromStream(() => _stream)
                    });
                });
            }
        }
    }
}
