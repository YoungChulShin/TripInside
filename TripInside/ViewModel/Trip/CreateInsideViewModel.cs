using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using TripInside.Models;
using TripInside.View.Trip;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace TripInside.ViewModel.Trip
{
    public class CreateInsideViewModel : BaseViewModel
    {
        private INavigation _navigation;
        private ImageSource _picture1;
        private ImageSource _picture2;
        private ImageSource _picture3;
        private ImageSource _picture4;
        private ImageSource _picture5;
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

        public CreateInsideViewModel(INavigation navigation)
        {
            _navigation = navigation;
            _geoCoder = new Geocoder();
            _currentWeather = _weather_sunny;

            InsideDate = GetInsideDateFromDateTime();

            OnPropertyChanged(_currentWeather);
        }

        private string GetInsideDateFromDateTime()
        {
            DateTime currentDate = DateTime.Now;
            return string.Format("{0}({1}) {2}",
                currentDate.ToString("yyyy.MM.dd"),
                GetWeekDay(currentDate),
                currentDate.ToString("HH:mm"));
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

        private void SetPictures(List<ImageSource> pictures)
        {
            try { Picture1 = pictures[0]; } catch { Picture1 = null; }
            try { Picture2 = pictures[1]; } catch { Picture2 = null; }
            try { Picture3 = pictures[2]; } catch { Picture3 = null; }
            try { Picture4 = pictures[3]; } catch { Picture4 = null; }
            try { Picture5 = pictures[4]; } catch { Picture5 = null; }

            ViewPictures = (pictures.Count == 0) ? false : true;
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
                    await _navigation.PopModalAsync();
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

                            //var possibleAddresses = await _geoCoder.GetAddressesForPositionAsync(currentPosition);
                            //foreach (var a in possibleAddresses)
                            //{
                            //    tempLocation += a + "\n";
                            //}

                            //GPSLocation = tempLocation;

                            GPSLocation = position.Latitude.ToString() + " " + position.Longitude.ToString();
                        }
                        catch (Exception ex)
                        {
                            GPSLocation = "Can't get location";
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
                   await _navigation.PushAsync(new CreateInsideCameraView(_cameraPictures));
               });
            }
        }

        public override void OnAppearing()
        {
            MessagingCenter.Unsubscribe<CreateInsideView, ImageSource>(this, "AddCameraPicture");
            MessagingCenter.Unsubscribe<CreateInsideView, ImageSource>(this, "RemoveCameraPicture");

            MessagingCenter.Subscribe<CreateInsideView, ImageSource>(this, "AddCameraPicture", (sender, arg) =>
            {
                if (_cameraPictures.Contains(arg) == false)
                {
                    _cameraPictures.Add(arg);
                    SetPictures(_cameraPictures);
                }
            });

            MessagingCenter.Subscribe<CreateInsideView, ImageSource>(this, "RemoveCameraPicture", (sender, arg) =>
            {
                if (_cameraPictures.Contains(arg))
                {
                    _cameraPictures.Remove(arg);
                    SetPictures(_cameraPictures);
                }
            });
        }

        public override void OnDisappearing()
        {
            //_cameraPictures.Clear();
            //ViewPictures = false;
        }

        public string StoryText
        {
            get
            {
                if (String.IsNullOrEmpty(_storyText))
                {
                    return "이야기를 입력 해 주세요";
                }
                else
                {
                    return _storyText;
                }
            }
            set
            {
                _storyText = value;
                OnPropertyChanged();
            }
        }
    }
}
