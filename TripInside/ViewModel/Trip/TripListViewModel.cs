using System;
using TripInside.Service;
using Xamarin.Forms;
using System.Windows.Input;
using TripInside.View.Trip;
using TripInside.Database;
using System.Collections.ObjectModel;
using System.Linq;
using TripInside.Model;
using System.Reflection;
using System.IO;

namespace TripInside.ViewModel.Trip
{
    public class TripListViewModel : BaseViewModel
    {
        INavigation _navigation;
        private ObservableCollection<Model.Trip> _items;

        public ObservableCollection<Model.Trip> Items
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

        public TripListViewModel(INavigation navigation)
        {
            _navigation = navigation;

            MakeItems();
            //_items = new ObservableCollection<Model.Trip>(TripDataAccess.GetTrips());
        }

        public bool ViewCreateTrip
        {
            get
            {
                int tripCount = TripDataAccess.GetTripCount();

                return (tripCount == 0) ? true : false;
            }
        }

        public ICommand CreateNewTrip
        {
            get
            {
                return new Command(() =>
                {
                    _navigation.PushModalAsync(new CreateTripView());
                });
            }
        }


		private void MakeItems()
		{
            _items = new ObservableCollection<Model.Trip>();
            foreach (var trip in TripDataAccess.GetTrips())
            {
                _items.Add(trip);
            }
		}
    }
}
