using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using TripInside.View.Trip;
using System.Reflection;
using TripInside.Models.DBModels;
using TripInside.Database;
using TripInside.Models;

namespace TripInside.ViewModel.Trip
{
    public class NationalListViewModel : BaseViewModel
    {
        private INavigation _navigation;
        private ObservableCollection<NationalInfo> items;

        public NationalListViewModel(INavigation navigation)
        {
            _navigation = navigation;

            MakeNationalItems();
        }

		public ObservableCollection<NationalInfo> Items
		{
			get { return items; }
			set
			{
				items = value;
				OnPropertyChanged("Items");
			}
		}

        private void MakeNationalItems()
        {
            items = new ObservableCollection<NationalInfo>();
            foreach (Nation nation in NationDataAccess.GetNations())
            {
                items.Add(new NationalInfo()
                {
                    Code = nation.Code,
                    Name = nation.Name,
                    Flag = ImageSource.FromResource(string.Format("TripInside.Resources.Images.NationalFlag.{0}.gif", nation.Code))
                });
            }
        }
    }
}
