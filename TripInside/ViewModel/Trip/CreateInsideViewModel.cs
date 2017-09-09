using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using TripInside.Database;
using TripInside.Models;
using TripInside.Models.DBModels;
using TripInside.View.Trip;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace TripInside.ViewModel.Trip
{
    public class CreateInsideViewModel : BaseViewModel
    {
        private const int MAX_IMAGE_COUNT = 10;
        private INavigation _navigation;
        private ImageSource _picture1;
        private ImageSource _picture2;
        private ImageSource _picture3;
        private ImageSource _picture4;
        private ImageSource _picture5;
        private ImageSource _picture6;
        private ImageSource _picture7;
        private ImageSource _picture8;
        private ImageSource _picture9;
        private ImageSource _picture10;
        private string _insideDate;
        private readonly string _weather_sunny = "WeatherSunny";
        private readonly string _weather_cloudy = "WeatherCloudy";
        private readonly string _weather_rainy = "WeatherRainy";
        private readonly string _weather_snowy = "WeatherSnowy";
        private string _currentWeather = string.Empty;
        private string _gpsLocation = string.Empty;
        private Geocoder _geoCoder;
        private string _storyText = string.Empty;
        private bool _viewPictures = false;

        private List<ImageSource> _cameraPictures = new List<ImageSource>();
        private List<byte[]> _imageDatas = new List<byte[]>();

        private List<CameraGallery> _galleryModel;


        private TripHistory _tripHistory;


        public CreateInsideViewModel(INavigation navigation, int tripID)
        {
            _navigation = navigation;
            _geoCoder = new Geocoder();
            _currentWeather = _weather_sunny;

            _tripHistory = new TripHistory();
            _tripHistory.Id = tripID;
            _tripHistory.RegisterDate = DateTime.Now;

            //_imageDatas.Clear();
            //_imageDatas.Add(_tripHistory.Image1);
            //_imageDatas.Add(_tripHistory.Image2);
            //_imageDatas.Add(_tripHistory.Image3);
            //_imageDatas.Add(_tripHistory.Image4);
            //_imageDatas.Add(_tripHistory.Image5);
            //_imageDatas.Add(_tripHistory.Image6);
            //_imageDatas.Add(_tripHistory.Image7);
            //_imageDatas.Add(_tripHistory.Image8);
            //_imageDatas.Add(_tripHistory.Image9);
            //_imageDatas.Add(_tripHistory.Image10);

            //_cameraPictures.Add(Picture1);
            //_cameraPictures.Add(Picture2);
            //_cameraPictures.Add(Picture3);
            //_cameraPictures.Add(Picture4);
            //_cameraPictures.Add(Picture5);
            //_cameraPictures.Add(Picture6);
            //_cameraPictures.Add(Picture7);
            //_cameraPictures.Add(Picture8);
            //_cameraPictures.Add(Picture9);
            //_cameraPictures.Add(Picture10);

            InsideDate = GetInsideDateFromDateTime(_tripHistory.RegisterDate);

            OnPropertyChanged(_currentWeather);
        }

        private string GetInsideDateFromDateTime(DateTime writeDate)
        {
            return string.Format("{0}({1}) {2}",
                writeDate.ToString("yyyy.MM.dd"),
                GetWeekDay(writeDate),
                writeDate.ToString("HH:mm"));
        }

        private string GetWeekDay(DateTime dateTime)
        {
            string tempWeekDay = string.Empty;
            var dt = dateTime.DayOfWeek;

            switch (dt)
            {
                case DayOfWeek.Monday: //월
                    tempWeekDay = "월";
                    break;

                case DayOfWeek.Tuesday: //화
                    tempWeekDay = "화";
                    break;

                case DayOfWeek.Wednesday: //수
                    tempWeekDay = "수";
                    break;

                case DayOfWeek.Thursday: //목
                    tempWeekDay = "목";
                    break;

                case DayOfWeek.Friday: //금
                    tempWeekDay = "금";
                    break;

                case DayOfWeek.Saturday: //토
                    tempWeekDay = "토";
                    break;

                case DayOfWeek.Sunday: //일
                    tempWeekDay = "일";
                    break;
            }

            return tempWeekDay;
        }

        public bool ViewPictures
        {
            get
            {
                return _viewPictures;
            }
            set
            {
                _viewPictures = value;
                OnPropertyChanged();
            }
        }

        public string InsideDate
        {
            get
            {
                return _insideDate;
            }
            set
            {
                _insideDate = value;
                OnPropertyChanged();
            }
        }
        
        public ImageSource Picture1
        {
            get
            {
                return _picture1;
            }
            set
            {
                _picture1 = value;
                
                OnPropertyChanged();
            }
        }
        public ImageSource Picture2
        {
            get
            {
                return _picture2;
            }
            set
            {
                _picture2 = value;
                OnPropertyChanged();
            }
        }
        public ImageSource Picture3
        {
            get
            {
                return _picture3;
            }
            set
            {
                _picture3 = value;
                OnPropertyChanged();
            }
        }
        public ImageSource Picture4
        {
            get
            {
                return _picture4;
            }
            set
            {
                _picture4 = value;
                OnPropertyChanged();
            }
        }
        public ImageSource Picture5
        {
            get
            {
                return _picture5;
            }
            set
            {
                _picture5 = value;
                OnPropertyChanged();
            }
        }
        public ImageSource Picture6
        {
            get
            {
                return _picture6;
            }
            set
            {
                _picture6 = value;
                OnPropertyChanged();
            }
        }
        public ImageSource Picture7
        {
            get
            {
                return _picture7;
            }
            set
            {
                _picture7 = value;
                OnPropertyChanged();
            }
        }
        public ImageSource Picture8
        {
            get
            {
                return _picture8;
            }
            set
            {
                _picture8 = value;
                OnPropertyChanged();
            }
        }
        public ImageSource Picture9
        {
            get
            {
                return _picture9;
            }
            set
            {
                _picture9 = value;
                OnPropertyChanged();
            }
        }
        public ImageSource Picture10
        {
            get
            {
                return _picture10;
            }
            set
            {
                _picture10 = value;
                OnPropertyChanged();
            }
        }

        private void SetPictures(List<CameraGallery> cameraGallerys)
        {
            try
            {
                Picture1 = cameraGallerys[0].CameraPicture;
                _tripHistory.Image1 = cameraGallerys[0].ImageData;
                _cameraPictures.Add(_picture1);
            }
            catch
            {
                Picture1 = null;
                _tripHistory.Image1 = null;
            }

            try
            {
                Picture2 = cameraGallerys[1].CameraPicture;
                _tripHistory.Image2 = cameraGallerys[1].ImageData;
                _cameraPictures.Add(_picture2);
            }
            catch
            {
                Picture2 = null;
                _tripHistory.Image2 = null;
            }

            try
            {
                Picture3 = cameraGallerys[2].CameraPicture;
                _tripHistory.Image3 = cameraGallerys[2].ImageData;
                _cameraPictures.Add(_picture3);
            }
            catch
            {
                Picture3 = null;
                _tripHistory.Image3 = null;
            }

            try
            {
                Picture4 = cameraGallerys[3].CameraPicture;
                _tripHistory.Image4 = cameraGallerys[3].ImageData;
                _cameraPictures.Add(_picture4);
            }
            catch
            {
                Picture4 = null;
                _tripHistory.Image4 = null;
            }

            try
            {
                Picture5 = cameraGallerys[4].CameraPicture;
                _tripHistory.Image5 = cameraGallerys[4].ImageData;
                _cameraPictures.Add(_picture5);
            }
            catch
            {
                Picture5 = null;
                _tripHistory.Image5 = null;
            }

            try
            {
                Picture6 = cameraGallerys[5].CameraPicture;
                _tripHistory.Image6 = cameraGallerys[5].ImageData;
                _cameraPictures.Add(_picture6);
            }
            catch
            {
                Picture6 = null;
                _tripHistory.Image6 = null;
            }

            try
            {
                Picture7 = cameraGallerys[6].CameraPicture;
                _tripHistory.Image7 = cameraGallerys[6].ImageData;
                _cameraPictures.Add(_picture7);
            }
            catch
            {
                Picture7 = null;
                _tripHistory.Image7 = null;
            }

            try
            {
                Picture8 = cameraGallerys[7].CameraPicture;
                _tripHistory.Image8 = cameraGallerys[7].ImageData;
                _cameraPictures.Add(_picture8);
            }
            catch
            {
                Picture8 = null;
                _tripHistory.Image8 = null;
            }

            try
            {
                Picture9 = cameraGallerys[8].CameraPicture;
                _tripHistory.Image9 = cameraGallerys[8].ImageData;
                _cameraPictures.Add(_picture9);
            }
            catch
            {
                Picture9 = null;
                _tripHistory.Image9 = null;
            }

            try
            {
                Picture10 = cameraGallerys[9].CameraPicture;
                _tripHistory.Image10 = cameraGallerys[9].ImageData;
                _cameraPictures.Add(_picture10);
            }
            catch
            {
                Picture10 = null;
                _tripHistory.Image10 = null;
            }

            ViewPictures = (cameraGallerys.Count == 0) ? false : true;
        }

        public ImageSource WeatherSunny
        {
            get
            {
                if (_currentWeather == _weather_sunny)
                {
                    return ImageSource.FromResource("TripInside.Resources.Images.Weathers.sun_selected.png");
                }
                else
                {
                    return ImageSource.FromResource("TripInside.Resources.Images.Weathers.sun.png");
                }
            }
        }
		public ImageSource WeatherCloudy
        {
			get
			{
                if (_currentWeather == _weather_cloudy)
                {
                    return ImageSource.FromResource("TripInside.Resources.Images.Weathers.cloud_selected.png");
                }
                else
                {
                    return ImageSource.FromResource("TripInside.Resources.Images.Weathers.cloud.png");
                }
			}
		}
		public ImageSource WeatherRainy
        {
			get
			{
                if (_currentWeather == _weather_rainy)
                {
                    return ImageSource.FromResource("TripInside.Resources.Images.Weathers.rain_selected.png");
                }
                else
                {
                    return ImageSource.FromResource("TripInside.Resources.Images.Weathers.rain.png");
                }
			}
		}
		public ImageSource WeatherSnowy
        {
			get
			{
                if (_currentWeather == _weather_snowy)
                {
                    return ImageSource.FromResource("TripInside.Resources.Images.Weathers.snow_selected.png");
                }
                else
                {
                    return ImageSource.FromResource("TripInside.Resources.Images.Weathers.snow.png");
                }
			}
		}

		public ImageSource Compass
		{
			get
			{
				return ImageSource.FromResource("TripInside.Resources.Images.Weathers.checkin.png");
			}
		}
        public ImageSource Camera
        {
            get
            {
                return ImageSource.FromResource("TripInside.Resources.Images.Weathers.camera.png");
            }
        }

        public ICommand CancelCreateInside
		{
			get
			{
				return new Command(async () =>
				{
                    MessagingCenter.Unsubscribe<CreateInsideView, List<CameraGallery>>(this, "AddCameraPicture");
                    await _navigation.PopModalAsync();
                });
			}
		}

        public ICommand CreateInside
        {
            get
            {
                return new Command(x =>
                {
                    _tripHistory.Weather = _currentWeather;
                    _tripHistory.Contents = _storyText;

                    TripDataAccess.SaveTripHistory(_tripHistory);
                    MessagingCenter.Unsubscribe<CreateInsideView, List<CameraGallery>>(this, "AddCameraPicture");

                    _navigation.PopModalAsync();
                });
            }
        }

        public ICommand SetWeatherToSunny
        {
            get
            {
                return new Command( x =>
                {
                    if (_currentWeather != _weather_sunny)
                    {
                        OnPropertyChanged(_currentWeather);
                        OnPropertyChanged(_weather_sunny);
                        _currentWeather = _weather_sunny;
                    }
                });
            }
        }
        public ICommand SetWeatherToCloudy
        {
            get
            {
                return new Command(x =>
                {
                    if (_currentWeather != _weather_cloudy)
                    {
                        OnPropertyChanged(_currentWeather);
                        OnPropertyChanged(_weather_cloudy);
                        _currentWeather = _weather_cloudy;
                    }
                });
            }
        }
        public ICommand SetWeatherToRainy
        {
            get
            {
                return new Command(x =>
                {
                    if (_currentWeather != _weather_rainy)
                    {
                        OnPropertyChanged(_currentWeather);
                        OnPropertyChanged(_weather_rainy);
                        _currentWeather = _weather_rainy;
                    }
                });
            }
        }
        public ICommand SetWeatherToSnowy
        {
            get
            {
                return new Command(x =>
                {
                    if (_currentWeather != _weather_snowy)
                    {
                        OnPropertyChanged(_currentWeather);
                        OnPropertyChanged(_weather_snowy);
                        _currentWeather = _weather_snowy;
                    }
                });
            }
        }

        public ICommand GetGPSLocation
        {
            get
            {
                return new Command(async () =>
                {
                    var locator = CrossGeolocator.Current;
                    locator.DesiredAccuracy = 50;

                    var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(10));
                    if (position == null)
                    {
                        GPSLocation = "Empty";
                    }
                    else
                    {
                        string tempLocation = string.Empty;
                        var currentPosition = new Position(position.Latitude, position.Longitude);
                        try
                        {

                            var possibleAddresses = await _geoCoder.GetAddressesForPositionAsync(currentPosition);

                            foreach (var a in possibleAddresses)
                            {
                                //tempLocation += a + "\n";
                                tempLocation = a;
                                break;
                            }

                            GPSLocation = tempLocation;

                            //GPSLocation = position.Latitude.ToString() + " " + position.Longitude.ToString();
                            _tripHistory.Latitude = position.Latitude;
                            _tripHistory.Longitude = position.Longitude;
                        }
                        catch (Exception ex)
                        {
                            GPSLocation = "Can't get location. " + ex.Message;
                            _tripHistory.Latitude = 0;
                            _tripHistory.Longitude = 0;
                        }
                    }
                });
            }
        }
        public string GPSLocation
        {
            get
            {
                return _gpsLocation;
            }
            set
            {
                _gpsLocation = value;
                OnPropertyChanged();
            }
        }

        public ICommand ManagePicture
        {
            get
            {
                return new Command(async () =>
               {              
                   await _navigation.PushAsync(new CreateInsideCameraView(_galleryModel));
               });
            }
        }

        public override void OnAppearing()
        {
            MessagingCenter.Unsubscribe<CreateInsideView, List<CameraGallery>>(this, "AddCameraPicture");
            MessagingCenter.Unsubscribe<CreateInsideView, ImageSource>(this, "RemoveCameraPicture");

            MessagingCenter.Subscribe<CreateInsideView, List<CameraGallery>>(this, "AddCameraPicture", (sender, arg) =>
            {
                _galleryModel = arg;
                SetPictures(_galleryModel);
            });

            //MessagingCenter.Subscribe<CreateInsideView, ImageSource>(this, "RemoveCameraPicture", (sender, arg) =>
            //{
            //    if (_cameraPictures.Contains(arg))
            //    {
            //        _cameraPictures.Remove(arg);
            //        SetPictures(_cameraPictures);
            //    }
            //});
        }

        public override void OnDisappearing()
        {
            //MessagingCenter.Unsubscribe<CreateInsideView, List<CameraGallery>>(this, "AddCameraPicture");
            //_cameraPictures.Clear();
            //ViewPictures = false;
        }

        public string StoryText
        {
            get
            {
                return _storyText;
            }
            set
            {
                _storyText = value;
                OnPropertyChanged();
            }
        }
    }
}
