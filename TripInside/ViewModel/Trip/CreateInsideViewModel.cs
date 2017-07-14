using Plugin.Geolocator;
using System;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace TripInside.ViewModel.Trip
{
    public class CreateInsideViewModel : BaseViewModel
    {
        private INavigation _navigation;
        private readonly string _weather_sunny = "WeatherSunny";
        private readonly string _weather_cloudy = "WeatherCloudy";
        private readonly string _weather_rainy = "WeatherRainy";
        private readonly string _weather_snowy = "WeatherSnowy";
        private string _currentWeather = string.Empty;
        private string _gpsLocation = string.Empty;
        private Geocoder _geoCoder;

        public CreateInsideViewModel(INavigation navigation)
        {
            _navigation = navigation;
            _geoCoder = new Geocoder();
            _currentWeather = _weather_sunny;
            
            OnPropertyChanged(_currentWeather);
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

		public ImageSource EmotionHappiness
		{
			get
			{
				return ImageSource.FromResource("TripInside.Resources.Images.Emotions.happiness_blue.png");
			}
		}
		public ImageSource EmotionSmile
		{
			get
			{
				return ImageSource.FromResource("TripInside.Resources.Images.Emotions.smile_black.png");
			}
		}
		public ImageSource EmotionSad
		{
			get
			{
				return ImageSource.FromResource("TripInside.Resources.Images.Emotions.sad_black.png");
			}
		}
		public ImageSource EmotionAngry
		{
			get
			{
				return ImageSource.FromResource("TripInside.Resources.Images.Emotions.angry_black.png");
			}
		}

		public ImageSource Compass
		{
			get
			{
				return ImageSource.FromResource("TripInside.Resources.Images.Weathers.checkin.png");
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

                            var possibleAddresses = await _geoCoder.GetAddressesForPositionAsync(currentPosition);
                            foreach (var a in possibleAddresses)
                            {
                                tempLocation += a + "\n";
                            }

                            GPSLocation = tempLocation;
                        }
                        catch (Exception ex)
                        {

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
    }
}
