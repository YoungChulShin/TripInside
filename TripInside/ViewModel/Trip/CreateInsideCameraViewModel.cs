﻿using System;
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
        private ImageSource _currentImage;

        public CreateInsideCameraViewModel(INavigation navigaion, List<CameraGallery> cameraGalley)
        {
            _navigation = navigaion;
            Items = new ObservableCollection<CameraGallery>();

            if (cameraGalley != null)
            {
                foreach (var item in cameraGalley)
                {
                    Items.Add(item);
                }
            }
        }

        public override void OnAppearing()
        {
            MessagingCenter.Subscribe<byte[]>(this, "ImageSelected", (args) =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    //Set the source of the image view with the byte array
                    var imageSource = ImageSource.FromStream(() => new MemoryStream(args));
                    var careraGallery = new CameraGallery()
                    {
                        CameraPicture = imageSource,
                        ImageData = args
                    };

                    Items.Add(careraGallery);
                });
            });
        }

        public override void OnDisappearing()
        {
            MessagingCenter.Send<CreateInsideView, List<CameraGallery>>(new CreateInsideView(), "AddCameraPicture", _items.ToList());
            MessagingCenter.Unsubscribe<byte[]>(this, "ImageSelected");
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
                        //MessagingCenter.Send<CreateInsideView, ImageSource>(new CreateInsideView(), "RemoveCameraPicture", parameter.CameraPicture);
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
                return new Command(() =>
                {
                    DependencyService.Get<ICamera>().BringUpPhotoGallery();
                });
            }
        }

        public ICommand GetPictureFromCamera
        {
            get
            {
                return new Command(() =>
                {
                    DependencyService.Get<ICamera>().BringUpCamera();
                });
            }
        }
    }
}
