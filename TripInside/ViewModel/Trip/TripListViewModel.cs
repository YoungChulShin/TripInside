using System;
using TripInside.Service;
using Xamarin.Forms;
using System.Windows.Input;
using TripInside.View.Trip;
using TripInside.Database;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.IO;
using TripInside.Models.DBModels;

namespace TripInside.ViewModel.Trip
{
    public class TripListViewModel : BaseViewModel
    {
        INavigation _navigation;
        private ObservableCollection<Models.TripInfo> _items;

        public ObservableCollection<Models.TripInfo> Items
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

        public string TripCount
        {
            get
            {
                return TripDataAccess.GetTripCount().ToString();
            }
        }

        public bool ViewTripList
        {
            get
            {
                return !ViewCreateTrip;
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
            _items = new ObservableCollection<Models.TripInfo>();

            Nation nation;
            foreach (var trip in TripDataAccess.GetTrips())
            {
                nation = NationDataAccess.GetNation(trip.NationalCode);

                _items.Add(new Models.TripInfo()
                {
                    Id = trip.Id,
                    Name = trip.Name,
                    NationalCode = nation.Code,
                    NationalName = nation.Name,
                    FromDate = trip.FromDate,
                    ToDate = trip.ToDate,
                    CreateDate = trip.CreateDate,
                    NationalFlag = ImageSource.FromResource($"TripInside.Resources.Images.NationalFlag.{nation.Code}.gif")
                });
            }
		}
    }
}
