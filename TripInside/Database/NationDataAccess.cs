using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using SQLite;
using TripInside.Models.DBModels;
using Xamarin.Forms;
using System.Reflection;
using System.IO;
using TripInside.View.Trip;

namespace TripInside.Database
{
    public class NationDataAccess
    {
		private static SQLiteConnection _database;
		private static ObservableCollection<Nation> Nations { get; set; }

        public NationDataAccess()
        {
			_database = DependencyService.Get<IDatabaseConnection>().DbConnection();
			_database.CreateTable<Nation>();

            Nations = new ObservableCollection<Nation>(_database.Table<Nation>());
            SaveTrip();
        }

        private static void SaveTrip()
		{
            Nation nation;
            if (GetNations().Count() == 0)
            {
                foreach (string nationalInfo in GetNationalListText().Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    string[] nationalItem = nationalInfo.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    nation = new Nation() { Code = nationalItem[0], Name = nationalItem[1] };

                    _database.InsertOrReplace(nation);
                }
            }
		}

		public static IEnumerable<Nation> GetNations()
		{
            var query = from nation in _database.Table<Nation>()
						select nation;

			return query.AsEnumerable();
		}

        public static Nation GetNation(string nationalCode)
        {
            return _database.Table<Nation>().FirstOrDefault(x => x.Code == nationalCode);
        }
        
        private static string GetNationalListText()
        {
            var assembly = (new TripListView()).GetType().GetTypeInfo().Assembly;
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
