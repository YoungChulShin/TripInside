using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TripInside.View.Trip;
using Xamarin.Forms;

namespace TripInside.ViewModel.Trip
{
    public class InsideViewModel : BaseViewModel
    {
        private INavigation _navigation;
        private InsideMapView _mapView;
        private InsidePictureView _pictureView;
        private InsideStoryView _storyView;
        private ContentView _currentView;

        public InsideViewModel(INavigation navigation)
        {
            _navigation = navigation;
            _mapView = new InsideMapView();
            _pictureView = new InsidePictureView();
            _storyView = new InsideStoryView();

            CurrentView = _storyView;
        }

        public ImageSource BackImage
        {
            get
            {
                return ImageSource.FromResource("TripInside.Resources.Images.Controls.back.png");
            }
        }

        public ImageSource AddImage
        {
            get
            {
                return ImageSource.FromResource("TripInside.Resources.Images.Controls.Add.png");
            }
        }

        public ICommand MoveBack
        {
            get
            {
                return new Command(async () =>
                {
                    await _navigation.PopModalAsync();
                });
            }
        }

        public ICommand AddNew
        {
            get
            {
                return new Command(async () =>
                {
                    //await _navigation.PushModalAsync(new CreateInsideView());
                    await _navigation.PushAsync(new CreateInsideView());
                });
            }
        }

        public ICommand ViewInsideStory
        {
            get
            {
                return new Command(x =>
                {
                    if (_currentView.GetType().Equals(typeof(InsideStoryView)) == false)
                    {
                       CurrentView = _storyView;
                    }
                });
            }
        }

        public ICommand ViewPictureStory
        {
            get
            {
                return new Command(x =>
                {
                    if (_currentView.GetType().Equals(typeof(InsidePictureView)) == false)
                    {
                       CurrentView = _pictureView;
                    }
                });
            }
        }

        public ICommand ViewMapStory
        {
            get
            {
                return new Command(x =>
                {
                    if (_currentView.GetType().Equals(typeof(InsideMapView)) == false)
                    {
                       CurrentView = _mapView;
                    }
                });
            }
        }

        public ContentView CurrentView
        {
            get
            {
                return _currentView;
            }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }
    }
}
