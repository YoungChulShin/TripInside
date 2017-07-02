using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace TripInside.ViewModel.Trip
{
    public class CreateInsideViewModel : BaseViewModel
    {
        private INavigation _navigation;

        public CreateInsideViewModel(INavigation navigation)
        {
            _navigation = navigation;
        }

        public ImageSource WeatherSun
        {
            get
            {
                return ImageSource.FromResource("TripInside.Resources.Images.Weathers.sun_red.png");
            }
        }
		public ImageSource WeatherCloud
		{
			get
			{
				return ImageSource.FromResource("TripInside.Resources.Images.Weathers.cloud_black.png");
			}
		}
		public ImageSource WeatherRain
		{
			get
			{
				return ImageSource.FromResource("TripInside.Resources.Images.Weathers.rain_black.png");
			}
		}
		public ImageSource WeatherSnow
		{
			get
			{
				return ImageSource.FromResource("TripInside.Resources.Images.Weathers.snow_black.png");
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
				return ImageSource.FromResource("TripInside.Resources.Images.Weathers.compass_green.png");
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
    }
}
