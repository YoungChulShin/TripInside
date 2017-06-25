using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TripInside.Model;
using System.Threading.Tasks;
using System.IO;
using TripInside.View.Trip;
using System.Reflection;

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
            foreach (string nationalInfo in GetNationalListText().Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries))
			{
                string[] nationalItem = nationalInfo.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                items.Add(new NationalInfo()
                {
                    Code = nationalItem[0],
                    Name = nationalItem[1],
                    Flag = ImageSource.FromResource(string.Format("TripInside.Resources.Images.NationalFlag.{0}.gif", nationalItem[0]))
                });
			}
        }

        private string GetNationalListText()
        {
            var assembly = this.GetType().GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("TripInside.Resources.Files.NationalList.txt");

            string nationalList = string.Empty;
            using (var reader = new System.IO.StreamReader(stream))
            {
                nationalList = reader.ReadToEnd();
            }

            return nationalList;
        }
    }
}
