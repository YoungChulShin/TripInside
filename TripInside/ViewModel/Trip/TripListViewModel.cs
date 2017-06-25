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
        private string _title = string.Empty;
        private bool _viewTripListControls = false;
        private bool _viewCreateTripControls = false;

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

        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }

        public TripListViewModel(INavigation navigation)
        {
            _navigation = navigation;

            MessagingCenter.Subscribe<TripListView>(this, "UpdateTripList", (sender) =>
            {
                MakeTripListItems();
            });

            MakeTripListItems();
        }

        public bool ViewTripControls
        {
            get
            {
                return _viewTripListControls;
            }
            set
            {
                _viewTripListControls = value;
                _viewCreateTripControls = !value;
                OnPropertyChanged();
                OnPropertyChanged("ViewCreateTripControls");
            }
        }

        public bool ViewCreateTripControls
        {
            get
            {
                return _viewCreateTripControls;
            }
            set
            {
                _viewCreateTripControls = value;
                _viewTripListControls = !value;

                OnPropertyChanged();
                OnPropertyChanged("ViewTripControls");
            }
        }

        public string TripCount
        {
            get
            {
                return TripDataAccess.GetTripCount().ToString();
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

        private void MakeTripListItems()
		{
            Items = new ObservableCollection<Models.TripInfo>();

            Nation nation;
            foreach (var trip in TripDataAccess.GetTrips())
            {
                nation = NationDataAccess.GetNation(trip.NationalCode);

                Items.Add(new Models.TripInfo()
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

            if (_items.Count == 0)
            {
                Title = "여행 기록";
                ViewCreateTripControls = true;
            }
            else
            {
                Title = $"여행 기록 ({_items.Count})";
                ViewCreateTripControls = false;
            }
		}
    }
}
